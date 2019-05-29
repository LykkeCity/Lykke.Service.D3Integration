using JetBrains.Annotations;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly]
    public class D3LedgerSettings
    {
        public string ServiceUrl { get; set; }
        public string Domain { get; set; }
    }
}
