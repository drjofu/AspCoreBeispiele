using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
  public class Kurs
  {
    public Kurs()
    {

    }

    public int Id { get; set; }
    public int Kursnummer { get; set; }
    public string Name { get; set; }
    public string Beschreibung { get; set; }

    public List<Termin> Termine { get; set; }
  }
}
