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
    public class IndexModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public IndexModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        public IList<TeilnehmerTermin> TeilnehmerTermin { get;set; }

        public async Task OnGetAsync()
        {
            TeilnehmerTermin = await _context.TeilnehmerTermin
                .Include(t => t.Teilnehmer)
                .Include(t => t.Termin).ToListAsync();
        }
    }
}
