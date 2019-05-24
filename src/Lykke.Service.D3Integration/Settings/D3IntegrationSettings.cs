using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class D3IntegrationSettings
    {
        public DbSettings Db { get; set; }
    }
}
