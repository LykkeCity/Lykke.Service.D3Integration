using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.D3Integration.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Lykke.Service.D3Integration.Domain.Services;
using Lykke.Service.D3Integration.DomainServices;

namespace Lykke.Service.D3Integration
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "D3Integration API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "D3IntegrationLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.D3IntegrationService.Db.LogsConnString;
                };

                options.Extend = (sc, settings) =>
                {
                    sc.AddHttpClient<ID3LedgerService, D3LedgerService>(client =>
                    {
                        client.BaseAddress =
                            new Uri(settings.CurrentValue.D3IntegrationService.D3Ledger.ServiceUrl);
                    });
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseLykkeConfiguration(options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });
        }
    }
}
