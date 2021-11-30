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
    public class GerechtIngredientenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtIngredientenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GerechtIngredienten
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GerechtIngredient.Include(g => g.Gerecht).Include(g => g.Ingredient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GerechtIngredienten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtIngredient = await _context.GerechtIngredient
                .Include(g => g.Gerecht)
                .Include(g => g.Ingredient)
                .FirstOrDefaultAsync(m => m.GerechtId == id);
            if (gerechtIngredient == null)
            {
                return NotFound();
            }

            return View(gerechtIngredient);
        }

        // GET: GerechtIngredienten/Create
        public IActionResult Create()
        {
            ViewData["GerechtId"] = new SelectList(_context.Gerecht, "Id", "Id");
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Id");
            return View();
        }

        // POST: GerechtIngredienten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GerechtId,IngredientId,Aantal")] GerechtIngredient gerechtIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechtIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtId"] = new SelectList(_context.Gerecht, "Id", "Id", gerechtIngredient.GerechtId);
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Id", gerechtIngredient.IngredientId);
            return View(gerechtIngredient);
        }

        // GET: GerechtIngredienten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtIngredient = await _context.GerechtIngredient.FindAsync(id);
            if (gerechtIngredient == null)
            {
                return NotFound();
            }
            ViewData["GerechtId"] = new SelectList(_context.Gerecht, "Id", "Id", gerechtIngredient.GerechtId);
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Id", gerechtIngredient.IngredientId);
            return View(gerechtIngredient);
        }

        // POST: GerechtIngredienten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GerechtId,IngredientId,Aantal")] GerechtIngredient gerechtIngredient)
        {
            if (id != gerechtIngredient.GerechtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechtIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtIngredientExists(gerechtIngredient.GerechtId))
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
            ViewData["GerechtId"] = new SelectList(_context.Gerecht, "Id", "Id", gerechtIngredient.GerechtId);
            ViewData["IngredientId"] = new SelectList(_context.Set<Ingredient>(), "Id", "Id", gerechtIngredient.IngredientId);
            return View(gerechtIngredient);
        }

        // GET: GerechtIngredienten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtIngredient = await _context.GerechtIngredient
                .Include(g => g.Gerecht)
                .Include(g => g.Ingredient)
                .FirstOrDefaultAsync(m => m.GerechtId == id);
            if (gerechtIngredient == null)
            {
                return NotFound();
            }

            return View(gerechtIngredient);
        }

        // POST: GerechtIngredienten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechtIngredient = await _context.GerechtIngredient.FindAsync(id);
            _context.GerechtIngredient.Remove(gerechtIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtIngredientExists(int id)
        {
            return _context.GerechtIngredient.Any(e => e.GerechtId == id);
        }
    }
}
