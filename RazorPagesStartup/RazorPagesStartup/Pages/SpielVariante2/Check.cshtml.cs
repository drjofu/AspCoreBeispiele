using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStartup.Models;

namespace RazorPagesStartup.Pages.SpielVariante2
{
  public class CheckModel : PageModel
  {
    private readonly Spielverwaltung spielverwaltung;

    [TempData]
    public string Meldung { get; set; }
    public bool EsGehtWeiter { get; private set; }
    [TempData]
    public int Schwierigkeitsgrad { get; set; } = 0;


    public CheckModel(Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnPost( int aufgabeId, string antwort)
    {
      var ergebnis= spielverwaltung.AntwortPrüfen(aufgabeId, antwort);
      Meldung = ergebnis.Meldung;
      EsGehtWeiter = ergebnis.Schwierigkeitsgrad > 0;
      if (EsGehtWeiter)
        Schwierigkeitsgrad = ergebnis.Schwierigkeitsgrad;
      else
        Schwierigkeitsgrad = 0;
    }
  }
}