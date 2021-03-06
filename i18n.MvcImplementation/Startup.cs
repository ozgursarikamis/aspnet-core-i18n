using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

namespace i18n.MvcImplementation
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
          var mvcBuilder = services.AddControllersWithViews();
          mvcBuilder.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
          services.Configure<LocalizationOptions>(options =>
          {
              options.ResourcesPath = "Resources";
          });

          services.Configure<RequestLocalizationOptions>(options =>
          {
              options.SupportedUICultures = new List<CultureInfo>
              {
                  new CultureInfo("en-US"),
                  new CultureInfo("ru-RU"),
                  new CultureInfo("es-MX"),
              };
              options.DefaultRequestCulture = new RequestCulture("en-US");
          });
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRequestLocalization();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
