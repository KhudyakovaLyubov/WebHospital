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
        public ActionResult Index() //Главная страница, отображение отделений, поиск врача
        {
            return View();
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
            List<Address> addresses = context.Address.ToList();
            List<Part> parts = context.Part.ToList();
            List<PartModel> partModel = parts
                .Select(p => new PartModel { Id = p.IDPart, Name = p.NamePart })
                .ToList();
            partModel.Insert(0, new PartModel { Id = 0, Name = "Все" });
            AddressViewModel avm = new AddressViewModel
            {
                PartList = partModel,
                AddressList = addresses
            };
            if (id != null && id > 0)
                avm.AddressList = addresses.Where(a => a.Part1.IDPart == id);
            return View(avm);
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