using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Startup_Blank.Models;

namespace Startup_Blank.Pages
{
  public class KurslisteModel : PageModel
  {
    public IEnumerable<Kurs> Kurse { get; set; }

    public void OnGet()
    {
      Kurse = Kurs.GetKurse();
    }
  }
}