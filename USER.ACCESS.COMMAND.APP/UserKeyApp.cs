using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.APP
{
    public class UserKeyApp : IUserKeyApp
    {
        private readonly IUserKeyRepository _userKeyRepository;

        public UserKeyApp(IUserKeyRepository userKeyRepository)
        {
            _userKeyRepository = userKeyRepository;
        }

        public Task CreateUserKey(UserKeySignature signature)
        {
            return _userKeyRepository.CreateUserKey(new Userkey(signature));
        }

        public Task DeleteUserKey(DeleteUserKeySignature signature)
        {
            return _userKeyRepository.DeleteUserKey(new Userkey(signature));
        }

        public Task UpdateUserKey(UserKeySignature signature)
        {
            return _userKeyRepository.UpdateUserKey(new Userkey(signature));
        }
    }
}
