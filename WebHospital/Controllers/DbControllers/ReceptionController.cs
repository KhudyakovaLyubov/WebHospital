using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class ReceptionController : Controller //Работа с данными таблицы "Прием пациентов"
    {
        HospitalDbContext context = new HospitalDbContext(); //Контекст данных, связи между таблицами

        public ActionResult GetReceptions() //Список записей о приемах 
        {
            return View(context.Reception);
        }

        [HttpGet]
        public ActionResult EditReception(int? id) //Переход на форму изменения записи
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var reception = context.Reception.Find(id);
            ViewBag.employees = new SelectList(context.Employee, "IDEmpoyee", "FIOEmployee"); //Выпадающий список сотрудников
            ViewBag.patients = new SelectList(context.Patient, "IDPatient", "FIOPatient"); //Выпадающий список пациентов
            if (reception != null)
            {
                return View(reception);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditReception(Reception reception) //Внесение изменений записи в базу данных
        {
            context.Entry(reception).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Patients", "Home");
        }

        [HttpGet]
        public ActionResult CreateReception() //Переход на форму добавления записи
        {
            ViewBag.employees = new SelectList(context.Employee, "IDEmpoyee", "FIOEmployee"); //Выпадающий список сотрудников
            ViewBag.patients = new SelectList(context.Patient, "IDPatient", "FIOPatient"); //Выпадающий список пациентов
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateReception(Reception reception) //Добавление записи в базу данных
        {
            context.Reception.Add(reception);
            context.SaveChanges();
            return RedirectToAction("Patients", "Home");
        }

        [HttpGet]
        public ActionResult DeleteReception(int id) // Переход на форму удаления записи
        {
            var reception = context.Reception.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            return View(reception);
        }

        [HttpPost, ActionName("DeleteReception")]
        public ActionResult DeleteConfirmedReception(int id) //Удаление записи из базы данных
        {
            var reception = context.Reception.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            context.Reception.Remove(reception);
            context.SaveChanges();
            return RedirectToAction("Patients", "Home");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}