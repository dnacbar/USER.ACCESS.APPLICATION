using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP
{
    public interface ISessionCommandApp
    {
        Task CreateSessionApp(ISessionCommandSignature signature);
        Task DeleteSessionApp(ISessionCommandSignature signature);
    }
}
