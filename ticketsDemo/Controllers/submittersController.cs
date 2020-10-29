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
    public class submittersController : Controller
    {
        private readonly ticketsContext _context;

        public submittersController(ticketsContext context)
        {
            _context = context;
        }

        // GET: submitters
        public async Task<IActionResult> Index()
        {
            return View(await _context.submitter_1.ToListAsync());
        }

        // GET: submitters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.submitter_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submitter == null)
            {
                return NotFound();
            }

            return View(submitter);
        }

        // GET: submitters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: submitters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,fullName")] submitter submitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submitter);
                await _context.SaveChangesAsync();
                return RedirectToAction("userCreate", "tickets", new { area = "" });
            }
            return View();
        }

        // GET: submitters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.submitter_1.FindAsync(id);
            if (submitter == null)
            {
                return NotFound();
            }
            return View(submitter);
        }

        // POST: submitters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,fullName")] submitter submitter)
        {
            if (id != submitter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!submitterExists(submitter.Id))
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
            return View(submitter);
        }

        // GET: submitters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitter = await _context.submitter_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submitter == null)
            {
                return NotFound();
            }

            return View(submitter);
        }

        // POST: submitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submitter = await _context.submitter_1.FindAsync(id);
            _context.submitter_1.Remove(submitter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool submitterExists(int id)
        {
            return _context.submitter_1.Any(e => e.Id == id);
        }
    }
}
