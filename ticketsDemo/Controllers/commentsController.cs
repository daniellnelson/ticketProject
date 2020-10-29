using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ticketsDemo.Data;
using ticketsDemo.Models;

namespace ticketsDemo.Controllers
{
    public class commentsController : Controller
    {
        private readonly ticketsContext _context;

        public commentsController(ticketsContext context)
        {
            _context = context;
        }

        // GET: comments
        public IActionResult Index(int? id)
        {
            var ticketsContext = _context.submitter.Include(c => c.assignee).Include(c => c.tickets).AsQueryable();
            ViewBag.urlID = id;
            if (id.ToString() == null || id == 0)
            {
                return View(ticketsContext);
            }
            ticketsContext = ticketsContext.Where(x => x.ticketID == id);
            return View(ticketsContext);
        }

        // GET: comments
        public IActionResult userComments(int? id)
        {
            var ticketsContext = _context.submitter.Include(c => c.assignee).Include(c => c.tickets).AsQueryable();
            ViewBag.urlID = id;
            if (id.ToString() == null || id == 0)
            {
                return View(ticketsContext);
            }
            ticketsContext = ticketsContext.Where(x => x.ticketID == id);
            return View(ticketsContext);
        }

        // GET: comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.submitter
                .Include(c => c.assignee)
                .Include(c => c.tickets)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // GET: comments/Create
        public IActionResult Create()
        {
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id");
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName");
            return View();
        }

        // POST: comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ticketID,commentDate,commentDescription,assigneeId")] comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "tickets");
            }
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName", comments.assigneeId);
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id", comments.ticketID);
            return View(comments);
        }

        public IActionResult userCreate()
        {
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id");
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName");
            return View();
        }

        // POST: comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> userCreate([Bind("id,ticketID,commentDate,commentDescription,assigneeId")] comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "tickets");
            }
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "fullName", comments.assigneeId);
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id", comments.ticketID);
            return View(comments);
        }

        // GET: comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.submitter.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "Id", comments.assigneeId);
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id", comments.ticketID);
            return View(comments);
        }

        // POST: comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ticketID,commentDate,commentDescription,assigneeId")] comments comments)
        {
            if (id != comments.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!commentsExists(comments.id))
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
            ViewData["assigneeId"] = new SelectList(_context.assignee, "Id", "Id", comments.assigneeId);
            ViewData["ticketID"] = new SelectList(_context.tickets, "Id", "Id", comments.ticketID);
            return View(comments);
        }

        // GET: comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.submitter
                .Include(c => c.assignee)
                .Include(c => c.tickets)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // POST: comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comments = await _context.submitter.FindAsync(id);
            _context.submitter.Remove(comments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool commentsExists(int id)
        {
            return _context.submitter.Any(e => e.id == id);
        }
    }
}
