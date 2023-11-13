using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_for_TA_Applications.Models
{
    public enum EnglishFluency1
    {
        Native, Fluent, Adequete, Poor, None
    }
    public class Application1
    {
        
        [Display(Name = "Univesity of Utah ID",
            ShortName ="Unid",
            Prompt ="u1234567",
            Description ="Please use the form u1234567...")]
        [RegularExpression( @"^u[0-9]{7,7}", ErrorMessage = "Does not match the form u1234567")]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Program { get; set; }

        [Range(0, 4,
            ErrorMessage = "GPA must be from 0-4")]
        [Required]
        public double GPA { get; set; }
        [Required]
        [Range(0, 100,
            ErrorMessage = "Hours must be from 0-100")]
        public int Hours { get; set; }
        public string PersonalStatement { get; set; }
        [Required]
        public EnglishFluency1? EnglishFluency1 { get; set; }
        [Required]
        [DisplayName("Sem. Completed")]
        [Range(0, 50,
            ErrorMessage = "Semesters must be from 0-50")]

        public int SemestersCompleted { get; set; }
        public string LinkedIn { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string USERID { get; set; }
    }
}
