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
    public class IndexModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public IndexModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        public IList<Teilnehmer> Teilnehmer { get;set; }

        public async Task OnGetAsync()
        {
            Teilnehmer = await _context.Teilnehmer.ToListAsync();
        }
    }
}
