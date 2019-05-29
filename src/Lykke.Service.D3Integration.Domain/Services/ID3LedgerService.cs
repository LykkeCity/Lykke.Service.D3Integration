using System.Threading.Tasks;

namespace Lykke.Service.D3Integration.Domain.Services
{
    public interface ID3LedgerService
    {
        Task<string> RegisterUserAsync(string username, string domain, string publicKey);
    }
}
