using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParamStoreApp.Models;

namespace ParamStoreApp
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
            services.AddControllers();

            services.Configure<ConfigOptions>(
                Configuration.GetSection("Config")
            );

            services.Configure<SmtpOptions>(
                Configuration.GetSection(SmtpOptions.SectionName));

            services.Configure<OidcOptions>(
                OidcProviders.Google,
                Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Google}"));

            services.Configure<OidcOptions>(
                OidcProviders.Facebook,
                Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Facebook}"));

            services.Configure<OidcOptions>(
                OidcProviders.Okta,
                Configuration.GetSection($"{OidcOptions.SectionName}:{OidcProviders.Okta}"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
