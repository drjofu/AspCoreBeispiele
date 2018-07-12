using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_Blank.Models
{
  public class Kurs
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Beschreibung { get; set; }

    public static IEnumerable<Kurs> GetKurse()
    {
      yield return new Kurs() { Id = 77, Name = "ASP.NET", Beschreibung = "Webentwicklung lernen" };
      yield return new Kurs() { Id = 78, Name = "C#", Beschreibung = "C# lernen" };
      yield return new Kurs() { Id = 78, Name = "yield return", Beschreibung = "Enumerator pattern lernen" };
    }
  }
}
