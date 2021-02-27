using System.Linq;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class EmployeeController : Controller //Работа с данными таблицы "Сотрудники"
    {
        HospitalDbContext context = new HospitalDbContext();

        [HttpGet]
        public ActionResult DetailsEmployee(int id) //Форма просмотра данных по определенной записи
        {
            var employee = context.Employee.Find(id);
            if (employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetEmployees(int? id) //Список врачей по специализации
        {
            var specialties = context.Specialty.Find(id);
            IQueryable<Employee> employees = context.Employee;
            employees = employees.Where(s => s.Specialty == specialties.IDSpecialty);
            return View(employees);
        }

        [HttpGet]
        public ActionResult EditEmployee(int? id) //Переход на форму изменения записи
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = context.Employee.Find(id);
            ViewBag.specialties = new SelectList(context.Specialty, "IDSpecialty", "NameSpecialty");
            if (employee != null)
            {
                return View(employee);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee) //Внесение изменений записи в базу данных
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Employees", "Home");
        }

        [HttpGet]
        public ActionResult CreateEmployee() //Переход на форму добавления новой записи
        {
            ViewBag.specialties = new SelectList(context.Specialty, "IDSpecialty", "NameSpecialty");
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee) //Добавление записи в базу данных
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Employees", "Home");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id) //Переход на форму удаления записи
        {
            var employee = context.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmedEmployee(int id) //Удаление записи из базы данных
        {
            var employee = context.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            int count = ReceptionCount(id);
            if(count != 0)
            {
                ViewBag.Message = "Невозможно удалить врача! Возможное решение: 1. Удалить записи на прием к данному врачу; 2. Поменять врача в записи на прием.";
                return View(employee);
            }
            context.Employee.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Employees", "Home");
        }

        private int ReceptionCount(int id) //Количество записей в связанной таблице по идентификатору главной таблицы
        {
            int count = 0;
            var employees = context.Employee.Find(id);
            IQueryable<Reception> receptions = context.Reception;
            receptions = receptions.Where(s => s.Employee == employees.IDEmpoyee);
            count = receptions.Count();
            return count;
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}