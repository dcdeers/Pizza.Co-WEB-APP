using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pizza.Co_WEB_APP.Models;

namespace Pizza.Co_WEB_APP.Data
{
    public class PizzaCo_WEB_APPContext : DbContext
    {
        public PizzaCo_WEB_APPContext (DbContextOptions<PizzaCo_WEB_APPContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza.Co_WEB_APP.Models.Menu> Menu { get; set; } = default!;
    }
}
