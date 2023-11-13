using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVC_for_TA_Applications.Areas.Identity.Data;
using MVC_for_TA_Applications.Models;

namespace MVC_for_TA_Applications.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationContext context, UserManager<TAUser> userManager)
        {
            context.Database.EnsureCreated();
            var app = await userManager.FindByNameAsync("u0000000@utah.edu");
            var app1 = await userManager.FindByNameAsync("u0000001@utah.edu");
            var app2 = await userManager.FindByNameAsync("u0000002@utah.edu");
            var applications = new Application1[]
            {
            new Application1{Name="Jimmy Trinh",ID="u0000000",PhoneNumber="801-455-5792", Address="3532 W Slalom Way", Degree = "BS", Program = "CS", GPA = 3.75,Hours=10,PersonalStatement = "Hi im jimmy",EnglishFluency1=EnglishFluency1.Native,SemestersCompleted=6, ApplicationDate = DateTime.Parse("2021-09-23"),ModificationDate=DateTime.Parse("2021-09-23"),USERID=await userManager.GetUserIdAsync(app)},
            new Application1{Name="John Huynh",ID="u0000001",PhoneNumber="801-455-5792", Address="3532 W Slalom Way", Degree = "BS", Program = "CS", GPA = 3.75,Hours=10,PersonalStatement = "Hi im john",EnglishFluency1=EnglishFluency1.Native,SemestersCompleted=6, ApplicationDate = DateTime.Parse("2021-09-23"),ModificationDate=DateTime.Parse("2021-09-23"),USERID=await userManager.GetUserIdAsync(app1)},
            new Application1{Name="Jonathan Rodriguez",ID="u0000002",PhoneNumber="801-000-0000", Address="1234 S West Valley", Degree = "BS", Program = "MC", GPA = 3.5,Hours=15,PersonalStatement = "I want job",EnglishFluency1=EnglishFluency1.Poor,SemestersCompleted=6, ApplicationDate = DateTime.Parse("2021-08-15"),ModificationDate=DateTime.Parse("2021-08-15"),USERID=await userManager.GetUserIdAsync(app2)},
            };
            // Look for any applications
            if (!context.Application1.Any())
            {


                foreach (Application1 s in applications)
                {
                    context.Application1.Add(s);
                }
                
            }
            // Look for any courses
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                     new Course{Section = "001", SemestersOffered = "Spring", Years = 2022, Title = "Intro Comp Programming",Department = "CS", CourseNumber = "1400",Description = "Algorithms class", ProfessorUID="u1234567", ProfessorName=" KOPTA,DANIEL M", TimeAndDays = "M/W 3:30-5:55", Location = "ASB", CreditHours = 4,  Enrollment = 150, Note = "Introduction to programming."},
                     new Course{Section = "007", SemestersOffered = "Spring", Years = 2022, Title = "Accel Obj-Orient Prog",Department = "CS", CourseNumber = "1420",Description = "Object Oriented Programming", ProfessorUID="u1234567", ProfessorName=" KOPTA,DANIEL M", TimeAndDays = "M/W 3:30-5:55", Location = "WEB", CreditHours = 4,  Enrollment = 100},
                     new Course{Section = "003", SemestersOffered = "Spring", Years = 2022, Title = "Love and Relationships",Department = "S", CourseNumber = "1212",Description = "Psycology of love and relationships", ProfessorUID="u1234567", ProfessorName=" KOPTA,DANIEL M", TimeAndDays = "M/W 3:30-5:55", Location = "GC", CreditHours = 3,  Enrollment = 150},
                     new Course{Section = "002", SemestersOffered = "Spring", Years = 2022, Title = "Discrete Structures",Department = "CS", CourseNumber = "2100",Description = "Discreet structures class", ProfessorUID="u1234567", ProfessorName="PANCHEKHA, PAVEL", TimeAndDays = "M/W 3:30-5:55", Location = "WEB", CreditHours = 4,  Enrollment = 50},
                     new Course{Section = "001", SemestersOffered = "Spring", Years = 2022, Title = "Computer Systems",Department = "CS", CourseNumber = "4400",Description = "Computer Systems", ProfessorUID="u1234567", ProfessorName=" KOPTA,DANIEL M", TimeAndDays = "M/W 3:30-5:55", Location = "WEB", CreditHours = 4,  Enrollment = 100},
                };
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
            }
            // Look for any enrollments
            if (!context.EnrollmentOverTimes.Any())
            {
                List<EnrollmentOverTime> enrollments = new List<EnrollmentOverTime>();
                using (var reader = new StreamReader(@"C:\Users\JohKing\Source\Repos\ps4---new-ta-application-johnsteam\MVC for TA Applications\Data\temp.csv"))
                {
                    var line = reader.ReadLine();
                    var dates = line.Split(",");

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        var values = line.Split(",");
                        string course = values[0];
                        string date = "";
                        for(int i = 1; i < values.Length; i++)
                        {
                            string month = dates[i].Substring(1,3);
                            int numberMonth = 0;
                            string day = dates[i].Substring(5, dates[i].Length - 5);
                            if(day.Length == 1)
                            {
                                day = "0" + day;
                            }
                            switch (month)
                            {
                                case "Jan":
                                    numberMonth = 1;
                                    break;
                                case "Feb":
                                    numberMonth = 2;
                                    break;
                                case "Mar":
                                    numberMonth = 3;
                                    break;
                                case "Apr":
                                    numberMonth = 4;
                                    break;
                                case "May":
                                    numberMonth = 5;
                                    break;
                                case "Jun":
                                    numberMonth = 6;
                                    break;
                                case "Jul":
                                    numberMonth = 7;
                                    break;
                                case "Aug":
                                    numberMonth = 8;
                                    break;
                                case "Sept":
                                    numberMonth = 9;
                                    break;
                                case "Oct":
                                    numberMonth = 10;
                                    break;
                                case "Nov":
                                    numberMonth = 11;
                                    break;
                                case "Dec":
                                    numberMonth = 12;
                                    break;              
                            }
                            EnrollmentOverTime e = new EnrollmentOverTime { Course = course, 
                                Date = "2021-"+ numberMonth.ToString() + "-" + day, 
                                Enrollments = Int32.Parse(values[i]) };
                            enrollments.Add(e);
                        }
                    }
                }
                foreach (EnrollmentOverTime e in enrollments)
                {
                    context.EnrollmentOverTimes.Add(e);
                }
            }

            //create date and time slots
            if (!context.Availability.Any())
            {
                List<Availability> av = new List<Availability>();
                String[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                foreach (Application1 a in applications)
                {
                    foreach (String day in days)
                    {
                        for (int hour = 8; hour < 20; hour++)
                        {
                            if ((a.ID == "u0000000" && day == "Monday" && hour < 12) || (a.ID == "u0000000" && day == "Friday" && hour >= 12 && hour < 17))
                            {
                                av.Add(new Availability { Available = true, AvailabilityString = $"{day} {hour}:00", USERID = a.USERID });
                            }
                            else
                            {
                                av.Add(new Availability { Available = false, AvailabilityString = $"{day} {hour}:00", USERID = a.USERID });
                            }
                               
                            for (int min = 15; min < 60; min += 15)
                            {
                                if ((a.ID == "u0000000" && day == "Monday" && hour < 12) || (a.ID == "u0000000" && day == "Friday" && hour >= 12 && hour < 17))
                                {
                                    av.Add(new Availability { Available = true, AvailabilityString = $"{day} {hour}:{min}", USERID = a.USERID });
                                }
                                else
                                {
                                    av.Add(new Availability { Available = false, AvailabilityString = $"{day} {hour}:{min}", USERID = a.USERID });
                                }
                                
                            }
                        }
                    }
                }

                foreach (Availability a in av)
                {
                    context.Availability.Add(a);
                }
                context.SaveChanges();
            }

            context.SaveChanges();
        }

    }
}
