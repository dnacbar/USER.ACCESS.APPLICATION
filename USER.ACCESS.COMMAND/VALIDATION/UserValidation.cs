using FluentValidation;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;
using USER.ACCESSQUERY.REPOSITORY.USER.INTERFACE;

namespace USER.ACCESS.COMMAND.VALIDATION
{
    public class CreateUserValidation : AbstractValidator<UserSignature>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x).NotEmpty().WithMessage(nameof(UserSignature).ToUpperInvariant() + " IS NULL OR EMPTY!");
            RuleFor(x => x.IdSystem).NotEmpty().WithMessage("ID SYSTEM INVALID!");
            RuleFor(x => x.Login).NotEmpty().WithMessage("LOGIN IS NULL!");
            RuleFor(x => x.LoginMustBeTheEmail).Equal(x => x.Login == x.Email).WithMessage("LOGIN AND E-MAIL INVALID!");
            RuleFor(x => x.PhoneObject.IsValid).Equal(true).WithMessage("CELLPHONE INVALID!");
            RuleFor(x => x.EmailObject.IsValid).Equal(true).WithMessage("E-MAIL INVALID!");
            RuleFor(x => x.User).NotEmpty().WithMessage("USER IS NULL!");
        }
    }

    public class DeleteUserValidation : AbstractValidator<DeleteUserSignature>
    {
        public DeleteUserValidation()
        {
            RuleFor(x => x).NotEmpty().WithMessage(nameof(UserSignature).ToUpperInvariant() + " IS NULL OR EMPTY!");
            RuleFor(x => x.IdSystem).NotEmpty().WithMessage("ID SYSTEM INVALID!");
            RuleFor(x => x.Login).NotEmpty().WithMessage("LOGIN IS NULL!");
        }
    }

    public class UpdateUserValidation : AbstractValidator<UserSignature>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x).NotEmpty().WithMessage(nameof(UserSignature).ToUpperInvariant() + " IS NULL OR EMPTY!");
            RuleFor(x => x.IdSystem).NotEmpty().WithMessage("ID SYSTEM INVALID!");
            RuleFor(x => x.Login).NotEmpty().WithMessage("LOGIN IS NULL!");

            RuleFor(x => _userRepository.VerifyActiveUserExists(new User(x)).GetAwaiter().GetResult()).NotEqual(false).WithMessage("USER NOT EXISTS TO UPDATING!");

            RuleFor(x => x.LoginMustBeTheEmail).Equal(x => x.Login == x.Email).WithMessage(" LOGIN AND E-MAIL INVALID!");
            RuleFor(x => x.PhoneObject.IsValid).Equal(true).WithMessage("CELLPHONE INVALID!");
            RuleFor(x => x.EmailObject.IsValid).Equal(true).WithMessage("E-MAIL INVALID!");
            RuleFor(x => x.User).NotEmpty().WithMessage("USER IS NULL!");
        }
    }

    public class UpdateFilledFieldUserValidation : AbstractValidator<UserSignature>
    {
        private readonly IUserRepository _userRepository;

        public UpdateFilledFieldUserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x).NotEmpty().WithMessage(nameof(UserSignature).ToUpperInvariant() + " IS NULL OR EMPTY!");
            RuleFor(x => x.IdSystem).NotEmpty().WithMessage("ID SYSTEM INVALID!");
            RuleFor(x => x.Login).NotEmpty().WithMessage("LOGIN IS NULL!");

            RuleFor(x => _userRepository.VerifyActiveUserExists(new User(x)).GetAwaiter().GetResult()).NotEqual(false).WithMessage("USER NOT EXISTS TO UPDATING!");

            RuleFor(x => x.LoginMustBeTheEmail).Equal(x => x.Login == x.Email).WithMessage("LOGIN AND E-MAIL INVALID!");
            RuleFor(x => string.IsNullOrEmpty(x.Phone) || x.PhoneObject.IsValid).NotEqual(false).WithMessage("CELLPHONE INVALID!");
            RuleFor(x => string.IsNullOrEmpty(x.Email) || x.EmailObject.IsValid).NotEqual(false).WithMessage("E-MAIL INVALID!");
        }
    }
}
