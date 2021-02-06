using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHospital.Models;

namespace WebHospital.ViewModel
{
    public class SpecialtyViewModel
    {
        public IEnumerable<Employee> EmployeeList { get; set; }
        public IEnumerable<DepartmentModel> DepartmentList { get; set; }
    }
}