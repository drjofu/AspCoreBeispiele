using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursverwaltung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kursverwaltung.Pages
{
  public class IndexModel : PageModel
  {
    private readonly KursverwaltungContext kursverwaltungContext;

    public IndexModel(KursverwaltungContext kursverwaltungContext)
    {
      this.kursverwaltungContext = kursverwaltungContext;
    }

    public IEnumerable<Kurs> Kurse { get; set; }

    public void OnGet()
    {
      Kurse = kursverwaltungContext.Kurs.Include(k=>k.Termine).ToList();
    }
  }
}
