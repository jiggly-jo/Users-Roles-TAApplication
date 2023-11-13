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
    public class Application1Controller : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<TAUser> _userManger;
        public Application1Controller(ApplicationContext context, UserManager<TAUser> userManager)
        {
            _userManger = userManager;
            _context = context;
        }

        // GET: Application1
        public async Task<IActionResult> Index()
        {
            List<Availability> l =  await _context.Availability.Where(m => m.USERID == _userManger.GetUserId(User)).ToListAsync();

            ViewData["Schedule"] = l;
            return View(await _context.Application1.ToListAsync());
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Application1.ToListAsync());
        }

        // GET: Application1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application1 = await _context.Application1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application1 == null)
            {
                return NotFound();
            }

            return View(application1);
        }

        // GET: Application1/Create
        public IActionResult Create()
        {
            ViewData["applications"] = _context.Application1.ToList();
            return View();
        }

        // POST: Application1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,PhoneNumber,Address,Degree,Program,GPA,Hours,PersonalStatement,EnglishFluency1,SemestersCompleted,LinkedIn,ApplicationDate,ModificationDate")] Application1 application1)
        {
            if (ModelState.IsValid)
            {
                application1.USERID = _userManger.GetUserId(User);
                _context.Add(application1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application1);
        }

        // GET: Application1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application1 = await _context.Application1.FindAsync(id);
            if (application1 == null)
            {
                return NotFound();
            }
            return View(application1);
        }

        // POST: Application1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,PhoneNumber,Address,Degree,Program,GPA,Hours,PersonalStatement,EnglishFluency1,SemestersCompleted,LinkedIn,ApplicationDate,ModificationDate,USERID")] Application1 application1)
        {
            if (id != application1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Application1Exists(application1.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(application1);
        }

        // GET: Application1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application1 = await _context.Application1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application1 == null)
            {
                return NotFound();
            }

            return View(application1);
        }

        // POST: Application1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var application1 = await _context.Application1.FindAsync(id);
            _context.Application1.Remove(application1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Application1Exists(string id)
        {
            return _context.Application1.Any(e => e.ID == id);
        }

    }
}
