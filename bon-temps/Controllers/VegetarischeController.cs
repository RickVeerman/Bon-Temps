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
    public class VegetarischeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VegetarischeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vegetarische
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vegetarisch.ToListAsync());
        }

        // GET: Vegetarische/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetarisch = await _context.Vegetarisch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegetarisch == null)
            {
                return NotFound();
            }

            return View(vegetarisch);
        }

        // GET: Vegetarische/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vegetarische/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort")] Vegetarisch vegetarisch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vegetarisch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vegetarisch);
        }

        // GET: Vegetarische/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetarisch = await _context.Vegetarisch.FindAsync(id);
            if (vegetarisch == null)
            {
                return NotFound();
            }
            return View(vegetarisch);
        }

        // POST: Vegetarische/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort")] Vegetarisch vegetarisch)
        {
            if (id != vegetarisch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vegetarisch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VegetarischExists(vegetarisch.Id))
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
            return View(vegetarisch);
        }

        // GET: Vegetarische/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vegetarisch = await _context.Vegetarisch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vegetarisch == null)
            {
                return NotFound();
            }

            return View(vegetarisch);
        }

        // POST: Vegetarische/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vegetarisch = await _context.Vegetarisch.FindAsync(id);
            _context.Vegetarisch.Remove(vegetarisch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VegetarischExists(int id)
        {
            return _context.Vegetarisch.Any(e => e.Id == id);
        }
    }
}
