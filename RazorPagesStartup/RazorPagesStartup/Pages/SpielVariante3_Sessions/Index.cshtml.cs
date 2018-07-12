using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStartup.Models;

namespace RazorPagesStartup.Pages.SpielVariante3_Sessions
{
  public class IndexModel : PageModel
  {
    private readonly WWM_SpielLogik.Spielverwaltung spielverwaltung;
    public WWM_SpielLogik.Aufgabe Aufgabe;

    [TempData]
    public string Meldung { get; set; } = "";


    public IndexModel(WWM_SpielLogik.Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnGet()
    {
      int? aufgabeId = HttpContext.Session.GetInt32("AufgabeId");
      if (aufgabeId.HasValue)
        Aufgabe = spielverwaltung.GetAufgabeMitId(aufgabeId.Value);
      else
      {
        var schwierigkeitsgrad = HttpContext.Session.GetInt32("Schwierigkeitsgrad");
        Aufgabe = spielverwaltung.GetAufgabeFürSchwierigkeitsgrad(schwierigkeitsgrad.GetValueOrDefault());
        HttpContext.Session.SetInt32("AufgabeId", Aufgabe.Id);
      }
    }
  }
}
