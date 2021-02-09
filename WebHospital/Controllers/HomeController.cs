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
        
        public ActionResult Structure()
        {
            return View(context.Specialty);
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}