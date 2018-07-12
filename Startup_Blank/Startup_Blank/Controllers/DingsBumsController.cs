using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_Blank.Controllers
{
  public class DingsBumsController
  {
    public string Aha(string text)
    {
      return $"Der Text '{text}' wurde übergeben";
    }
  }
}
