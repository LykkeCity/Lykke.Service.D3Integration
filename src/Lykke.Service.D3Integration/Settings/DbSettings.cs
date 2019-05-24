using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.D3Integration.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
