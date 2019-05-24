using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public D3IntegrationSettings D3IntegrationService { get; set; }
    }
}
