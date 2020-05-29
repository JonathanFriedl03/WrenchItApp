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

        public double Miles { get; set; }

        public string Vin { get; set; }

    }
}
