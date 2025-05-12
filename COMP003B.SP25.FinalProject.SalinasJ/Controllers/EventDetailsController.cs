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
    public class EventDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventDetails.Include(e => e.Events).Include(e => e.Organizer).Include(e => e.SpecialGuest).Include(e => e.Venue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetails
                .Include(e => e.Events)
                .Include(e => e.Organizer)
                .Include(e => e.SpecialGuest)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Date");
            ViewData["OrganizerId"] = new SelectList(_context.Organizers, "OrganizerId", "Email");
            ViewData["SpecialGuestId"] = new SelectList(_context.SpecialGuests, "SpecialGuestId", "Bio");
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,OrganizerId,VenueId,SpecialGuestId")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Date", eventDetail.EventId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizers, "OrganizerId", "Email", eventDetail.OrganizerId);
            ViewData["SpecialGuestId"] = new SelectList(_context.SpecialGuests, "SpecialGuestId", "Bio", eventDetail.SpecialGuestId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", eventDetail.VenueId);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetails.FindAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Date", eventDetail.EventId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizers, "OrganizerId", "Email", eventDetail.OrganizerId);
            ViewData["SpecialGuestId"] = new SelectList(_context.SpecialGuests, "SpecialGuestId", "Bio", eventDetail.SpecialGuestId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", eventDetail.VenueId);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventId,OrganizerId,VenueId,SpecialGuestId")] EventDetail eventDetail)
        {
            if (id != eventDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventDetailExists(eventDetail.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Date", eventDetail.EventId);
            ViewData["OrganizerId"] = new SelectList(_context.Organizers, "OrganizerId", "Email", eventDetail.OrganizerId);
            ViewData["SpecialGuestId"] = new SelectList(_context.SpecialGuests, "SpecialGuestId", "Bio", eventDetail.SpecialGuestId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", eventDetail.VenueId);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetails
                .Include(e => e.Events)
                .Include(e => e.Organizer)
                .Include(e => e.SpecialGuest)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetail = await _context.EventDetails.FindAsync(id);
            if (eventDetail != null)
            {
                _context.EventDetails.Remove(eventDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventDetailExists(int id)
        {
            return _context.EventDetails.Any(e => e.Id == id);
        }
    }
}
