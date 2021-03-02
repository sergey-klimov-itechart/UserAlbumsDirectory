using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserDirectory.BusinessLayer;
using UserDirectory.Infrastructure;
using UserDirectory.Repository;

namespace UserDirectory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserDirectoryRepository, JsonplaceholderRepository>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseStatusCodePages("text/plain", "Error. Status code : {0}");
            
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "Error",
                    "Error",
                    new { controller = "Error", action = "Error" });

                endpoints.MapControllerRoute(
                    "",
                    "",
                    new { controller = "Album", action = "List", pageNumber = 1 });

                endpoints.MapControllerRoute(
                    name: null,
                    "{controller}/{action}/{id?}");
            });
        }
    }
}
