using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
                
       
        public double PricePerHour { get; set; }

        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public int ServiceTypeId { get; set; }       
        public  ServiceType ServiceType { get; set; }     
             


    }
}
