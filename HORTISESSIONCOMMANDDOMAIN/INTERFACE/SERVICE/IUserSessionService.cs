using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserSessionService
    {
        Task<ICreatedSessionCommandResult> CreateSessionService(IUserSessionCommandSignature signature);
        Task DeleteSessionService(IUserSessionCommandSignature signature);
    }
}
