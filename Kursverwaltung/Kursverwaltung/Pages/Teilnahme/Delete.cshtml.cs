using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Teilnahme
{
    public class DeleteModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DeleteModel(Kursverwaltung.Models.KursverwaltungContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeilnehmerTermin = await _context.TeilnehmerTermin.FindAsync(id);

            if (TeilnehmerTermin != null)
            {
                _context.TeilnehmerTermin.Remove(TeilnehmerTermin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
