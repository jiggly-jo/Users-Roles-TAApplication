using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_for_TA_Applications.Models
{
    public class EnrollmentOverTime
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public int Enrollments { get; set; }

        [Required]
        public string Date { get; set; }
    }

}
