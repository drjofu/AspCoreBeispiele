using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbBeispiel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DbBeispiel.Pages
{
  // https://www.c-sharpcorner.com/article/claim-based-and-policy-based-authorization-with-asp-net-core-2-1/

  [Authorize(Policy = MyPolicyNames.DerDarfDas)]
  public class IndexModel : PageModel
  {
    private readonly MondialCore2Context mondialCore2Context;

    public IndexModel(MondialCore2Context mondialCore2Context)
    {
      this.mondialCore2Context = mondialCore2Context;
    }

    public List<Continent> Continents { get; private set; }

    public void OnGet()
    {
      this.Continents = mondialCore2Context.Continents.ToList();
      var t = this.User.FindFirst("dings");

      HttpContext.Session.SetInt32("x", 42);
    }
  }
}
