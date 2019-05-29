using Autofac;
using AzureStorage.Tables;
using JetBrains.Annotations;
using Lykke.Common.Log;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.D3Integration.AzureRepositories;
using Lykke.Service.D3Integration.Domain.Repositories;
using Lykke.Service.D3Integration.Domain.Services;
using Lykke.Service.D3Integration.DomainServices;
using Lykke.Service.D3Integration.Settings;
using Lykke.Service.Kyc.Abstractions.Services;
using Lykke.Service.Kyc.Client;
using Lykke.SettingsReader;

namespace Lykke.Service.D3Integration.Modules
{
    [UsedImplicitly]
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
                new D3UsersRepository(AzureTableStorage<D3UserEntity>.Create(
                    _appSettings.ConnectionString(x => x.D3IntegrationService.Db.DataConnString),
                    "D3Users", ctx.Resolve<ILogFactory>()))
            ).As<ID3UsersRepository>().SingleInstance();

            builder.RegisterType<D3UserService>()
                .As<ID3UserService>()
                .WithParameter(TypedParameter.From(_appSettings.CurrentValue.D3IntegrationService.D3Ledger.Domain))
                .SingleInstance();
            
            builder.Register(ctx =>
                    new KycStatusServiceClient(_appSettings.CurrentValue.KycServiceClient, ctx.Resolve<ILogFactory>())
            ).As<IKycStatusService>().SingleInstance();
            
            builder.RegisterLykkeServiceClient(_appSettings.CurrentValue.ClientAccountServiceClient.ServiceUrl);
        }
    }
}
