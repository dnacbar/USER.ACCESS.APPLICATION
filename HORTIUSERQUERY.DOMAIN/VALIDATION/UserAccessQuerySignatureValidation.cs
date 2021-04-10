using FluentValidation;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERQUERY.DOMAIN.VALIDATION
{
    public sealed class UserLogoutQuerySignatureValidation : AbstractValidator<IUserLogoutQuerySignature>
    {
        public UserLogoutQuerySignatureValidation()
        {
            RuleFor(x => x.IdSession).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
