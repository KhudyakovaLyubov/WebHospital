using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers
{
    public class HomeController : Controller
    {
        HospitalDbContext context = new HospitalDbContext();
        public ActionResult Index()
        {
            return View(context.Department);
        }

        public ActionResult Patients()
        {
            return View(context.Patient);
        }

        public ActionResult Employees()
        {
            return View(context.Employee);
        }

        public ActionResult Parts()
        {
            return View(context.Part);
        }
    }
}