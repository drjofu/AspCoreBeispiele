using System;
using System.Linq;

namespace WWM_SpielLogik
{
  public class Spiel
  {
    public int AktuellerSchwierigkeitsgrad { get; set; }
    public Aufgabe Aufgabe { get; set; }
    public bool SpielBeendet { get; set; }
    public string Meldung { get; set; }

    private int[] gewinnstufen = { 0, 50, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 500000, 1000000 };

    public Spiel()
    {
      AufgabeAuslosen();
    }

    private void AufgabeAuslosen()
    {
      AktuellerSchwierigkeitsgrad++;
      //using (var db = new WWMKontext("WWM"))
      //{
      //  var query = db.Aufgabe.Where(a => a.Schwierigkeitsgrad == AktuellerSchwierigkeitsgrad).OrderBy(a => a.Id);
      //  var n = query.Count();
      //  n = new Random().Next(n);
      //  Aufgabe = query.Skip(n).First();
      //}
    }

    public void Aufgeben()
    {
      Meldung = "Glückwunsch zu " + gewinnstufen[AktuellerSchwierigkeitsgrad - 1] + " Talern!";
      SpielBeendet = true;
    }
    public void AntwortPrüfen(string antwort)
    {
      if (Aufgabe.Lösung == antwort.ToUpper())
      {
        if (AktuellerSchwierigkeitsgrad == 15)
        {
          Meldung = "Glückwunsch zu 1.000.000 Talern!";
          SpielBeendet = true;
        }
        else
        {
          Meldung = "Richtig! Sie stehen bei " + gewinnstufen[AktuellerSchwierigkeitsgrad] + " Talern.";
          AufgabeAuslosen();
        }
      }
      else
      {
        Meldung = "Leider falsch! Die richtige Antwort verraten wir nicht...";
        SpielBeendet = true;
      }
    }

  }
}
