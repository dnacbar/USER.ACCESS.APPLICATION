using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.APP
{
    public class UserApp : IUserApp
    {
        private readonly IUserRepository _userRepository;

        public UserApp(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateUser(UserSignature signature)
        {
            return _userRepository.CreateUser(new User(signature));
        }

        public Task DeleteUser(DeleteUserSignature signature)
        {
            return _userRepository.DeleteUser(new User(signature));
        }

        public Task UpdateUser(UserSignature signature)
        {
            return _userRepository.UpdateUser(new User(signature));
        }

        public Task UpdateUserOnlyFilledField(UserSignature signature)
        {
            return _userRepository.UpdateUserOnlyFilledField(new User(signature));
        }
    }
}
