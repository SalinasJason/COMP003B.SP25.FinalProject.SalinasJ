using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.SalinasJ.Data;
using COMP003B.SP25.FinalProject.SalinasJ.Models;

namespace COMP003B.SP25.FinalProject.SalinasJ.Controllers
{
    public class SpecialGuestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialGuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpecialGuests
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialGuests.ToListAsync());
        }

        // GET: SpecialGuests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialGuest = await _context.SpecialGuests
                .FirstOrDefaultAsync(m => m.SpecialGuestId == id);
            if (specialGuest == null)
            {
                return NotFound();
            }

            return View(specialGuest);
        }

        // GET: SpecialGuests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialGuests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialGuestId,Name,Email,PhoneNumber,Bio")] SpecialGuest specialGuest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialGuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialGuest);
        }

        // GET: SpecialGuests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialGuest = await _context.SpecialGuests.FindAsync(id);
            if (specialGuest == null)
            {
                return NotFound();
            }
            return View(specialGuest);
        }

        // POST: SpecialGuests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialGuestId,Name,Email,PhoneNumber,Bio")] SpecialGuest specialGuest)
        {
            if (id != specialGuest.SpecialGuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialGuest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialGuestExists(specialGuest.SpecialGuestId))
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
            return View(specialGuest);
        }

        // GET: SpecialGuests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialGuest = await _context.SpecialGuests
                .FirstOrDefaultAsync(m => m.SpecialGuestId == id);
            if (specialGuest == null)
            {
                return NotFound();
            }

            return View(specialGuest);
        }

        // POST: SpecialGuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialGuest = await _context.SpecialGuests.FindAsync(id);
            if (specialGuest != null)
            {
                _context.SpecialGuests.Remove(specialGuest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialGuestExists(int id)
        {
            return _context.SpecialGuests.Any(e => e.SpecialGuestId == id);
        }
    }
}
