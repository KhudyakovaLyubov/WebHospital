using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHospital.Models;

namespace WebHospital.Controllers.DbControllers
{
    public class SpecialtyController : Controller
    {
        HospitalDbContext context = new HospitalDbContext();
        // GET: Specialty
        public ActionResult GetSpecialties(int? id)
        {
            var departments = context.Department.Find(id);
            IQueryable<Specialty> specialties = context.Specialty;
            specialties = specialties.Where(s => s.Department == departments.IDDepartment);
            return View(specialties);
        }
    }
}