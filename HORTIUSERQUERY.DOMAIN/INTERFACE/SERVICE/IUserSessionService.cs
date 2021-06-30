using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserSessionService
    {
        Task<bool> GetUserSession(UserSession userSession);
    }
}
