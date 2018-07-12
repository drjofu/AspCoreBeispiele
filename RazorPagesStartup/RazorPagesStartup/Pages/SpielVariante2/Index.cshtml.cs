using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStartup.Models;

namespace RazorPagesStartup.Pages.SpielVariante2
{
  public class IndexModel : PageModel
  {
    private readonly Spielverwaltung spielverwaltung;
    public Aufgabe Aufgabe;

    [TempData]
    public string Meldung { get; set; } = "";

    [TempData]
    public int Schwierigkeitsgrad { get; set; } = 0;


    public IndexModel(Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnGet()
    {
      Aufgabe = spielverwaltung.GetAufgabeFürSchwierigkeitsgrad(Schwierigkeitsgrad);

    }
  }
}
