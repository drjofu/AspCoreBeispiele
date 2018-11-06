using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbBeispiel.Models;

namespace DbBeispiel.Pages.DB.Continents
{
    public class IndexModel : PageModel
    {
        private readonly DbBeispiel.Models.MondialCore2Context _context;

        public IndexModel(DbBeispiel.Models.MondialCore2Context context)
        {
            _context = context;
        }

        public IList<Continent> Continent { get;set; }

        public async Task OnGetAsync()
        {
            Continent = await _context.Continents.ToListAsync();
        }
    }
}
