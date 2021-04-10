using FluentValidation;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERQUERY.DOMAIN.VALIDATION
{
    public sealed class UserAccessQuerySignatureValidation : AbstractValidator<IUserAccessQuerySignature>
    {
        public UserAccessQuerySignatureValidation()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.EmailObject).Must(x => x.IsValid());
            RuleFor(x => x.PasswordObject).Must(x => x.IsValid());
        }
    }
}
