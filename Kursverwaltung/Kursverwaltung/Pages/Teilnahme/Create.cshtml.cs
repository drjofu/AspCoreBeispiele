using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Teilnahme
{
    public class CreateModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public CreateModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeilnehmerId"] = new SelectList(_context.Teilnehmer, "Id", "Id");
        ViewData["TerminId"] = new SelectList(_context.Termin, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public TeilnehmerTermin TeilnehmerTermin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TeilnehmerTermin.Add(TeilnehmerTermin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}