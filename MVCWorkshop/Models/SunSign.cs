using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWorkshop.Models
{
    public class SunSign
    {
        [Key]
        public int SignId { get; set; }
        [Required]
        [StringLength(50)]
        public string SignName { get; set; }
        [Required]
        public DateTime SignDate { get; set; }

        public SunSign SignType { get; set; }

        public int id { get; set; }

        public User user { get; set; }
    }
}
