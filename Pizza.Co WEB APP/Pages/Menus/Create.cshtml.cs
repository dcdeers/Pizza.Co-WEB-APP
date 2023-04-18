using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pizza.Co_WEB_APP.Data;
using Pizza.Co_WEB_APP.Models;

namespace Pizza.Co_WEB_APP.Pages.Menus
{
    public class CreateModel : PageModel
    {
        private readonly Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext _context;

        public CreateModel(Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Menu == null || Menu == null)
            {
                return Page();
            }

            _context.Menu.Add(Menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
