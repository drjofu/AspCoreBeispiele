﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kursverwaltung.Models;

namespace Kursverwaltung.Pages.Kurse
{
    public class CreateModel : PageModel
    {
        private readonly Kursverwaltung.Models.KursverwaltungContext _context;

        public CreateModel(Kursverwaltung.Models.KursverwaltungContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kurs Kurs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kurs.Add(Kurs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}