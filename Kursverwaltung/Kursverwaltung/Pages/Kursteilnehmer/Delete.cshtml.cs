using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Kursteilnehmer
{
    public class DeleteModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DeleteModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teilnehmer Teilnehmer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teilnehmer = await _context.Teilnehmer.FirstOrDefaultAsync(m => m.Id == id);

            if (Teilnehmer == null)
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

            Teilnehmer = await _context.Teilnehmer.FindAsync(id);

            if (Teilnehmer != null)
            {
                _context.Teilnehmer.Remove(Teilnehmer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
