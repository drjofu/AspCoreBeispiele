using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbBeispiel.Models;

namespace DbBeispiel.Pages.DB.Continents
{
    public class EditModel : PageModel
    {
        private readonly DbBeispiel.Models.MondialCore2Context _context;

        public EditModel(DbBeispiel.Models.MondialCore2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Continent = await _context.Continents.FirstOrDefaultAsync(m => m.Id == id);

            if (Continent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Continent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentExists(Continent.Id))
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

        private bool ContinentExists(int id)
        {
            return _context.Continents.Any(e => e.Id == id);
        }
    }
}
