using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHospital.Models;

namespace WebHospital.ViewModel
{
    public class AddressViewModel
    {
        public IEnumerable<Address> AddressList { get; set; }
        public IEnumerable<PartModel> PartList { get; set; }
    }
}