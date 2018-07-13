using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
  public class Teilnehmer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<TeilnehmerTermin> TeilnehmerTermine { get; set; }

  }
}
