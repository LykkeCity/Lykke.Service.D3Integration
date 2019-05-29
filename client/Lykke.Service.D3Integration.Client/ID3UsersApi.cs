using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.D3Integration.Client.Models;
using Lykke.Service.D3Integration.Contract;
using Refit;

namespace Lykke.Service.D3Integration.Client
{
    // This is an example of service controller interfaces.
    // Actual interface methods must be placed here (not in ID3IntegrationClient interface).

    /// <summary>
    /// D3Integration client API interface.
    /// </summary>
    [PublicAPI]
    public interface ID3UsersApi
    {
        /// <summary>
        /// Adds D3 user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Post("/api/d3user")]
        Task AddD3UserAsync([Body]D3UserRequest request);

        /// <summary>
        /// Gets KYC status by iroha username
        /// </summary>
        /// <param name="irohaUsername">Iroha username</param>
        /// <returns></returns>
        [Get("/api/d3user/kyc/{irohaUsername}")]
        Task<D3KycStatus> GetKycStatusAsync(string irohaUsername);
    }
}
