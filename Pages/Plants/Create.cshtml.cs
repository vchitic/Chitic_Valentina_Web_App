using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chitic_Valentina_Web_App.Data;
using Chitic_Valentina_Web_App.Models;

namespace Chitic_Valentina_Web_App.Pages.Plants
{
    public class CreateModel : PlantCategoriesModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public CreateModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["WeatherID"] = new SelectList(_context.Weather, "ID", "WeatherType");
            ViewData["WateringID"] = new SelectList(_context.Watering, "ID", "WateringPer");


            var plant = new Plant();
            plant.PlantCategories = new List<PlantCategory>();

            PopulateAssignedCategoryData(_context, plant);
            
            return Page();
        }

        [BindProperty]
        public Plant Plant { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPlant = new Plant();
            if (selectedCategories != null)
            {
                newPlant.PlantCategories = new List<PlantCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PlantCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newPlant.PlantCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Plant>(newPlant, "Plant",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.WeatherID, i => i.WateringID))
            {
                _context.Plant.Add(newPlant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newPlant);
            return Page();
        }
    }
}
