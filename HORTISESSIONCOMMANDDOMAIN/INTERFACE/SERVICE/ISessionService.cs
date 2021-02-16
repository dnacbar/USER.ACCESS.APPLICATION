using HORTIUSERCOMMAND.DOMAIN.DOMAIN;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface ISessionService
    {
        Task CreateSessionService(UserSession userSession);
        Task DeleteSessionService(UserSession userSession);
    }
}
