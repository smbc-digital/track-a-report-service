using System.Diagnostics.CodeAnalysis;
using track_a_report_service.Utils.HealthChecks;
using track_a_report_service.Utils.ServiceCollectionExtensions;
using track_a_report_service.Utils.StorageProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockportGovUK.AspNetCore.Availability;
using StockportGovUK.AspNetCore.Availability.Middleware;
using StockportGovUK.NetStandard.Gateways;
using StockportGovUK.NetStandard.Gateways.Extensions;

namespace track_a_report_service
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson();
            services.AddStorageProvider(Configuration);
            services.AddHttpClient<IGateway, Gateway>(Configuration, "IGatewayConfig");
            services.AddAvailability();
            services.AddSwagger();
            services.AddHealthChecks()
                    .AddCheck<TestHealthCheck>("TestHealthCheck");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler($"/api/v1/error{(env.IsDevelopment() ? "/local" : string.Empty)}");

            app.UseMiddleware<Availability>();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            
            app.UseHealthChecks("/healthcheck", HealthCheckConfig.Options);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "track_a_report_service API");
            });
        }
    }
}
