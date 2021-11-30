using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bon_temps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bon_temps.Components
{
    public class GerechtIngredientViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GerechtIngredientViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ingredienten = await _context.GerechtIngredient
                .Include(i => i.Ingredient)
                .Where(i => i.GerechtId == id)
                .ToListAsync();

            return View(ingredienten);
        }
    }
}


