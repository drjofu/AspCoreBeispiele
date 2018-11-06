using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DbBeispiel.Models;

namespace DbBeispiel.Pages.DB.Continents
{
    public class CreateModel : PageModel
    {
        private readonly DbBeispiel.Models.MondialCore2Context _context;

        public CreateModel(DbBeispiel.Models.MondialCore2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Continent Continent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Continents.Add(Continent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}