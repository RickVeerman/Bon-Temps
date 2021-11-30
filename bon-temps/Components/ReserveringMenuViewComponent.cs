using bon_temps.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bon_temps.Components
{
    public class ReserveringMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ReserveringMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var menus = await _context.ReserveringMenu
                .Include(i => i.Menu)
                .ThenInclude(i => i.MenuSoort)
                .Where(i => i.ReserveringId == id)
                .ToListAsync();

            return View(menus);
        }
    }
}
