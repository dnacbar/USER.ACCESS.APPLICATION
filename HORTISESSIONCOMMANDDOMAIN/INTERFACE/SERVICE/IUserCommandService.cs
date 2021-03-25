using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserCommandService
    {
        Task CreateUser(User user);
        Task InactiveUser(User user);
        Task UpdateUser(User user);
    }
}
