using System.Threading.Tasks;

namespace Lykke.Service.D3Integration.Domain.Repositories
{
    public interface ID3UsersRepository
    {
        Task<ID3User> GetUserAsync(string irohaUsername);
        Task AddUserAsync(string clientId, string irohaUsername, string publicKey, string clientName);
    }
}
