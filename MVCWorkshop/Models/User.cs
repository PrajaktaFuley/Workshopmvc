using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWorkshop.Models
{
    public class User
    { 
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        
        
    }
}
