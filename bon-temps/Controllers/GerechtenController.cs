using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bon_temps.Data;
using bon_temps.Models;
using System.Diagnostics;

namespace bon_temps.Controllers
{
    public class GerechtenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gerechten
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gerecht.Include(g => g.GerechtSoort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gerechten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerecht
                .Include(g => g.GerechtSoort)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["Ingredienten"] = new SelectList(_context.Ingredient, "Id", "Naam");

            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // GET: Gerechten/Create
        public IActionResult Create()
        {
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoort, "Id", "Soort");
            return View();
        }

        // POST: Gerechten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soort,Naam")] Gerecht gerecht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerecht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoort, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerecht.FindAsync(id);
            if (gerecht == null)
            {
                return NotFound();
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoort, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // POST: Gerechten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soort,Naam")] Gerecht gerecht)
        {
            if (id != gerecht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerecht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtExists(gerecht.Id))
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
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoort, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerecht
                .Include(g => g.GerechtSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // POST: Gerechten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerecht = await _context.Gerecht.FindAsync(id);
            _context.Gerecht.Remove(gerecht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IngredientToevoegen(int gerechtId, int ingredientId, int aantal)
        {
            var ge = new GerechtIngredient {
                GerechtId = gerechtId,
                IngredientId = ingredientId, 
                Aantal = aantal };

            _context.GerechtIngredient.Add(ge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = gerechtId });
        }


        private bool GerechtExists(int id)
        {
            return _context.Gerecht.Any(e => e.Id == id);
        }
        public ActionResult Ingredient()
        {
            return PartialView();
        }
    }
}
