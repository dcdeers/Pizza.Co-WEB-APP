﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizza.Co_WEB_APP.Data;
using Pizza.Co_WEB_APP.Models;

namespace Pizza.Co_WEB_APP.Pages.Menus
{
    public class EditModel : PageModel
    {
        private readonly Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext _context;

        public EditModel(Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu =  await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            Menu = menu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(Menu.ID))
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

        private bool MenuExists(int id)
        {
          return (_context.Menu?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
