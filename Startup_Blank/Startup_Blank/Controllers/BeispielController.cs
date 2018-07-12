using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Startup_Blank.Models;

namespace Startup_Blank.Controllers
{
  public class BeispielController : Controller
  {
    public IActionResult Index(int? id)
    {
      var kurs = Kurs.GetKurse().FirstOrDefault(k => k.Id == id);
      if (kurs == null) return NotFound($"Kurs mit id {id} nicht gefunden");
      return View(kurs);
    }

    public ActionResult<IEnumerable<Kurs>> Kurse()
    {
      return View( Kurs.GetKurse());
    }


  }
}