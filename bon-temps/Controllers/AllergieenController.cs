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
    public class AllergieenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllergieenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Allergieen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Allergie.ToListAsync());
        }

        // GET: Allergieen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergie = await _context.Allergie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergie == null)
            {
                return NotFound();
            }

            return View(allergie);
        }

        // GET: Allergieen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allergieen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Allergeen")] Allergie allergie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergie);
        }

        // GET: Allergieen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergie = await _context.Allergie.FindAsync(id);
            if (allergie == null)
            {
                return NotFound();
            }
            return View(allergie);
        }

        // POST: Allergieen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Allergeen")] Allergie allergie)
        {
            if (id != allergie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergieExists(allergie.Id))
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
            return View(allergie);
        }

        // GET: Allergieen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergie = await _context.Allergie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergie == null)
            {
                return NotFound();
            }

            return View(allergie);
        }

        // POST: Allergieen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergie = await _context.Allergie.FindAsync(id);
            _context.Allergie.Remove(allergie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergieExists(int id)
        {
            return _context.Allergie.Any(e => e.Id == id);
        }
    }
}
