using Lykke.HttpClientGenerator;

namespace Lykke.Service.D3Integration.Client
{
    /// <summary>
    /// D3Integration API aggregating interface.
    /// </summary>
    public class D3IntegrationClient : ID3IntegrationClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Interface to D3Users Api.</summary>
        public ID3UsersApi Users { get; private set; }

        /// <summary>C-tor</summary>
        public D3IntegrationClient(IHttpClientGenerator httpClientGenerator)
        {
            Users = httpClientGenerator.Generate<ID3UsersApi>();
        }
    }
}
