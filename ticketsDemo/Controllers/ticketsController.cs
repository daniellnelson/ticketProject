using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ticketsDemo.Data;
using ticketsDemo.Models;

namespace ticketsDemo.Controllers
{
    public class ticketsController : Controller
    {
        private readonly ticketsContext _context;

        public ticketsController(ticketsContext context)
        {
            _context = context;
        }

        // GET: tickets
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.priorityParam = String.IsNullOrEmpty(sortOrder) ? "prioritySort" : "";
            ViewBag.severityParam = String.IsNullOrEmpty(sortOrder) ? "severitySort" : "";
            ViewBag.submitParam = String.IsNullOrEmpty(sortOrder) ? "submitSort" : "";
            var ticketsContext = _context.tickets.Include(t => t.assignee).Include(t => t.status).Include(t => t.submitter).AsQueryable();
            switch (sortOrder)
            {
                case "prioritySort":
                    ticketsContext = ticketsContext.OrderByDescending(s => s.priority);
                    break;
                case "submitSort":
                    ticketsContext = ticketsContext.OrderByDescending(s => s.SubmittedDate);
                    break;
                case "severitySort":
                    ticketsContext = ticketsContext.OrderBy(s => s.severity);
                    break;
                default:
                    ticketsContext = ticketsContext.OrderBy(s => s.Id);
                    break;
            }
            return View(await ticketsContext.ToListAsync());
        }

        public async Task<IActionResult> userView(string sortOrder)
        {
            ViewBag.priorityParam = String.IsNullOrEmpty(sortOrder) ? "prioritySort" : "";
            ViewBag.severityParam = String.IsNullOrEmpty(sortOrder) ? "severitySort" : "";
            ViewBag.submitParam = String.IsNullOrEmpty(sortOrder) ? "submitSort" : "";
            var ticketsContext = _context.tickets.Include(t => t.assignee).Include(t => t.status).Include(t => t.submitter).AsQueryable();
            switch (sortOrder)
            {
                case "prioritySort":
                    ticketsContext = ticketsContext.OrderByDescending(s => s.priority);
                    break;
                case "submitSort":
                    ticketsContext = ticketsContext.OrderByDescending(s => s.SubmittedDate);
                    break;
                case "severitySort":
                    ticketsContext = ticketsContext.OrderBy(s => s.severity);
                    break;
                default:
                    ticketsContext = ticketsContext.OrderBy(s => s.Id);
                    break;
            }
            return View(await ticketsContext.ToListAsync());
        }


        public async Task<IActionResult> closedTickets()
        {
            var ticketsContext = _context.tickets.Include(t => t.assignee).Include(t => t.status).Include(t => t.submitter);
            return View(await ticketsContext.ToListAsync());
        }

        public async Task<IActionResult> userClosedtickets()
        {
            var ticketsContext = _context.tickets.Include(t => t.assignee).Include(t => t.status).Include(t => t.submitter);
            return View(await ticketsContext.ToListAsync());
        }


        // GET: tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.tickets
                .Include(t => t.assignee)
                .Include(t => t.status)
                .Include(t => t.submitter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }



        // GET: tickets/Create
        public IActionResult Create()
        {
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName");
            ViewData["statusId"] = new SelectList(_context.status, "id", "statusName");
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName");
            return View();
        }

        // POST: tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,SubmittedDate,ClosedDate,severity,priority,assigneeId,submitterId,description,statusId")] tickets tickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName", tickets.assigneeId);
            ViewData["statusId"] = new SelectList(_context.status, "id", "statusName", tickets.statusId);
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName", tickets.submitterId);
            return View(tickets);
        }

        // GET: tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName", tickets.assigneeId);
            ViewData["statusId"] = new SelectList(_context.status, "id", "statusName", tickets.statusId);
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName", tickets.submitterId);
            return View(tickets);
        }

        // POST: tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,SubmittedDate,ClosedDate,severity,priority,assigneeId,submitterId,description,statusId")] tickets tickets)
        {
            if (id != tickets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ticketsExists(tickets.Id))
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
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName", tickets.assigneeId);
            ViewData["statusId"] = new SelectList(_context.status, "id", "id", tickets.statusId);
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName", tickets.submitterId);
            return View(tickets);
        }

        // GET: tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.tickets
                .Include(t => t.assignee)
                .Include(t => t.status)
                .Include(t => t.submitter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tickets = await _context.tickets.FindAsync(id);
            _context.tickets.Remove(tickets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ticketsExists(int id)
        {
            return _context.tickets.Any(e => e.Id == id);
        }


        //User Creation Methods
        // GET: tickets/Create
        public IActionResult UserCreate()
        {
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName");
            return View();
        }

        // POST: tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate([Bind("Id,Title,SubmittedDate,ClosedDate,severity,priority,assigneeId,submitterId,description,statusId")] tickets tickets)
        {
            if (ModelState.IsValid)
            {
                if (tickets.assigneeId == 0)
                {
                    tickets.assigneeId = 1;
                }
                if (tickets.statusId == 0)
                {
                    tickets.statusId = 1;
                }
                if (tickets.priority == 0)
                {
                    tickets.priority = 4;//defaulting
                }
                if (tickets.ClosedDate == null)
                {
                    tickets.ClosedDate = DateTime.MaxValue;
                }
                _context.Add(tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(userView));
            }
            ViewData["submitterId"] = new SelectList(_context.submitter_1, "Id", "fullName", tickets.submitterId);
            return View(tickets);
        }

        // GET: tickets/E
    }
}
