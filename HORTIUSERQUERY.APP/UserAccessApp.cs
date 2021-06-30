using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.APP;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.APP
{
    public sealed class UserAccessApp : IUserAccessApp
    {
        private readonly HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE.IUserSessionService _sessionCommandService;
        private readonly IUserAccessService _userAccessQueryService;

        public UserAccessApp(HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE.IUserSessionService sessionCommandService,
                                  IUserAccessService userAccessQueryService)
        {
            _sessionCommandService = sessionCommandService;
            _userAccessQueryService = userAccessQueryService;
        }

        public async Task<IUserAccessQueryResult> AuthenticateUserAccess(IUserAccessQuerySignature signature)
        {
            var userAccessResult = await _userAccessQueryService.AuthenticateUserAccess(signature);

            var createdSessionResult = await _sessionCommandService.CreateSessionService(new UserSessionCommandSignature
            {
                Token = userAccessResult.Token,
                Login = signature.Login,
                IpAddress = signature.IpAddress
            });

            if (createdSessionResult == null || string.IsNullOrEmpty(createdSessionResult.IdSession))
                return null;

            userAccessResult.IdSession = createdSessionResult.IdSession;

            return userAccessResult;
        }

        public async Task LogoutUserAccess(IUserLogoutQuerySignature signature)
        {
            await _sessionCommandService.DeleteSessionService(new UserSessionCommandSignature
            {
                Token = signature.Token,
                Login = signature.Login,
                IdSession = signature.IdSession
            });
        }
    }
}
