using Microsoft.EntityFrameworkCore;
using Pizza.Co_WEB_APP.Data;

namespace Pizza.Co_WEB_APP.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PizzaCo_WEB_APPContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PizzaCo_WEB_APPContext>>()))
            {
                if (context == null || context.Menu == null)
                {
                    throw new ArgumentNullException("Null PizzaCo_WEB_APPContex");
                }

                if (context.Menu.Any())
                {
                    return;
                }

                context.Menu.AddRange(
                    new Menu
                    {
                        
                        Name = "Pepperoni Pizza",
                        Category = "Romantic Comedy",
                        Price = 10.00M

                    }

                    );
                context.SaveChanges();




            }

        }
    }
}
