using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_for_TA_Applications.Models
{
    public class Availability
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string AvailabilityString { get; set; }
        [Required]
        public string USERID { get; set; }

        [Required]
        public bool Available { get; set; }
    }
}
