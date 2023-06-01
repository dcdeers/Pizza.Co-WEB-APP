using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizza.Co_WEB_APP.Data;
using System;

namespace Pizza.Co_WEB_APP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<PizzaCo_WEB_APPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<PizzaCo_WEB_APPContext>()
             .AddDefaultTokenProviders();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            CreateRoles(serviceProvider).Wait();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Member" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var _user = await UserManager.FindByEmailAsync("dirtjdin@gmail.com");
            if (_user != null)
            {
                await UserManager.AddToRoleAsync(_user, "Admin");
            }



        }

    }

    
}
