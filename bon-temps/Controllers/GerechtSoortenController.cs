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
    public class GerechtSoortenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtSoortenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerechtSoorten
        public async Task<IActionResult> Index()
        {
            return View(await _context.GerechtSoort.ToListAsync());
        }

        // GET: GerechtSoorten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoort = await _context.GerechtSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechtSoort == null)
            {
                return NotFound();
            }

            return View(gerechtSoort);
        }

        // GET: GerechtSoorten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GerechtSoorten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort")] GerechtSoort gerechtSoort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechtSoort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerechtSoort);
        }

        // GET: GerechtSoorten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoort = await _context.GerechtSoort.FindAsync(id);
            if (gerechtSoort == null)
            {
                return NotFound();
            }
            return View(gerechtSoort);
        }

        // POST: GerechtSoorten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort")] GerechtSoort gerechtSoort)
        {
            if (id != gerechtSoort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechtSoort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtSoortExists(gerechtSoort.Id))
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
            return View(gerechtSoort);
        }

        // GET: GerechtSoorten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtSoort = await _context.GerechtSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechtSoort == null)
            {
                return NotFound();
            }

            return View(gerechtSoort);
        }

        // POST: GerechtSoorten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechtSoort = await _context.GerechtSoort.FindAsync(id);
            _context.GerechtSoort.Remove(gerechtSoort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtSoortExists(int id)
        {
            return _context.GerechtSoort.Any(e => e.Id == id);
        }
    }
}
