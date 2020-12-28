using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chitic_Valentina_Web_App.Data;
using Chitic_Valentina_Web_App.Models;

namespace Chitic_Valentina_Web_App.Pages.Plants
{
    public class IndexModel : PageModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public IndexModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
        {
            _context = context;
        }

        public IList<Plant> Plant { get;set; }

        public PlantData PlantD { get; set; }
        public int PlantID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PlantD = new PlantData();
            PlantD.Plants = await _context.Plant
            .Include(b => b.Weather)
            .Include(b => b.Watering)
            .Include(b => b.PlantCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                PlantID = id.Value;
                Plant plant = PlantD.Plants
                .Where(i => i.ID == id.Value).Single();
                PlantD.Categories = plant.PlantCategories.Select(s => s.Category);
            }
        }

    }
}
