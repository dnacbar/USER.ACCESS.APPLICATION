using HORTI.CORE.CROSSCUTTING.EXCEPTION;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERQUERY.DOMAIN.MODEL.EXTENSION;
using HORTIUSERQUERY.DOMAIN.MODEL.RESULT;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.SERVICE
{
    public sealed class UserAccessQueryService : IUserAccessQueryService
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public UserAccessQueryService(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<IUserAccessQueryResult> AuthenticateUserAccess(IUserAccessQuerySignature signature)
        {
            if (!await _userQueryRepository.VerifyUserExists(signature.ToUser()))
                throw new NotFoundException();

            return new UserAccessQueryResult(signature.Login, JwtTokenQueryService.GenerateToken(signature.ToUserSession()));
        }

        public async Task LogoutUserAccess(IUserLogoutQuerySignature signature)
        {
            if (true)
            {

            }
        }
    }
}
