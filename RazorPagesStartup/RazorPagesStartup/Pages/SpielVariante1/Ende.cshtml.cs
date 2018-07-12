using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStartup.Models;

namespace RazorPagesStartup.Pages.SpielVariante1
{
  public class EndeModel : PageModel
  {
    private readonly Spielverwaltung spielverwaltung;

    [TempData]
    public string Meldung { get; set; }

    public EndeModel(Spielverwaltung spielverwaltung)
    {
      this.spielverwaltung = spielverwaltung;
    }

    public void OnPost(int aufgabeId)
    {
      Meldung = spielverwaltung.Aufgeben(aufgabeId);
    }
  }
}