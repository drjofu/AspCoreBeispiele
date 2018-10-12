using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionsBeispiel.Utilities;
using System;

namespace SessionsBeispiel.Controllers
{
  public class Info
  {
    public DateTime? Startzeit { get; set; }
    public string Name { get; set; }
  }

  [Route("api/[controller]")]
  [ApiController]
  public class BeispielController : ControllerBase
  {
    public Info Get()
    {
      return new Info
      {
        Startzeit = HttpContext.Session.Get<DateTime?>("startzeit"),
        Name = HttpContext.Session.GetString("name")
      };
    }
  }
}