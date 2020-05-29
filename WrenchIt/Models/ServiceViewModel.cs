using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class ServiceViewModel
    {
        public Service Service { get; set; }
       // public Labor Labor { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}