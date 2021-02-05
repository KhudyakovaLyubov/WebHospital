using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class DepartmentController : Controller //Работа с данными таблицы "Отделения"
    {
        HospitalDbContext context = new HospitalDbContext();

        [HttpGet]
        public ActionResult EditDepartment(int? id) //Редактирование данных
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var department = context.Department.Find(id);
            if (department != null)
            {
                return View(department);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditDepartment(Department department) //Внесение изменений записи в базу данных
        {
            context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department department) //Добавление записи в базу данных
        {
            context.Department.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}