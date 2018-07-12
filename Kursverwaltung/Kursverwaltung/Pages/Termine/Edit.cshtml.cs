using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Termine
{
  public class EditModel : PageModel
  {
    private readonly Kursverwaltung.Models.KursverwaltungContext _context;

    public EditModel(Kursverwaltung.Models.KursverwaltungContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Termin Termin { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Termin = await _context.Termin
          .Include(t => t.Kurs).FirstOrDefaultAsync(m => m.Id == id);

      if (Termin == null)
      {
        return NotFound();
      }
      ViewData["KursId"] = new SelectList(_context.Kurs, "Id", "Id");
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Termin).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TerminExists(Termin.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool TerminExists(int id)
    {
      return _context.Termin.Any(e => e.Id == id);
    }
  }
}
