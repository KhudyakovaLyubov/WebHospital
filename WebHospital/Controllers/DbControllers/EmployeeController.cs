﻿using System.Linq;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class EmployeeController : Controller //Работа с данными таблицы "Сотрудники"
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

        [HttpGet]
        public ActionResult EditEmployee(int? id) //Редактирование данных
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = context.Employee.Find(id);
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
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee) //Добавление записи в базу данных
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Employees", "Home");
        }

        protected override void Dispose(bool disposing) //Закрытие соединения с контекстом данных
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}