using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chitic_Valentina_Web_App.Data;
using Chitic_Valentina_Web_App.Models;

namespace Chitic_Valentina_Web_App.Pages.Plants
{
    public class EditModel : PlantCategoriesModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public EditModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
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

            if (Plant == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Plant);

            ViewData["WeatherID"] = new SelectList(_context.Weather, "ID", "WeatherType");
            ViewData["WateringID"] = new SelectList(_context.Watering, "ID", "WateringPer");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plantToUpdate = await _context.Plant
            .Include(i => i.Weather)
            .Include(i => i.Watering)
            .Include(i => i.PlantCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (plantToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Plant>( plantToUpdate, "Plant",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.Weather, i => i.Watering))
            {
                UpdatePlantCategories(_context, selectedCategories, plantToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdatePlantCategories(_context, selectedCategories, plantToUpdate);
            PopulateAssignedCategoryData(_context, plantToUpdate);
            return Page();
        }
    }
}
