using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbBeispiel.Models;

namespace DbBeispiel.Pages.DB.Continents
{
    public class DeleteModel : PageModel
    {
        private readonly DbBeispiel.Models.MondialCore2Context _context;

        public DeleteModel(DbBeispiel.Models.MondialCore2Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Continent = await _context.Continents.FindAsync(id);

            if (Continent != null)
            {
                _context.Continents.Remove(Continent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
