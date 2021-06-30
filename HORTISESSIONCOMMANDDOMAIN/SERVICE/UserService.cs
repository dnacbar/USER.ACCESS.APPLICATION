using HORTI.CORE.CROSSCUTTING.ENCRYPTING;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.SERVICE
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userCommandRepository;
        public UserService(IUserRepository userCommandRepository)
        {
            _userCommandRepository = userCommandRepository;
        }

        public Task CreateUser(User user)
        {
            user.DsPassword = user.DsPassword.ToEncryptPasswordText();
            return _userCommandRepository.CreateUser(user);
        }

        public Task InactiveUser(User user)
        {
            return _userCommandRepository.InactiveUser(user);
        }

        public Task UpdateUser(User user)
        {
            user.DsPassword = user.DsPassword.ToEncryptPasswordText();
            return _userCommandRepository.UpdateUser(user);
        }
    }
}
