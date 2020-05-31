using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Year { get; set; }
        public string Model { get; set; }

        public long Miles { get; set; }

        public string Vin { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
