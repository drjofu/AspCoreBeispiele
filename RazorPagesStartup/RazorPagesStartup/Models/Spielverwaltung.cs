using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesStartup.Models
{
  public class Spielverwaltung
  {
    private readonly int[] gewinnstufen =  { 0, 50, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 500000, 1000000 };
    private readonly List<Aufgabe>[] aufgaben = new List<Aufgabe>[15];
    private Random rnd = new Random();
    private Dictionary<int, Aufgabe> aufgabenDict = new Dictionary<int, Aufgabe>();

    public (int Schwierigkeitsgrad, string Meldung) AntwortPrüfen(int aufgabeId, string antwort)
    {
      var aufgabe = aufgabenDict[aufgabeId];
      if (aufgabe.Lösung == antwort?.ToUpper())
      {
        if (aufgabe.Schwierigkeitsgrad == 15)
          return (-1, "Glückwunsch zu 1.000.000 Talern!");
        return (aufgabe.Schwierigkeitsgrad, "Richtig! Sie stehen bei " + gewinnstufen[aufgabe.Schwierigkeitsgrad] + " Talern.");
      }
      else
      {
        return (-2, "Leider falsch! Die richtige Antwort verraten wir nicht...");
      }
    }

    public Aufgabe GetAufgabeMitId(int aufgabeId)
    {
      return aufgabenDict[aufgabeId];
    }

    public string Aufgeben(int aufgabeId)
    {
      return $"Schade! - Trotzdem Glückwunsch zu {gewinnstufen[aufgabenDict[aufgabeId].Schwierigkeitsgrad-1]} Talern";
    }

    public Spielverwaltung(IConfiguration configuration)
    {
      for (int i = 0; i < aufgaben.Length; i++)
      {
        aufgaben[i] = new List<Aufgabe>();
      }

      string pfad = configuration.GetValue<string>("Spiel:PfadAufgabendatei");
      int id = 1;
      foreach (var zeile in File.ReadLines(pfad))
      {
        var aufgabe = new Aufgabe();
        var teile = zeile.Split(';');
        aufgabe.Schwierigkeitsgrad = int.Parse(teile[0]);
        aufgabe.Frage = teile[1];
        aufgabe.Antwort1 = teile[2];
        aufgabe.Antwort2 = teile[3];
        aufgabe.Antwort3 = teile[4];
        aufgabe.Antwort4 = teile[5];
        aufgabe.Lösung = teile[6];
        aufgabe.Id = id++;
        aufgaben[aufgabe.Schwierigkeitsgrad-1].Add(aufgabe);
        aufgabenDict.Add(aufgabe.Id, aufgabe);
      }
    }

    public Aufgabe GetAufgabeFürSchwierigkeitsgrad(int schwierigkeitsgrad)
    {
      int index = rnd.Next(aufgaben[schwierigkeitsgrad].Count);
      return aufgaben[schwierigkeitsgrad][index];
    }



  }
}
