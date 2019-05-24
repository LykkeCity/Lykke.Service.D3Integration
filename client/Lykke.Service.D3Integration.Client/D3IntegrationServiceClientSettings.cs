using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.D3Integration.Client 
{
    /// <summary>
    /// D3Integration client settings.
    /// </summary>
    public class D3IntegrationServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
