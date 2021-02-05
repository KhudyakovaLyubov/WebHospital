using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class EmployeeController : Controller
    {
        HospitalDbContext context = new HospitalDbContext();
        // GET: Employee
        public ActionResult GetEmployees(int? id)
        {
            var specialties = context.Specialty.Find(id);
            IQueryable<Employee> employees = context.Employee;
            employees = employees.Where(s => s.Specialty == specialties.IDSpecialty);
            return View(employees);
        }
    }
}