using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Teilnahme
{
    public class EditModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public EditModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeilnehmerTermin TeilnehmerTermin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeilnehmerTermin = await _context.TeilnehmerTermin
                .Include(t => t.Teilnehmer)
                .Include(t => t.Termin).FirstOrDefaultAsync(m => m.TeilnehmerId == id);

            if (TeilnehmerTermin == null)
            {
                return NotFound();
            }
           ViewData["TeilnehmerId"] = new SelectList(_context.Teilnehmer, "Id", "Id");
           ViewData["TerminId"] = new SelectList(_context.Termin, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeilnehmerTermin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeilnehmerTerminExists(TeilnehmerTermin.TeilnehmerId))
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

        private bool TeilnehmerTerminExists(int id)
        {
            return _context.TeilnehmerTermin.Any(e => e.TeilnehmerId == id);
        }
    }
}
