using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bon_temps.Data;
using bon_temps.Models;

namespace bon_temps.Controllers
{
    public class DrankenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrankenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dranken
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Drank.Include(d => d.DrankSoort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dranken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drank = await _context.Drank
                .Include(d => d.DrankSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drank == null)
            {
                return NotFound();
            }

            return View(drank);
        }

        // GET: Dranken/Create
        public IActionResult Create()
        {
            ViewData["DrankSoortId"] = new SelectList(_context.DrankSoort, "Id", "Soort");
            return View();
        }

        // POST: Dranken/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort,Naam,Prijs")] Drank drank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrankSoortId"] = new SelectList(_context.DrankSoort, "Id", "Soort", drank.DrankSoortId);
            return View(drank);
        }

        // GET: Dranken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drank = await _context.Drank.FindAsync(id);
            if (drank == null)
            {
                return NotFound();
            }
            ViewData["DrankSoortId"] = new SelectList(_context.DrankSoort, "Id", "Soort", drank.DrankSoortId);
            return View(drank);
        }

        // POST: Dranken/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort,Naam,Prijs")] Drank drank)
        {
            if (id != drank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankExists(drank.Id))
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
            ViewData["DrankSoortId"] = new SelectList(_context.DrankSoort, "Id", "Soort", drank.DrankSoortId);
            return View(drank);
        }

        // GET: Dranken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drank = await _context.Drank
                .Include(d => d.DrankSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drank == null)
            {
                return NotFound();
            }

            return View(drank);
        }

        // POST: Dranken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drank = await _context.Drank.FindAsync(id);
            _context.Drank.Remove(drank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankExists(int id)
        {
            return _context.Drank.Any(e => e.Id == id);
        }
    }
}
