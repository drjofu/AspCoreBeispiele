using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Termine
{
  public class KursListItem
  {
    public int Id { get; set; }
    public string Text { get; set; }
  }

  public class CreateModel : PageModel
  {
    private readonly Kursverwaltung.Models.KursverwaltungContext _context;

    public CreateModel(Kursverwaltung.Models.KursverwaltungContext context)
    {
      _context = context;
    }

    public List<KursListItem> KursSelectList { get; set; }

    public IActionResult OnGet()
    {
      KursSelectList = _context.Kurs.Select(k => new KursListItem { Id = k.Id, Text = k.Kursnummer + " " + k.Name }).ToList();
      ViewData["KursId"] = new SelectList(_context.Kurs, "Id", "Name");
      return Page();
    }

    [BindProperty]
    public Termin Termin { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Termin.Add(Termin);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}