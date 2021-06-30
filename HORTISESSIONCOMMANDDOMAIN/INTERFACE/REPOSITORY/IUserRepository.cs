using HORTIUSERCOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task InactiveUser(User user);
        Task UpdateUser(User user);
    }
}