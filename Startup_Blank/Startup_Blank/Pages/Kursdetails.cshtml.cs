using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Startup_Blank.Models;

namespace Startup_Blank.Pages
{
  public class KursdetailsModel : PageModel
  {
    public Kurs Kurs { get; set; }

    public IActionResult OnGet(int? id)
    {
      Kurs = Kurs.GetKurse().FirstOrDefault(k => k.Id == id);
      if (Kurs == null) return NotFound($"Kurs mit id {id} nicht gefunden");

      return Page();
    }
  }
}