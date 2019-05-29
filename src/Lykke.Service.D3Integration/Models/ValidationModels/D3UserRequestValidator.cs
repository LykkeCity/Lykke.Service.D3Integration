using Common;
using FluentValidation;
using JetBrains.Annotations;
using Lykke.Service.D3Integration.Client.Models;

namespace Lykke.Service.D3Integration.Models.ValidationModels
{
    [UsedImplicitly]
    public class D3UserRequestValidator : AbstractValidator<D3UserRequest>
    {
        public D3UserRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty();

            RuleFor(x => x.PublicKey)
                .NotEmpty();

            RuleFor(x => x.IrohaUsername)
                .NotEmpty()
                .Must(s => s.IsValidPartitionOrRowKey())
                .WithMessage(x => $"Invalid {nameof(x.IrohaUsername)} value");
        }
    }
}
