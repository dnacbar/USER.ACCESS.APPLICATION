using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.APP;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.APP
{
    public sealed class UserAccessQueryApp : IUserAccessQueryApp
    {
        private readonly ISessionCommandService _sessionCommandService;
        private readonly IUserAccessQueryService _userAccessQueryService;

        public UserAccessQueryApp(ISessionCommandService sessionCommandService,
                                  IUserAccessQueryService userAccessQueryService)
        {
            _sessionCommandService = sessionCommandService;
            _userAccessQueryService = userAccessQueryService;
        }

        public async Task<IUserAccessQueryResult> AuthenticateUserAccess(IUserAccessQuerySignature signature)
        {
            var taskUserAccess = _userAccessQueryService.AuthenticateUserAccess(signature);
            var taskCreatedSession = _sessionCommandService.CreateSessionService(new SessionCommandSignature
            {
                Login = signature.Login,
                IpAddress = signature.IpAddress
            });

            var userAccessResult = await taskUserAccess;
            if (userAccessResult == null)
                return null;

            var createdSessionResult = await taskCreatedSession;
            if (createdSessionResult == null || string.IsNullOrEmpty(createdSessionResult.IdSession))
                return null;

            userAccessResult.IdSession = createdSessionResult.IdSession;

            return userAccessResult;
        }
    }
}
