using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_for_TA_Applications.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_for_TA_Applications.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Application> Application { get; set; }
        public DbSet<Application1> Application1 { get; set; }

        public DbSet<Availability> Availability { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EnrollmentOverTime> EnrollmentOverTimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<Application1>().ToTable("Applications1");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Availability>().ToTable("Availability");
            modelBuilder.Entity<EnrollmentOverTime>().ToTable("EnrollmentOverTimes");

        }
    }
}
