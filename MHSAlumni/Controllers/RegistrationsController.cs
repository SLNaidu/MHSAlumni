using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MHSAlumni.DAL;
using MHSAlumni.Models;

namespace MHSAlumni.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly MhsaluminiContext _context;

        public RegistrationsController(MhsaluminiContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var mhsaluminiContext = _context.Registrations.Include(r => r.Alumni).Include(r => r.Event);
            return View(await mhsaluminiContext.ToListAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Alumni)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["AlumniId"] = new SelectList(_context.Alumni, "AlumniId", "AlumniId");
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationId,RegistrationInfo,EventId,AlumniId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumniId"] = new SelectList(_context.Alumni, "AlumniId", "AlumniId", registration.AlumniId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", registration.EventId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["AlumniId"] = new SelectList(_context.Alumni, "AlumniId", "AlumniId", registration.AlumniId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", registration.EventId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationId,RegistrationInfo,EventId,AlumniId")] Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegistrationId))
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
            ViewData["AlumniId"] = new SelectList(_context.Alumni, "AlumniId", "AlumniId", registration.AlumniId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", registration.EventId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Alumni)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registrations == null)
            {
                return Problem("Entity set 'MhsaluminiContext.Registrations'  is null.");
            }
            var registration = await _context.Registrations.FindAsync(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
          return (_context.Registrations?.Any(e => e.RegistrationId == id)).GetValueOrDefault();
        }
    }
}
