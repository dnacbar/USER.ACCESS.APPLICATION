using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERCOMMAND.DOMAIN.MODEL.RESULT;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.SERVICE
{
    public sealed class UserSessionService : IUserSessionService
    {
        private readonly IUserSessionRepository _sessionCommandRepository;
        public UserSessionService(IUserSessionRepository sessionCommandRepository)
        {
            _sessionCommandRepository = sessionCommandRepository;
        }

        public async Task<ICreatedSessionCommandResult> CreateSessionService(IUserSessionCommandSignature signature)
        {
            return new CreatedSessionCommandResult(await _sessionCommandRepository.CreateSessionAsync(new UserSession(signature)));
        }

        public Task DeleteSessionService(IUserSessionCommandSignature signature)
        {
            return _sessionCommandRepository.DeleteSessionAsync(new UserSession(signature));
        }
    }
}
