using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.APP
{
    public sealed class UserCommandApp : IUserCommandApp
    {
        private readonly IUserCommandService _userCommandService;
        public UserCommandApp(IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
        }

        public Task CreateUser(ICreateUserCommandSignature signature)
        {
            return  _userCommandService.CreateUser(new User(signature));
        }

        public Task InactiveUser(IDeleteUserCommandSignature signature)
        {
            return _userCommandService.InactiveUser(new User(signature));
        }

        public Task UpdateUser(IUpdateUserCommandSignature signature)
        {
            return _userCommandService.UpdateUser(new User(signature));
        }
    }
}
