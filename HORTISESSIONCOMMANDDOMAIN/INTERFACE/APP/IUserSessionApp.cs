using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserSessionApp
    {
        Task CreateSessionApp(IUserSessionCommandSignature signature);
        Task DeleteSessionApp(IUserSessionCommandSignature signature);
    }
}
