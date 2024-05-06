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
    public class AlumniController : Controller
    {
        private readonly MhsaluminiContext _context;

        public AlumniController(MhsaluminiContext context)
        {
            _context = context;
        }

        // GET: Alumni
        public async Task<IActionResult> Index()
        {
            var mhsaluminiContext = _context.Alumni.Include(a => a.Membership).Include(a => a.Organization);
            return View(await mhsaluminiContext.ToListAsync());
        }

        // GET: Alumni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumni == null)
            {
                return NotFound();
            }

            var alumnus = await _context.Alumni
                .Include(a => a.Membership)
                .Include(a => a.Organization)
                .FirstOrDefaultAsync(m => m.AlumniId == id);
            if (alumnus == null)
            {
                return NotFound();
            }

            return View(alumnus);
        }

        // GET: Alumni/Create
        public IActionResult Create()
        {
            ViewData["MembershipId"] = new SelectList(_context.Memberships, "MembershipId", "MembershipId");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId");
            return View();
        }

        // POST: Alumni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumniId,FirstName,LastName,MaidenName,HomePhonenumber,WorkPhonenumber,CellPhoneNumber,Email,DateOfBirth,Gender,Street,City,State,Zip,GraduationYear,Organizations,Occupation,MaritalStatus,Password,MembershipId,OrganizationId")] Alumnus alumnus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipId"] = new SelectList(_context.Memberships, "MembershipId", "MembershipId", alumnus.MembershipId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", alumnus.OrganizationId);
            return View(alumnus);
        }

        // GET: Alumni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumni == null)
            {
                return NotFound();
            }

            var alumnus = await _context.Alumni.FindAsync(id);
            if (alumnus == null)
            {
                return NotFound();
            }
            ViewData["MembershipId"] = new SelectList(_context.Memberships, "MembershipId", "MembershipId", alumnus.MembershipId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", alumnus.OrganizationId);
            return View(alumnus);
        }

        // POST: Alumni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlumniId,FirstName,LastName,MaidenName,HomePhonenumber,WorkPhonenumber,CellPhoneNumber,Email,DateOfBirth,Gender,Street,City,State,Zip,GraduationYear,Organizations,Occupation,MaritalStatus,Password,MembershipId,OrganizationId")] Alumnus alumnus)
        {
            if (id != alumnus.AlumniId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnusExists(alumnus.AlumniId))
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
            ViewData["MembershipId"] = new SelectList(_context.Memberships, "MembershipId", "MembershipId", alumnus.MembershipId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", alumnus.OrganizationId);
            return View(alumnus);
        }

        // GET: Alumni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumni == null)
            {
                return NotFound();
            }

            var alumnus = await _context.Alumni
                .Include(a => a.Membership)
                .Include(a => a.Organization)
                .FirstOrDefaultAsync(m => m.AlumniId == id);
            if (alumnus == null)
            {
                return NotFound();
            }

            return View(alumnus);
        }

        // POST: Alumni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumni == null)
            {
                return Problem("Entity set 'MhsaluminiContext.Alumni'  is null.");
            }
            var alumnus = await _context.Alumni.FindAsync(id);
            if (alumnus != null)
            {
                _context.Alumni.Remove(alumnus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnusExists(int id)
        {
          return (_context.Alumni?.Any(e => e.AlumniId == id)).GetValueOrDefault();
        }
    }
}
