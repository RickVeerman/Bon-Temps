using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bon_temps.Data;
using bon_temps.Models;
using Microsoft.AspNetCore.Identity;

namespace bon_temps.Controllers
{
    public class ReserveringenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReserveringenController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Reserveringen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservering.Include(r => r.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reserveringen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering
                .Include(r => r.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["Menus"] = new SelectList(_context.Menu, "Id", "Naam");
            return View(reservering);
        }

        // GET: Reserveringen/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Reserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Tijd,ApplicationUserId")] Reservering reservering)
        {
            if (ModelState.IsValid)
            {
                // Als de ApplicationUserId "0" is, dan de huidige gebruiken gebruiken...
                if (reservering.ApplicationUserId == "0")
                {
                    reservering.ApplicationUserId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
                }
                _context.Add(reservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = reservering.Id });
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", reservering.ApplicationUserId);
            return View(reservering);
        }

        // GET: Reserveringen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "HeleNaam", reservering.ApplicationUserId);
            return View(reservering);
        }

        // POST: Reserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Tijd,ApplicationUserId")] Reservering reservering)
        {
            if (id != reservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringExists(reservering.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", reservering.ApplicationUserId);
            return View(reservering);
        }

        // GET: Reserveringen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reservering
                .Include(r => r.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: Reserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.Reservering.FindAsync(id);
            _context.Reservering.Remove(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MenuToevoegen(int reserveringId, int menuId, int aantal)
        {
            var re = new ReserveringMenu
            {
                ReserveringId = reserveringId,
                MenuId = menuId,
                Aantal = aantal
            };

            

            ViewData["GerechtSoort"] = new SelectList(_context.GerechtSoort, "Id", "Soort");
            _context.ReserveringMenu.Add(re);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = reserveringId });
        }
        public async Task<IActionResult> EditMenu(int? id, int? menuId, int aantal)
        {
            if (id == null || menuId == null)
            {
                return NotFound();
            }

            var reservering = await _context.ReserveringMenu
                .Include(i => i.Menu)
                .Include(i => i.Reservering)
                .FirstOrDefaultAsync(m => m.ReserveringId == id);

            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Id", reservering.MenuId);
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id", reservering.ReserveringId);
 
            return View(reservering);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMenu(int id, int menuId, Reservering reservering)
        {
            if (id != reservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringExists(reservering.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = reservering.Id });
            }
            ViewData["ReserveringId"] = new SelectList(_context.Reservering, "Id", "Id", reservering.Id);
            return View(reservering);
        }

        private bool ReserveringExists(int id)
        {
            return _context.Reservering.Any(e => e.Id == id);
        }
    }
}
