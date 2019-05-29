namespace Lykke.Service.D3Integration.Domain
{
    public interface ID3User
    {
        string ClientId { get; }
        string IrohaUsername { get; }
        string PublicKey { get; }
        string ClientName { get; }
    }
}
