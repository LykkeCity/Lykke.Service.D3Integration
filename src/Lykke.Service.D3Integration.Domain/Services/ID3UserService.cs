using System.Threading.Tasks;
using Lykke.Service.D3Integration.Contract;

namespace Lykke.Service.D3Integration.Domain.Services
{
    public interface ID3UserService
    {
        Task<ID3User> GetUserAsync(string irohaUsername);
        Task AddUserAsync(string clientId, string irohaUsername, string publicKey);
        Task<D3KycStatus> GetKycStatusAsync(string irohaUsername);
    }
}
