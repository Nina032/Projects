using Microsoft.AspNetCore.Builder;

namespace ExempelProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
 
        }
        public void Configure(IApplicationBuilder app)
        {
           app.UseDefaultFiles();
           app.UseStaticFiles();
        }
    }
}
