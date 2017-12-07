using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    public class SimplePerson
    {
        [Required(ErrorMessage = "*Name required")]
        [StringLength(20, MinimumLength = 0)]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Age required")]
        [Range(0, 120)]
        public int? Age { get; set; }
    }
}
