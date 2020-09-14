using System.Collections.Generic;
using System.Globalization;
using i18n.Middlewares.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace i18n.Middlewares
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
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedCultures = new List<CultureInfo>
                {
                    // new CultureInfo("bs"),
                    new CultureInfo("de"),
                    new CultureInfo("es"),
                    new CultureInfo("fr-FR"),
                };
                options.FallBackToParentUICultures = true;
                options.DefaultRequestCulture = new RequestCulture("es");
                options.RequestCultureProviders.Insert(0,
                    new RouteDataRequestCultureProvider());

                options.RequestCultureProviders.Insert(1,
                    new CountryDomainRequestCultureProvider());
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            // app.UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{ui-culture}/{controller=Enumerations}/{action=Genders}/{id?}");
            });
        }
    }
}
