using System.Diagnostics.CodeAnalysis;
using track_a_report_service.Utils.HealthChecks;
using track_a_report_service.Utils.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddHttpClient<IGateway, Gateway>(Configuration, "IGatewayConfig");
            services.AddSwagger();
            services.AddHealthChecks()
                    .AddCheck<TestHealthCheck>("TestHealthCheck");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler($"/api/v1/error{(env.IsDevelopment() ? "/local" : string.Empty)}")
                .UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers())
                .UseHealthChecks("/healthcheck", HealthCheckConfig.Options)
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Track a report service API");
                });
        }
    }
}
