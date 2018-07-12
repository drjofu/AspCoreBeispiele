using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStartup.Models
{
  public class AufgabeViewModel
  {
    public WWM_SpielLogik.Aufgabe Aufgabe { get; set; }
    public string Meldung { get; set; }
  }
}
