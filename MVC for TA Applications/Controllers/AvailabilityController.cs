using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_for_TA_Applications.Areas.Identity.Data;
using MVC_for_TA_Applications.Data;
using MVC_for_TA_Applications.Models;

namespace MVC_for_TA_Applications.Controllers
{
    public class AvailabilityController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<TAUser> _userManger;
        private readonly Dictionary<int, string> timeslots;
        public AvailabilityController(ApplicationContext context, UserManager<TAUser> userManager)
        {
            _userManger = userManager;
            _context = context;
            timeslots = new Dictionary<int, string>();
            int currentTime = 800;
            //initialize dictionary monday
            for (int i = 1; i <= 48; i++)
            {
                string timeString = currentTime.ToString();
                string hour;
                string minutes;
                if (timeString.Length == 3)
                {
                    hour = timeString.Substring(0, 1);
                    minutes = timeString.Substring(1, 2);
                    timeString = hour + ":" + minutes;
                }
                else
                {
                    hour = timeString.Substring(0, 2);
                    minutes = timeString.Substring(2, 2);
                    timeString = hour + ":" + minutes;
                }
                if ( minutes == "45")
                {
                    currentTime = (currentTime - 45) + 100;
                 }
                else
                {
                    currentTime += 15;
                }
                timeslots.Add(i, "Monday "+ timeString);
            }
            currentTime = 800;
            //tuesday
            for (int i = 49; i <= 96; i++)
            {
                string timeString = currentTime.ToString();
                string hour;
                string minutes;
                if (timeString.Length == 3)
                {
                    hour = timeString.Substring(0, 1);
                    minutes = timeString.Substring(1, 2);
                    timeString = hour + ":" + minutes;
                }
                else
                {
                    hour = timeString.Substring(0, 2);
                    minutes = timeString.Substring(2, 2);
                    timeString = hour + ":" + minutes;
                }
                if (minutes == "45")
                {
                    currentTime = (currentTime - 45) + 100;
                }
                else
                {
                    currentTime += 15;
                }
                timeslots.Add(i, "Tuesday "+ timeString);
            }
            currentTime = 800;
            //wednesday
            for (int i = 97; i <= 144; i++)
            {
                string timeString = currentTime.ToString();
                string hour;
                string minutes;
                if (timeString.Length == 3)
                {
                    hour = timeString.Substring(0, 1);
                    minutes = timeString.Substring(1, 2);
                    timeString = hour + ":" + minutes;
                }
                else
                {
                    hour = timeString.Substring(0, 2);
                    minutes = timeString.Substring(2, 2);
                    timeString = hour + ":" + minutes;
                }
                if (minutes == "45")
                {
                    currentTime = (currentTime - 45) + 100;
                }
                else
                {
                    currentTime += 15;
                }
                timeslots.Add(i, "Wednesday " + timeString);
            }
            currentTime = 800;
            //thursday
            for (int i = 145; i <= 192; i++)
            {
                string timeString = currentTime.ToString();
                string hour;
                string minutes;
                if (timeString.Length == 3)
                {
                    hour = timeString.Substring(0, 1);
                    minutes = timeString.Substring(1, 2);
                    timeString = hour + ":" + minutes;
                }
                else
                {
                    hour = timeString.Substring(0, 2);
                    minutes = timeString.Substring(2, 2);
                    timeString = hour + ":" + minutes;
                }
                if (minutes == "45")
                {
                    currentTime = (currentTime - 45) + 100;
                }
                else
                {
                    currentTime += 15;
                }
                timeslots.Add(i, "Thursday " + timeString);
            }
            currentTime = 800;
            //friday
            for (int i = 193; i <= 240; i++)
            {
                string timeString = currentTime.ToString();
                string hour;
                string minutes;
                if (timeString.Length == 3)
                {
                    hour = timeString.Substring(0, 1);
                    minutes = timeString.Substring(1, 2);
                    timeString = hour + ":" + minutes;
                }
                else
                {
                    hour = timeString.Substring(0, 2);
                    minutes = timeString.Substring(2, 2);
                    timeString = hour + ":" + minutes;
                }
                if (minutes == "45")
                {
                    currentTime = (currentTime - 45) + 100;
                }
                else
                {
                    currentTime += 15;
                }
                timeslots.Add(i, "Friday " + timeString);
            }

        }

        // GET: Application1
        public async Task<IActionResult> Index()
        {
            string userID = _userManger.GetUserId(User);
            if (userID == null)
            {
                return NotFound();
            }
            return View(await _context.Availability.Where(m => m.USERID == _userManger.GetUserId(User)).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SetSchedule(bool[] slots)
        {
            string userID = _userManger.GetUserId(User);
            for (int i = 0;i < slots.Length; i++)
            {
                string timeSlot = timeslots[i + 1];
                var a = await _context.Availability
                .FirstOrDefaultAsync(m => m.USERID == userID && m.AvailabilityString == timeSlot);
                a.Available = slots[i];
                _context.Availability.Update(a);
            }
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "removed!" });
        }

        [HttpPost]
        public async Task<IActionResult> GetSchedule(string userId)
        {
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "removed!" });
        }
    }
}
