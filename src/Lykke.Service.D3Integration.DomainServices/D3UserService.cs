using System.Threading.Tasks;
using Lykke.Service.D3Integration.Contract;
using Lykke.Service.D3Integration.Domain;
using Lykke.Service.D3Integration.Domain.Repositories;
using Lykke.Service.D3Integration.Domain.Services;
using Lykke.Service.Kyc.Abstractions.Domain.Verification;
using Lykke.Service.Kyc.Abstractions.Services;

namespace Lykke.Service.D3Integration.DomainServices
{
    public class D3UserService : ID3UserService
    {
        private readonly string _domain;
        private readonly ID3LedgerService _ledgerService;
        private readonly ID3UsersRepository _usersRepository;
        private readonly IKycStatusService _kycStatusService;

        public D3UserService(
            string domain,
            ID3LedgerService ledgerService,
            ID3UsersRepository usersRepository,
            IKycStatusService kycStatusService)
        {
            _domain = domain;
            _ledgerService = ledgerService;
            _usersRepository = usersRepository;
            _kycStatusService = kycStatusService;
        }

        public Task<ID3User> GetUserAsync(string irohaUsername)
        {
            return _usersRepository.GetUserAsync(irohaUsername);
        }

        public async Task AddUserAsync(string clientId, string irohaUsername, string publicKey)
        {
            string clientName = await _ledgerService.RegisterUserAsync(irohaUsername, _domain, publicKey);
            await _usersRepository.AddUserAsync(clientId, irohaUsername, publicKey, clientName);
        }

        public async Task<D3KycStatus> GetKycStatusAsync(string irohaUsername)
        {
            ID3User user = await GetUserAsync(irohaUsername);

            KycStatus kycStatus = await _kycStatusService.GetKycStatusAsync(user.ClientId);

            return kycStatus.GetKycStatus();
        }
    }
}
