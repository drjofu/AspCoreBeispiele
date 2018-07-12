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
    public class DetailsModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DetailsModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

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
    }
}
