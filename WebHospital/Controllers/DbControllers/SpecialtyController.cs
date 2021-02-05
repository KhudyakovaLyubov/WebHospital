using System.Linq;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class SpecialtyController : Controller //Работа с данными таблицы "Специализации"
    {
        HospitalDbContext context = new HospitalDbContext(); //Контекст данных, связи между таблицами
        // GET: Specialty
        public ActionResult GetSpecialties(int? id) //Все записи по фильтру и без
        {
            var departments = context.Department.Find(id);
            IQueryable<Specialty> specialties = context.Specialty;
            specialties = specialties.Where(s => s.Department == departments.IDDepartment);
            return View(specialties);
        }

        [HttpGet]
        public ActionResult EditSpecialty(int? id) //Редактирование данных
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var specialty = context.Specialty.Find(id);
            ViewBag.departments = new SelectList(context.Department, "NameDepartment", "IDDepartment");
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
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult CreateSpecialty()
        {
            ViewBag.departments = new SelectList(context.Department, "NameDepartment", "IDDepartment");
            return View();
        }
        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty) //Добавление записи в базу данных
        {
            context.Specialty.Add(specialty);
            context.SaveChanges();
            return RedirectToAction("");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}