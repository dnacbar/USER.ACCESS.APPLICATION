using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERCOMMAND.DOMAIN.MODEL.RESULT;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.SERVICE
{
    public sealed class SessionCommandService : ISessionCommandService
    {
        private readonly ISessionCommandRepository _sessionCommandRepository;
        public SessionCommandService(ISessionCommandRepository sessionCommandRepository)
        {
            _sessionCommandRepository = sessionCommandRepository;
        }

        public async Task<ICreatedSessionCommandResult> CreateSessionService(ISessionCommandSignature signature)
        {
            return new CreatedSessionCommandResult(await _sessionCommandRepository.CreateSessionAsync(new UserSession(signature)));
        }

        public Task DeleteSessionService(string idSession)
        {
            return _sessionCommandRepository.DeleteSessionAsync(idSession);
        }
    }
}
