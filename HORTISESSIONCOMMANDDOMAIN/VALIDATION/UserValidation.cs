using FluentValidation;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERCOMMAND.DOMAIN.VALIDATION
{
    public sealed class CreateUserCommandValidation : AbstractValidator<ICreateUserCommandSignature>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.EmailObject).Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => x.IsValid());
            RuleFor(x => x.PasswordObject).Must(x => x.IsValid());
        }
    }

    public sealed class DeleteUserCommandValidation : AbstractValidator<IDeleteUserCommandSignature>
    {
        public DeleteUserCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.EmailObject).Must(x => x.IsValid());
            RuleFor(x => x.PasswordObject).Must(x => x.IsValid());
        }
    }

    public sealed class UpdateUserCommandValidation : AbstractValidator<IUpdateUserCommandSignature>
    {
        public UpdateUserCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.EmailObject).Must(x => x.IsValid());
            RuleFor(x => x.PhoneObject).Must(x => x.IsValid());
            RuleFor(x => x.PasswordObject).Must(x => x.IsValid());
        }
    }
}
