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
    public class ReserveringMenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReserveringMenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReserveringMenus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReserveringMenu.Include(r => r.Menu).Include(r => r.Reservering);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReserveringMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringMenu = await _context.ReserveringMenu
                .Include(r => r.Menu)
                .Include(r => r.Reservering)
                .FirstOrDefaultAsync(m => m.ReserveringId == id);
            if (reserveringMenu == null)
            {
                return NotFound();
            }

            return View(reserveringMenu);
        }

        // GET: ReserveringMenus/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id");
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id");
            return View();
        }

        // POST: ReserveringMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveringId,MenuId,Aantal")] ReserveringMenu reserveringMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserveringMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id", reserveringMenu.MenuId);
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id", reserveringMenu.ReserveringId);
            return View(reserveringMenu);
        }

        // GET: ReserveringMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringMenu = await _context.ReserveringMenu.FindAsync(id);
            if (reserveringMenu == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id", reserveringMenu.MenuId);
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id", reserveringMenu.ReserveringId);
            return View(reserveringMenu);
        }

        // POST: ReserveringMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveringId,MenuId,Aantal")] ReserveringMenu reserveringMenu)
        {
            if (id != reserveringMenu.ReserveringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserveringMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringMenuExists(reserveringMenu.ReserveringId))
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
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id", reserveringMenu.MenuId);
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id", reserveringMenu.ReserveringId);
            return View(reserveringMenu);
        }

        // GET: ReserveringMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringMenu = await _context.ReserveringMenu
                .Include(r => r.Menu)
                .Include(r => r.Reservering)
                .FirstOrDefaultAsync(m => m.ReserveringId == id);
            if (reserveringMenu == null)
            {
                return NotFound();
            }

            return View(reserveringMenu);
        }

        // POST: ReserveringMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserveringMenu = await _context.ReserveringMenu.FindAsync(id);
            _context.ReserveringMenu.Remove(reserveringMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveringMenuExists(int id)
        {
            return _context.ReserveringMenu.Any(e => e.ReserveringId == id);
        }
    }
}
