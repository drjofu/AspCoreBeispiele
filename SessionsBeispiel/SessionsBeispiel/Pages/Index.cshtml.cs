using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionsBeispiel.Utilities;

namespace SessionsBeispiel.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public string Name { get; set; }

    public DateTime? Startzeit { get; set; }

    public void OnGet()
    {
      Name = HttpContext.Session.GetString("name");
      Startzeit = HttpContext.Session.Get<DateTime?>("startzeit");
      if (Startzeit == null)
      {
        Startzeit = DateTime.Now;
        HttpContext.Session.Set("startzeit", Startzeit);
      }
    }

    public ActionResult OnPost()
    {
      HttpContext.Session.SetString("name", Name);
      return RedirectToPage();
    }
  }
}
