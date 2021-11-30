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
    public class IngredientenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingredienten
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ingredient.Include(i => i.Allergie).Include(i => i.Vegetarisch);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ingredienten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .Include(i => i.Allergie)
                .Include(i => i.Vegetarisch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredienten/Create
        public IActionResult Create()
        {
            ViewData["AllergieId"] = new SelectList(_context.Allergie, "Id", "Allergeen");
            ViewData["VegetarischId"] = new SelectList(_context.Vegetarisch, "Id", "Soort");
            return View();
        }

        // POST: Ingredienten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Eenheid,Soort,Allergeen")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergie, "Id", "Allergeen", ingredient.AllergieId);
            ViewData["VegetarischId"] = new SelectList(_context.Vegetarisch, "Id", "Soort", ingredient.VegetarischId);
            return View(ingredient);
        }

        // GET: Ingredienten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergie, "Id", "Allergeen", ingredient.AllergieId);
            ViewData["VegetarischId"] = new SelectList(_context.Vegetarisch, "Id", "Soort", ingredient.VegetarischId);
            return View(ingredient);
        }

        // POST: Ingredienten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Eenheid,Soort,Allergeen")] Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.Id))
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
            ViewData["AllergieId"] = new SelectList(_context.Allergie, "Id", "Allergeen", ingredient.AllergieId);
            ViewData["VegetarischId"] = new SelectList(_context.Vegetarisch, "Id", "Soort", ingredient.VegetarischId);
            return View(ingredient);
        }

        // GET: Ingredienten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .Include(i => i.Allergie)
                .Include(i => i.Vegetarisch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredienten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.Id == id);
        }
    }
}
