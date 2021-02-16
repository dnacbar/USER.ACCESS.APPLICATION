using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP
{
    public interface ISessionApp
    {
        Task CreateSessionApp(IUserSessionSignature signature);
        Task DeleteSessionApp(IUserSessionSignature signature);
    }
}
