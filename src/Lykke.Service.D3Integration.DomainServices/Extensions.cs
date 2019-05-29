using Lykke.Service.D3Integration.Contract;
using Lykke.Service.Kyc.Abstractions.Domain.Verification;

namespace Lykke.Service.D3Integration.DomainServices
{
    public static class Extensions
    {
        public static D3KycStatus GetKycStatus(this KycStatus status)
        {
            switch (status)
            {
                case KycStatus.NeedToFillData:
                    return D3KycStatus.Pending;
                case KycStatus.Pending:
                    return D3KycStatus.Processing;
                case KycStatus.ReviewDone:
                case KycStatus.Ok:
                    return D3KycStatus.Ok;
                default:
                    return D3KycStatus.Failed;
            }
        }
    }
}
