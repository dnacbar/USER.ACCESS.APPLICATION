using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface ISessionCommandService
    {
        Task<ICreatedSessionCommandResult> CreateSessionService(ISessionCommandSignature signature);
        Task DeleteSessionService(string idSession);
    }
}
