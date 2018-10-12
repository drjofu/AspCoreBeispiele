using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpDown.Controllers
{
  [Route("api/[controller]/{name}", Name = "FileRoute")]
  [ApiController]
  public class ImageDownloadController : ControllerBase
  {
    public FileResult Get(string name)
    {
      name = Path.GetFileName(name);
      return File(System.IO.File.OpenRead(Path.Combine(@"C:\Projekte\Schulungen\AspCoreBeispiele\FileUpDown\FileUpDown\Files", name)), MediaTypeNames.Image.Jpeg/*, name*/);
    }

    [HttpGet("files")]
    public IEnumerable<string> GetFilenames()
    {
      return Directory.EnumerateFiles(@"C:\Projekte\Schulungen\AspCoreBeispiele\FileUpDown\FileUpDown\Files").Select(f=>Path.GetFileName(f));
    }
  }
}