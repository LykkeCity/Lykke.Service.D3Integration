using JetBrains.Annotations;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class D3IntegrationSettings
    {
        public DbSettings Db { get; set; }
        public D3LedgerSettings D3Ledger { get; set; }
    }
}
