using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.D3Integration.Domain;
using Lykke.Service.D3Integration.Domain.Repositories;

namespace Lykke.Service.D3Integration.AzureRepositories
{
    public class D3UsersRepository : ID3UsersRepository
    {
        private readonly INoSQLTableStorage<D3UserEntity> _tableStorage;

        public D3UsersRepository(INoSQLTableStorage<D3UserEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public async Task<ID3User> GetUserAsync(string irohaUsername)
        {
            return await _tableStorage.GetDataAsync(D3UserEntity.GeneratePartitionKey(irohaUsername),
                D3UserEntity.GenerateRowKey(irohaUsername));
        }

        public Task AddUserAsync(string clientId, string irohaUsername, string publicKey, string clientName)
        {
            return _tableStorage.InsertOrMergeAsync(D3UserEntity.Create(clientId, irohaUsername, publicKey, clientName));
        }
    }
}
