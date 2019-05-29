using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.D3Integration.Settings
{
    [UsedImplicitly]
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
        [AzureTableCheck]
        public string DataConnString { get; set; }
    }
}
