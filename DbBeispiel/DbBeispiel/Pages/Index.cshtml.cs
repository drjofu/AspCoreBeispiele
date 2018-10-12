using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbBeispiel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DbBeispiel.Pages
{
  public class IndexModel : PageModel
  {
    private readonly MondialCore2Context mondialCore2Context;

    public IndexModel(MondialCore2Context mondialCore2Context)
    {
      this.mondialCore2Context = mondialCore2Context;
    }

    public List<Continents> Continents { get; private set; }

    public void OnGet()
    {
      this.Continents = mondialCore2Context.Continents.ToList();
    }
  }
}
