using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace i18n.Middlewares.Localization
{
    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app,
            IOptions<RequestLocalizationOptions> options)
        {
            app.UseRequestLocalization(options.Value);
        }
    }
}
