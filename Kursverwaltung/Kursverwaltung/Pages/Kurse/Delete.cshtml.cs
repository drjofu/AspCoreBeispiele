using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Kurse
{
    public class DeleteModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DeleteModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kurs Kurs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kurs = await _context.Kurs.FirstOrDefaultAsync(m => m.Id == id);

            if (Kurs == null)
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

            Kurs = await _context.Kurs.FindAsync(id);

            if (Kurs != null)
            {
                _context.Kurs.Remove(Kurs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
