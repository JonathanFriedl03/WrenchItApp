using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class ApproveServiceViewModel
    {
        public Service Service { get; set; }

        public int serviceId { get; set; }
        public double Quote { get; set; }
    }
}
