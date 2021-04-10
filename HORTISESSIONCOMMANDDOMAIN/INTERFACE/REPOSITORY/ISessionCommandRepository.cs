using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface ISessionCommandRepository
    {
        Task<UserSession> CreateSessionAsync(UserSession userSession);
        Task DeleteSessionAsync(UserSession userSession);
    }
}