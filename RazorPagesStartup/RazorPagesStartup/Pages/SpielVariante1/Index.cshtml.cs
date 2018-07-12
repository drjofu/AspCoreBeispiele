using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStartup.Models;

namespace RazorPagesStartup.Pages.SpielVariante1
{
  public class IndexModel : PageModel
  {
    private readonly Spielverwaltung spielverwaltung;
    public Aufgabe Aufgabe;

    [TempData]
    public string Meldung { get; set; } = "";

    public IndexModel(Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnGet(int schwierigkeitsgrad=0)
    {
      Aufgabe = spielverwaltung.GetAufgabeFürSchwierigkeitsgrad(schwierigkeitsgrad);
    }
  }
}
