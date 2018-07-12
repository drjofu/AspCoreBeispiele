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
    public class DetailsModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public DetailsModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

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
    }
}
