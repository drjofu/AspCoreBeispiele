using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Kurse
{
    public class EditModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public EditModel(Kursverwaltung.Models.KursverwaltungContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KursExists(Kurs.Id))
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

        private bool KursExists(int id)
        {
            return _context.Kurs.Any(e => e.Id == id);
        }
    }
}
