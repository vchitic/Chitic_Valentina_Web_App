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

namespace Chitic_Valentina_Web_App.Pages.WaterPeriods
{
    public class EditModel : PageModel
    {
        private readonly Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext _context;

        public EditModel(Chitic_Valentina_Web_App.Data.Chitic_Valentina_Web_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Watering Watering { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Watering = await _context.Watering.FirstOrDefaultAsync(m => m.ID == id);

            if (Watering == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Watering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WateringExists(Watering.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WateringExists(int id)
        {
            return _context.Watering.Any(e => e.ID == id);
        }
    }
}
