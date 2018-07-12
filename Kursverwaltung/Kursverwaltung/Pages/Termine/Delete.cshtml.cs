using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Termine
{
    public class DeleteModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DeleteModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Termin Termin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Termin = await _context.Termin
                .Include(t => t.Kurs).FirstOrDefaultAsync(m => m.Id == id);

            if (Termin == null)
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

            Termin = await _context.Termin.FindAsync(id);

            if (Termin != null)
            {
                _context.Termin.Remove(Termin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
