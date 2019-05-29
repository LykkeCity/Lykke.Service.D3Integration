using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Log;
using JetBrains.Annotations;
using Lykke.Common.ApiLibrary.Exceptions;
using Lykke.Common.Log;
using Lykke.Service.D3Integration.Domain;
using Lykke.Service.D3Integration.Domain.Services;
using Newtonsoft.Json;

namespace Lykke.Service.D3Integration.DomainServices
{
    [UsedImplicitly]
    public class D3LedgerService : ID3LedgerService
    {
        private readonly HttpClient _client;
        private readonly ILog _log;

        public D3LedgerService(
            HttpClient client,
            ILogFactory logFactory
            )
        {
            _client = client;
            _log = logFactory.CreateLog(this);
        }

        public async Task<string> RegisterUserAsync(string username, string domain, string publicKey)
        {
            var data = new MultipartFormDataContent
            {
                {new StringContent(username), "name"},
                {new StringContent(domain), "domain"},
                {new StringContent(publicKey), "pubkey"}
            };

            var response = await _client.PostAsync("/users", data);

            if (response == null)
            {
                _log.Error(message: "No response from d3ledge service", context: new {name = username, domain, publicKey});
                throw new ValidationApiException(HttpStatusCode.InternalServerError, "No response from d3ledge service");
            }

            string responseData = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(responseData))
            {
                _log.Error(message: "Empty response from d3ledge service", context: new {name = username, domain, publicKey});
                throw new ValidationApiException(HttpStatusCode.InternalServerError, "Empty response from d3ledge service");
            }

            D3Response d3Response;

            try
            {
                d3Response = JsonConvert.DeserializeObject<D3Response>(responseData);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Can't deserialize response", responseData);
                throw;
            }

            if (response.IsSuccessStatusCode)
                return d3Response.ClientId;

            _log.Error(message: d3Response.Message, context: d3Response);
            throw new ValidationApiException(HttpStatusCode.InternalServerError,
                $"message: {d3Response.Message}, details: {d3Response.Details}");
        }
    }
}
