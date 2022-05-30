using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP;
using USER.ACCESS.COMMAND.DOMAIN.INTERFACE.REPOSITORY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.APP
{
    public class UserSystemApp : IUserSystemApp
    {
        private readonly IUserSystemRepository _userSystemRepository;

        public UserSystemApp(IUserSystemRepository userSystemRepository)
        {
            _userSystemRepository = userSystemRepository;
        }

        public Task CreateUserSystem(UserSystemSignature signature)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserSystem(DeleteUserSystemSignature signature)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserSystem(UserSystemSignature signature)
        {
            throw new NotImplementedException();
        }
    }
}
