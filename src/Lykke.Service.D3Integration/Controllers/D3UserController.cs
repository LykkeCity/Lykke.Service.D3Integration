using System.Net;
using System.Threading.Tasks;
using Common;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Common.ApiLibrary.Exceptions;
using Lykke.Service.ClientAccount.Client;
using Lykke.Service.D3Integration.Client;
using Lykke.Service.D3Integration.Client.Models;
using Lykke.Service.D3Integration.Contract;
using Lykke.Service.D3Integration.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lykke.Service.D3Integration.Controllers
{
    [Route("api/d3user")]
    public class D3UserController : Controller, ID3UsersApi
    {
        private readonly ID3UserService _userService;
        private readonly IClientAccountClient _clientAccountClient;

        public D3UserController(
            ID3UserService userService,
            IClientAccountClient clientAccountClient
        )
        {
            _userService = userService;
            _clientAccountClient = clientAccountClient;
        }

        /// <summary>
        /// Adds D3 user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerOperation("AddD3User")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task AddD3UserAsync([FromBody]D3UserRequest request)
        {
            if (!request.IrohaUsername.IsValidPartitionOrRowKey())
                throw new ValidationApiException($"Invalid {nameof(request.IrohaUsername)} value");

            var user = await _userService.GetUserAsync(request.IrohaUsername);

            if (user != null)
                throw new ValidationApiException("User already exists");

            var client = await _clientAccountClient.GetClientByIdAsync(request.ClientId);

            if (client == null)
                throw new ValidationApiException("Client not found");

            await _userService.AddUserAsync(request.ClientId, request.IrohaUsername, request.PublicKey);
        }

        /// <summary>
        /// Gets KYC status by iroha username
        /// </summary>
        /// <param name="irohaUsername"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("kyc/{irohaUsername}")]
        [SwaggerOperation("GetKycStatus")]
        [ProducesResponseType(typeof(D3KycStatus), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        public async Task<D3KycStatus> GetKycStatusAsync(string irohaUsername)
        {
            if (!irohaUsername.IsValidPartitionOrRowKey())
                throw new ValidationApiException($"Invalid {nameof(irohaUsername)} value");

            var user = await _userService.GetUserAsync(irohaUsername);

            if (user == null)
                throw new ValidationApiException("User not found");

            return await _userService.GetKycStatusAsync(irohaUsername);
        }
    }
}
