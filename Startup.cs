using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueryBuilder.DbContexts;
using Microsoft.Extensions.Configuration;
using QueryBuilder.Services;
using QueryBuilder.DataAccessLayer;

namespace QueryBuilder
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("YourConnectionString")));
            services.AddTransient<AppDbContext>();
            services.AddTransient<QueryService>();
            services.AddTransient<QueryTemplateService>();
            services.AddTransient<QueryTemplateRepository>();
            services.AddTransient<QueryResponseProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            { 

                endpoints.MapControllerRoute(
                    name: "queryTemplate",
                    pattern: "querytemplate/{action=Index}/{id?}",
                    defaults: new { controller = "QueryTemplate" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Columns}/{action=Index}/{id?}");
            });
        }
    }
}
