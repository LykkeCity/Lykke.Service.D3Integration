using Lykke.HttpClientGenerator;

namespace Lykke.Service.D3Integration.Client
{
    /// <summary>
    /// D3Integration API aggregating interface.
    /// </summary>
    public class D3IntegrationClient : ID3IntegrationClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to D3Integration Api.</summary>
        public ID3IntegrationApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public D3IntegrationClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<ID3IntegrationApi>();
        }
    }
}
