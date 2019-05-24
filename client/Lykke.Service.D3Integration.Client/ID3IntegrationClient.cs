using JetBrains.Annotations;

namespace Lykke.Service.D3Integration.Client
{
    /// <summary>
    /// D3Integration client interface.
    /// </summary>
    [PublicAPI]
    public interface ID3IntegrationClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - ID3IntegrationApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        ID3IntegrationApi Api { get; }
    }
}
