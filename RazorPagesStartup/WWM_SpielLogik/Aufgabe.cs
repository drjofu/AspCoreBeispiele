using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWM_SpielLogik
{
    public class Aufgabe
    {
      public int Id { get; set; }
      public int Schwierigkeitsgrad { get; set; }
      public string Frage { get; set; }
      public string Antwort1 { get; set; }
      public string Antwort2 { get; set; }
      public string Antwort3 { get; set; }
      public string Antwort4 { get; set; }
      public string Lösung { get; set; }

    }
}
