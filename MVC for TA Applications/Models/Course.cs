using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_for_TA_Applications.Models
{
    public class Course
    {

        [Required]
        public int ID { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string SemestersOffered { get; set; }

        [Required]
        public int Years { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string CourseNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Univesity of Utah ID",
         ShortName = "Unid",
         Prompt = "u1234567",
         Description = "Please use the form u1234567...")]
        [RegularExpression(@"^u[0-9]{7,7}", ErrorMessage = "Does not match the form u1234567")]
        [Required]
        public string ProfessorUID { get; set; }

        [Required]
        public string ProfessorName { get; set; }

        [Required]
        public string TimeAndDays { get; set; }

        [Required]
        public string Location { get; set; }

        [Range(0, 10,
            ErrorMessage = "Credit Hours must be from 0-10")]
        [Required]
        public int CreditHours { get; set; }

        [Required]
        public int Enrollment { get; set; }

        public string Note { get; set; }

    }
}
