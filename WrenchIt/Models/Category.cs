using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name= "Category Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public string DisplayOrder { get; set; }

    }
}
