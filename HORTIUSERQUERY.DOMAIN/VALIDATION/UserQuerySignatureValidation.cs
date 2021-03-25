using FluentValidation;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERQUERY.DOMAIN.VALIDATION
{
    public sealed class UserQuerySignatureValidation : AbstractValidator<IUserQuerySignature>
    {
        public UserQuerySignatureValidation()
        {   
            RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        }
    }
}
