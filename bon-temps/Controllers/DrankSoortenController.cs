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
    public class DrankSoortenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrankSoortenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DrankSoorten
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrankSoort.ToListAsync());
        }

        // GET: DrankSoorten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankSoort = await _context.DrankSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drankSoort == null)
            {
                return NotFound();
            }

            return View(drankSoort);
        }

        // GET: DrankSoorten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrankSoorten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort")] DrankSoort drankSoort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drankSoort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drankSoort);
        }

        // GET: DrankSoorten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankSoort = await _context.DrankSoort.FindAsync(id);
            if (drankSoort == null)
            {
                return NotFound();
            }
            return View(drankSoort);
        }

        // POST: DrankSoorten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort")] DrankSoort drankSoort)
        {
            if (id != drankSoort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drankSoort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankSoortExists(drankSoort.Id))
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
            return View(drankSoort);
        }

        // GET: DrankSoorten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankSoort = await _context.DrankSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drankSoort == null)
            {
                return NotFound();
            }

            return View(drankSoort);
        }

        // POST: DrankSoorten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankSoort = await _context.DrankSoort.FindAsync(id);
            _context.DrankSoort.Remove(drankSoort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankSoortExists(int id)
        {
            return _context.DrankSoort.Any(e => e.Id == id);
        }
    }
}
