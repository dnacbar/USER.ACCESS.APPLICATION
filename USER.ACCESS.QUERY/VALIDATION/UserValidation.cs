using FluentValidation;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE.QUERY;

namespace USER.ACCESS.QUERY.VALIDATION
{
    public sealed class UserValidation : AbstractValidator<UserQuerySignature>
    {
        public UserValidation()
        {
            RuleFor(x => x).NotEmpty().WithMessage(nameof(UserQuerySignature).ToUpperInvariant() + ": IS NULL OR EMPTY!");
            RuleFor(x => x.IdSystem).NotEmpty().WithMessage("ID SYSTEM INVALID!");
            //RuleFor(x => x.DS).NotEmpty().WithMessage("ID SYSTEM INVALID!");
        }
    }
}
