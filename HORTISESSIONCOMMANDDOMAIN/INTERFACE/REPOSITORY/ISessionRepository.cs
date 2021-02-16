using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface ISessionRepository
    {
        Task CreateSessionAsync(UserSession userSession);
        Task<UserSession> GetSessionAsync();
    }
}