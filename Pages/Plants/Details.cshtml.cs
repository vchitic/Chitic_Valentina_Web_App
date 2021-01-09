using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chitic_Valentina_Web_App.Data;
using Chitic_Valentina_Web_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chitic_Valentina_Web_App.Pages.Plants
{
    public class DetailsModel : PageModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public DetailsModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Plant Plant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plant = await _context.Plant
             .Include(b => b.Weather)
             .Include(b => b.Watering)
             .Include(b => b.PlantCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            //ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");


            if (Plant == null)
            {
                return NotFound();
            }
            return Page();

            
        }
    }
}
