using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
  public class Termin
  {
    public int Id { get; set; }

    public int KursId { get; set; }
    public Kurs Kurs { get; set; }

    [DataType(DataType.Date)]
    public DateTime Start { get; set; }

    public ICollection<TeilnehmerTermin> TeilnehmerTermine { get; set; }

  }
}
