using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
  public class TeilnehmerTermin
  {
    public int TeilnehmerId { get; set; }
    public Teilnehmer Teilnehmer { get; set; }

    public int TerminId { get; set; }
    public Termin Termin { get; set; }

  }
}
