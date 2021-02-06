using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospital.Models;
using WebHospital.ViewModel;

namespace WebHospital.Controllers
{
    public class HomeController : Controller
    {
        HospitalDbContext context = new HospitalDbContext();
        public ActionResult Index(int? id) //Главная страница, отображение отделений, поиск врача
        {
            List<Employee> employees = context.Employee.ToList();
            List<Department> departments = context.Department.ToList();
            List<DepartmentModel> departModel = departments
                .Select(d => new DepartmentModel { Id = d.IDDepartment, Name = d.NameDepartment })
                .ToList();
            departModel.Insert(0, new DepartmentModel { Id = 0, Name = "Все отделения" }) ;
            SpecialtyViewModel svm = new SpecialtyViewModel
            {
                DepartmentList = departModel,
                EmployeeList = employees
            };
            if (id != null && id > 0)
                svm.EmployeeList = employees.Where(e => e.Specialty1.Department == id);
            return View(svm);
        }

        public ActionResult Patients() //Список врачей и данные по ним
        {
            return View(context.Patient);
        }

        public ActionResult Employees() //Список пациентов и данные по ним
        {
            return View(context.Employee);
        }

        public ActionResult Parts(int? id) // Фильтрация записей таблицы "Адреса" по полю "Участок"
        {
            /*List<Address> addresses = context.Address.ToList();
            List<Part> parts = context.Part.ToList();
            List<DepartmentModel> partModel = parts
                .Select(p => new DepartmentModel { Id = p.IDPart, Name = p.NamePart })
                .ToList();
            partModel.Insert(0, new DepartmentModel { Id = 0, Name = "Все" });
            SpecialtyViewModel avm = new SpecialtyViewModel
            {
                PartList = partModel,
                AddressList = addresses
            };
            if (id != null && id > 0)
                avm.AddressList = addresses.Where(a => a.Part1.IDPart == id);*/
            return View();
        }

        [HttpPost, ActionName("Employees")]
        public ActionResult DeleteConfirmedEmployee(int id) //Удаление записи из таблицы "Сотрудники"
        {
            var employee = context.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            context.Employee.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Employees");
        }

        [HttpPost, ActionName("Index")]
        public ActionResult DeleteConfirmedDepartment(int id) //Удаление записи из таблицы "Отделения"
        {
            var department = context.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            context.Department.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Index")]
        public ActionResult DeleteConfirmedSpecialty(int id) //Удаление записи из таблицы "Специализации"
        {
            var specialty = context.Specialty.Find(id);
            if (specialty == null)
            {
                return HttpNotFound();
            }
            context.Specialty.Remove(specialty);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Index")]
        public ActionResult DeleteConfirmedReception(int id) //Удаление записи из таблицы "Сотрудники"
        {
            var reception = context.Reception.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            context.Reception.Remove(reception);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Patients")]
        public ActionResult DeleteConfirmedPatient(int id) //Удаление записи из таблицы "Пациенты"
        {
            var patient = context.Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            context.Patient.Remove(patient);
            context.SaveChanges();
            return RedirectToAction("Patients");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}