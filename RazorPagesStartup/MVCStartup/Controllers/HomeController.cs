using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCStartup.Models;
using WWM_SpielLogik;

namespace MVCStartup.Controllers
{
  public class HomeController : Controller
  {
    private readonly Spielverwaltung spielverwaltung;

    public HomeController(Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    //public override void OnActionExecuting(ActionExecutingContext context)
    //{
    //  base.OnActionExecuting(context);
    //}

    public IActionResult Index()
    {
      int? aufgabeId = HttpContext.Session.GetInt32("AufgabeId");
      Aufgabe aufgabe;

      if (aufgabeId.HasValue)
        aufgabe = spielverwaltung.GetAufgabeMitId(aufgabeId.Value);
      else
      {
        var schwierigkeitsgrad = HttpContext.Session.GetInt32("Schwierigkeitsgrad");
        aufgabe = spielverwaltung.GetAufgabeFürSchwierigkeitsgrad(schwierigkeitsgrad.GetValueOrDefault());
        HttpContext.Session.SetInt32("AufgabeId", aufgabe.Id);
      }

      return View(new AufgabeViewModel() { Aufgabe = aufgabe });
    }

    [HttpPost]
    public IActionResult Check(string antwort)
    {
      var vm = new CheckViewModel();
      int? aufgabeId = HttpContext.Session.GetInt32("AufgabeId");
      if (aufgabeId == null)
      {
        vm.Meldung = "Session abgelaufen";
        vm.EsGehtWeiter = false;
        return View(vm);
      }

      var ergebnis = spielverwaltung.AntwortPrüfen(aufgabeId.Value, antwort);
      vm.Meldung = ergebnis.Meldung;
      vm.EsGehtWeiter = ergebnis.Schwierigkeitsgrad > 0;
      if (vm.EsGehtWeiter)
        HttpContext.Session.SetInt32("Schwierigkeitsgrad", ergebnis.Schwierigkeitsgrad);
      else
        HttpContext.Session.Remove("Schwierigkeitsgrad");

      HttpContext.Session.Remove("AufgabeId");

      return View(vm);
    }

    [HttpPost]
    public IActionResult Ende()
    {
      int? aufgabeId = HttpContext.Session.GetInt32("AufgabeId");
      if (aufgabeId == null)
      {
        return View((object)"Session abgelaufen");
      }

      return View((object)spielverwaltung.Aufgeben(aufgabeId.Value));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
