using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza.Co_WEB_APP.Data;
using Pizza.Co_WEB_APP.Models;

namespace Pizza.Co_WEB_APP.Pages.Menus
{
    public class IndexModel : PageModel
    {
        private readonly Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext _context;

        public IndexModel(Pizza.Co_WEB_APP.Data.PizzaCo_WEB_APPContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Menu != null)
            {
                Menu = await _context.Menu.ToListAsync();
            }
        }
    }
}
