using JetBrains.Annotations;
using Lykke.Sdk.Settings;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.Kyc.Client;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public D3IntegrationSettings D3IntegrationService { get; set; }
        public KycServiceClientSettings KycServiceClient { get; set; }
        public ClientAccountServiceClientSettings ClientAccountServiceClient { get; set; }
    }
}
