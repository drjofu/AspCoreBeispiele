using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace FileUpDown.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public IEnumerable< IFormFile> FileToUpload { get; set; }

    public IEnumerable<string> GetFilenames()
    {
      return Directory.EnumerateFiles(@"C:\Projekte\Schulungen\AspCoreBeispiele\FileUpDown\FileUpDown\Files").Select(f => Path.GetFileName(f));
    }

    public void OnGet()
    {

    }

    public async Task OnPostAsync()
    {
      foreach (var item in FileToUpload)
      {
        var stream = item.OpenReadStream();
        var buffer = new byte[item.Length];
        var n = await stream.ReadAsync(buffer, 0, buffer.Length);
        await System.IO.File.WriteAllBytesAsync(Path.Combine(@"C:\Projekte\Schulungen\AspCoreBeispiele\FileUpDown\FileUpDown\Files", item.FileName), buffer);

      }
    }
  }
}
