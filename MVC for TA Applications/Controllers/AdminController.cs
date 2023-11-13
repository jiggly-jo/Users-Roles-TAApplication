using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_for_TA_Applications.Areas.Identity.Data;
using MVC_for_TA_Applications.Data;
using MVC_for_TA_Applications.Models;

namespace MVC_for_TA_Applications.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<TAUser> _userManger;

        public AdminController(UserManager<TAUser> userManger, RoleManager<IdentityRole> roleManager, ApplicationContext context)
        {
            _userManger = userManger;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["roles"] = string.Join(",", _roleManager.Roles.ToList());
            ViewData["users"] = string.Join(",", _userManger.Users.ToList());
            return View(await _context.Application.ToListAsync());
        }
        public async Task<IActionResult> EnrollmentTrends()
        {
            return View(await _context.EnrollmentOverTimes.ToListAsync());
        }

        [HttpPost]
        public string[] GetEnrollmentData(string startDate,string endDate, string course)
        {
            //2021-1-15
            //DateTime start = new DateTime(Int32.Parse(startDate.Substring(0,4)), Int32.Parse(startDate.Substring(5, 2)), Int32.Parse(startDate.Substring(8, 2)));
            //DateTime end = new DateTime(Int32.Parse(endDate.Substring(0, 4)), Int32.Parse(endDate.Substring(5, 2)), Int32.Parse(endDate.Substring(8, 2)));
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            List<string> enrollmentanddate = new List<string>();
            for (var day = start.Date; day <= end; day = day.AddDays(1))
            {
                
                string currentdate = day.ToString().Substring(0,10);
                string currentMonth = currentdate.Substring(0, 2);
                string currentDay = currentdate.Substring(3, 2);
                string currentYear = currentdate.Substring(6, 4);
                if (currentDay.EndsWith("/"))
                {
                    currentDay = "0"+currentDay.Substring(0, 1);
                    currentYear = currentdate.Substring(5, 4);
                }

                
                currentdate = currentYear + "-"+currentMonth+"-"+currentDay;
                EnrollmentOverTime e = _context.EnrollmentOverTimes.FirstOrDefault(m => m.Date == currentdate && m.Course == course);
                enrollmentanddate.Add(currentdate);
                if(e == null)
                {
                    enrollmentanddate.Add("0");
                }
                else
                {
                    enrollmentanddate.Add(e.Enrollments.ToString());
                }
                
            }
            return enrollmentanddate.ToArray();
        }

        [HttpPost] 
        public async Task<IActionResult> Change_Role(string userid, string role, string add_remove) 
        {
            var user = await _userManger.FindByIdAsync(userid);
            
            if (add_remove == "add")
            {
                await _userManger.AddToRoleAsync(user, role);
                return Ok(new { success = true, message = "added!" });
            }

            await _userManger.RemoveFromRoleAsync(user, role);
            return Ok(new { success = true, message = "removed!" });


        }
    }
}
