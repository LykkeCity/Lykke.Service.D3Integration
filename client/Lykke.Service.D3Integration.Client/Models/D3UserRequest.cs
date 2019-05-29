namespace Lykke.Service.D3Integration.Client.Models
{
    /// <summary>
    /// Add d3 user request
    /// </summary>
    public class D3UserRequest
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Iroha username
        /// </summary>
        public string IrohaUsername { get; set; }

        /// <summary>
        /// D3 public key
        /// </summary>
        public string PublicKey { get; set; }
    }
}
