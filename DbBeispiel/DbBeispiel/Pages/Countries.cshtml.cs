using DbBeispiel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DbBeispiel.Pages
{
  public class CountriesModel : PageModel
  {
    private readonly MondialCore2Context mondial;
    public IEnumerable<Country> Countries { get; set; }

    public CountriesModel(MondialCore2Context mondial)
    {
      this.mondial = mondial;
    }

    public void OnGet(int continentId)
    {
      this.Countries = this.mondial.Countries.Where(c => c.ContinentId == continentId).ToList();
      int x = HttpContext.Session.GetInt32("x")??0;
    }
  }
}