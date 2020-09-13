using System.Globalization;
using i18n.StringLocalizers.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace i18n.StringLocalizers
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
            //services.AddRazorPages();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IHelpService, HelpService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
            app.Run(async context =>
            {
                if (context.Request.Query.ContainsKey("ui"))
                {
                    var tag = context.Request.Query["ui"];
                    CultureInfo.CurrentUICulture = new CultureInfo(tag);

                }
                if (context.Request.Query.ContainsKey("about"))
                {
                    var searchTerm = context.Request.Query["about"];
                    IAboutService service = context.RequestServices.GetService<IAboutService>();
                    var content = service.Reply(searchTerm);
                    await context.Response.WriteAsync(content);
                    return;
                }

                if (context.Request.Query.ContainsKey("help"))
                {
                    string serviceName = context.Request.Query["help"];
                    IHelpService service = context.RequestServices.GetService<IHelpService>();

                    var content = service.GetHelpFor(serviceName);
                    await context.Response.WriteAsync(content);

                    return;
                }

                if (context.Request.Query.ContainsKey("department"))
                {
                    var department = context.Request.Query["department"];

                    IDepartmentService service = context.RequestServices.GetService<IDepartmentService>();
                    var info = service.GetInfo(department);

                    await context.Response.WriteAsync(info);

                    return;
                }

                await context.Response.WriteAsync("Welcome to App-O-Matic");
            });
        }
    }
}
