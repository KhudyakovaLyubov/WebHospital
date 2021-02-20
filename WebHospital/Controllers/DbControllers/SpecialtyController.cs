using System.Linq;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class SpecialtyController : Controller //Работа с данными таблицы "Специализации"
    {
        HospitalDbContext context = new HospitalDbContext(); //Контекст данных, связи между таблицами
        // GET: Specialty
        public ActionResult GetSpecialties() //Все записи 
        {
            return PartialView(context.Specialty);
        }

        [HttpGet]
        public ActionResult EditSpecialty(int? id) //Переход на форму изменения записи
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var specialty = context.Specialty.Find(id);
            ViewBag.departments = new SelectList(context.Department, "IDDepartment", "NameDepartment");
            if (specialty != null)
            {
                return View(specialty);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditSpecialty(Specialty specialty) //Внесение изменений записи в базу данных
        {
            context.Entry(specialty).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Structure", "Home");
        }

        [HttpGet]
        public ActionResult CreateSpecialty() //Переход на форму добавления новой записи
        {
            ViewBag.departments = new SelectList(context.Department, "IDDepartment", "NameDepartment");
            return View();
        }
        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty) //Добавление записи в базу данных
        {
            context.Specialty.Add(specialty);
            context.SaveChanges();
            return RedirectToAction("Structure", "Home");
        }

        [HttpGet]
        public ActionResult DeleteSpecialty(int id) //Удаление данных
        {
            var specialty = context.Specialty.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            return View(specialty);
        }

        [HttpPost, ActionName("DeleteSpecialty")]
        public ActionResult DeleteConfirmedSpecialty(int id) //Удаление записи из базы данных
        {
            var specialty = context.Specialty.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            context.Specialty.Remove(specialty);
            context.SaveChanges();
            return RedirectToAction("Structure", "Home");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}