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
  public class CheckModel : PageModel
  {
    private readonly WWM_SpielLogik.Spielverwaltung spielverwaltung;

    [TempData]
    public string Meldung { get; set; }
    public bool EsGehtWeiter { get; private set; }


    public CheckModel(WWM_SpielLogik.Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnPost(  string antwort)
    {
      int? aufgabeId = HttpContext.Session.GetInt32("AufgabeId");
      if(aufgabeId==null)
      {
        Meldung = "Session abgelaufen";
        EsGehtWeiter = false;
        return;
      }

      var ergebnis= spielverwaltung.AntwortPrüfen(aufgabeId.Value, antwort);
      Meldung = ergebnis.Meldung;
      EsGehtWeiter = ergebnis.Schwierigkeitsgrad > 0;
      if (EsGehtWeiter)
        HttpContext.Session.SetInt32("Schwierigkeitsgrad", ergebnis.Schwierigkeitsgrad);
      else
        HttpContext.Session.Remove("Schwierigkeitsgrad");

      HttpContext.Session.Remove("AufgabeId");

    }
  }
}