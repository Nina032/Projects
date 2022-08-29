using ExempelProject.Data;
using ExempelProject.Services;
using Microsoft.AspNetCore.Builder;

namespace ExempelProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExempelProjectContext>();
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddTransient<IMailService, NullMailService>();
            services.AddTransient<ExempelSeeder>();
            services.AddScoped<IExempelRepository, ExempelRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();

                cfg.MapControllerRoute("Default,",
                "/{controller}/{action}/{id?}",
                new { controller = "App", action = "Index" });
            });
        }
    }
}
