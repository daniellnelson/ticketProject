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
    public class assigneesController : Controller
    {
        private readonly ticketsContext _context;

        public assigneesController(ticketsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Validate(assignee admin)
        {
            var _admin = _context.assignee.Where(s => s.username == admin.username);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.password == admin.password).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid username!" });
            }
        }
        // GET: assignees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.assignee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // GET: assignees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: assignees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,fullName,username,password,isActive,hireDate,terminationDate")] assignee assignee)
        {
            if (assignee.terminationDate == null)
            {
                assignee.terminationDate = DateTime.MaxValue;
            }
            if(assignee.isActive == 0)
            {
                assignee.isActive = 1;
            }
            if (ModelState.IsValid)
            {
                _context.Add(assignee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignee);
        }

        // GET: assignees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.assignee.FindAsync(id);
            if (assignee == null)
            {
                return NotFound();
            }
            return View(assignee);
        }

        // POST: assignees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,fullName,username,password,isActive,hireDate,terminationDate")] assignee assignee)
        {
            if (id != assignee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!assigneeExists(assignee.Id))
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
            return View(assignee);
        }

        // GET: assignees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.assignee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // POST: assignees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignee = await _context.assignee.FindAsync(id);
            _context.assignee.Remove(assignee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool assigneeExists(int id)
        {
            return _context.assignee.Any(e => e.Id == id);
        }
    }
}
