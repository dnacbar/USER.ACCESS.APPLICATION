using HORTICORE.PROXY.INTERFACE;
using HORTICORE.PROXY.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.APP
{
    public sealed class UserCommandApp : IUserCommandApp
    {
        private readonly DBHORTIUSERCONTEXT _DBHORTIUSERCONTEXT;
        private readonly IConfiguration _configuration;
        private readonly IHortiCoreProxy _hortiCoreProxy;
        private readonly IUserCommandService _userCommandService;

        public UserCommandApp(DBHORTIUSERCONTEXT DBHORTIUSERCONTEXT,
                            IConfiguration configuration,
                            IHortiCoreProxy hortiCoreProxy,
                            IUserCommandService userCommandService)
        {
            _DBHORTIUSERCONTEXT = DBHORTIUSERCONTEXT;
            _configuration = configuration;
            _hortiCoreProxy = hortiCoreProxy;
            _userCommandService = userCommandService;

        }

        public async Task CreateUser(ICreateUserCommandSignature signature)
        {
            using var hortiUserTran = _DBHORTIUSERCONTEXT.Database.BeginTransaction();

            await _userCommandService.CreateUser(new User(signature));

            if (await _hortiCoreProxy.CreateClient(new ClientProxySignature(signature)))
                hortiUserTran.Commit();
            else
                hortiUserTran.Rollback();
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
