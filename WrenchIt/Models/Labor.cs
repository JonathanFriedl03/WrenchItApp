using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class Labor
    {
        [Key]
        public int Id { get; set; }       
        [Display(Name = "Time of Job")]
        public double TimeOfJob { get; set; }
        [Required]
        [Display(Name ="Price per Hour")]
        public double PricePerHour { get; set; }
    }
}
