using Lykke.Service.D3Integration.Domain;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.D3Integration.AzureRepositories
{
    public class D3UserEntity : TableEntity, ID3User
    {
        public string ClientId { get; set; }
        public string IrohaUsername { get; set; }
        public string PublicKey { get; set; }
        public string ClientName { get; set; }
        
        internal static string GeneratePartitionKey(string id) => $"{id}";
        internal static string GenerateRowKey(string id) => $"user_{id}";

        public static D3UserEntity Create(string clientId, string irohaUsername, string publicKey, string clientName)
        {
            return new D3UserEntity
            {
                PartitionKey = GeneratePartitionKey(irohaUsername),
                RowKey = GenerateRowKey(irohaUsername),
                IrohaUsername = irohaUsername,
                ClientId = clientId,
                PublicKey = publicKey,
                ClientName = clientName
            };
        }
    }
}
