using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Chitic_Valentina_Web_App.Data;
using Chitic_Valentina_Web_App.Models;

namespace Chitic_Valentina_Web_App.Pages.WeatherTypes
{
    public class DetailsModel : PageModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public DetailsModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
        {
            _context = context;
        }

        public Weather Weather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FirstOrDefaultAsync(m => m.ID == id);

            if (Weather == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
