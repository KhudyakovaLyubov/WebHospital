using System.Web.Mvc;
using WebHospital.Models;


namespace WebHospital.Controllers.DbControllers
{
    public class PatientController : Controller //Работа с данными таблицы "Пациенты"
    {
        HospitalDbContext context = new HospitalDbContext();

        [HttpGet]
        public ActionResult DetailsPatient(int id)
        {
            var patient = context.Patient.Find(id);
            if (patient != null)
            {
                return View(patient);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditPatient(int? id) //Редактирование данных
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
        public ActionResult CreatePatient()
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
        public ActionResult DeletePatient(int id) //Удаление данных
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