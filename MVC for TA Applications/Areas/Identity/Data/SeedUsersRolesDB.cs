using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_for_TA_Applications.Data;
using Microsoft.AspNetCore.Identity;
using MVC_for_TA_Applications.Areas.Identity.Data;

namespace MVC_for_TA_Applications
{
    public class SeedUsersRolesDB
    {
        public static async Task InitializeAsync(TAUsersRolesDB db, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            db.Database.EnsureCreated();
            // Look for any applications
            if (rm.Roles.Any())
            {
                return;   // DB has been seeded
            }


            await rm.CreateAsync(new IdentityRole { Name = "Administrator" });
            await rm.CreateAsync(new IdentityRole { Name = "Professor" });
            await rm.CreateAsync(new IdentityRole { Name = "Applicant" });

            var admins = new TAUser[]
            {
                new TAUser{Name = "Addy", UserName="admin@utah.edu", EmailConfirmed=true,Unid = "u1234567"},

            };
            var profs = new TAUser[]
            {
                new TAUser{Name = "Saint Germain", UserName="professor@utah.edu", EmailConfirmed=true, Unid="u1234567"},

            };
            var applicants = new TAUser[]
            {
                new TAUser{Name = "Jimmy Trinh", UserName="u0000000@utah.edu",EmailConfirmed=true, Unid = "u0000000"},
                new TAUser{Name = "John Huynh", UserName="u0000001@utah.edu",EmailConfirmed=true, Unid = "u0000001"},
                new TAUser{Name = "Jonathan Rodriguez", UserName="u0000002@utah.edu",EmailConfirmed=true, Unid = "u0000002"}
            };

            var password = new PasswordHasher<TAUser>();
            foreach (var admin in admins)
            {
                var hashed = password.HashPassword(admin, "123ABC!@#def");
                admin.PasswordHash = hashed;
                await um.CreateAsync(admin);
                await um.AddToRoleAsync(admin, "Administrator");
            }
            foreach (var prof in profs)
            {
                var hashed = password.HashPassword(prof, "123ABC!@#def");
                prof.PasswordHash = hashed;
                await um.CreateAsync(prof);
                await um.AddToRoleAsync(prof, "Professor");
            }
            foreach (var applicant in applicants)
            {
                var hashed = password.HashPassword(applicant, "123ABC!@#def");
                applicant.PasswordHash = hashed;
                await um.CreateAsync(applicant);
                await um.AddToRoleAsync(applicant, "Applicant");
            }
        }
    }
}
