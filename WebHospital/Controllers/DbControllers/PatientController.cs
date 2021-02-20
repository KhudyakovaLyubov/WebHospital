using System.Web.Mvc;
using WebHospital.Models;


namespace WebHospital.Controllers.DbControllers
{
    public class PatientController : Controller //Работа с данными таблицы "Пациенты"
    {
        HospitalDbContext context = new HospitalDbContext(); //контекст данных

        [HttpGet]
        public ActionResult DetailsPatient(int id) //Форма просмотра данных по определенной записи
        {
            var patient = context.Patient.Find(id);
            if (patient != null)
            {
                return View(patient);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditPatient(int? id) //Переход на форму изменения записи
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var patient = context.Patient.Find(id);
            if (patient != null)
            {
                return View(patient);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditPatient(Patient patient) //Внесение изменений записи в базу данных
        {
            context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Patients", "Home");
        }

        [HttpGet]
        public ActionResult CreatePatient() //Переход на форму добавления новой записи
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePatient(Patient patient) //Добавление записи в базу данных
        {
            context.Patient.Add(patient);
            context.SaveChanges();
            return RedirectToAction("Patients", "Home");
        }


        [HttpGet]
        public ActionResult DeletePatient(int id) //Переход на форму удаления записи
        {
            var patient = context.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("DeletePatient")]
        public ActionResult DeleteConfirmedPatient(int id) //Удаление записи из базы данных
        {
            var patient = context.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            context.Patient.Remove(patient);
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