using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class CServiceRequestViewModel
    {
        public IEnumerable<Service> ServiceList { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}
