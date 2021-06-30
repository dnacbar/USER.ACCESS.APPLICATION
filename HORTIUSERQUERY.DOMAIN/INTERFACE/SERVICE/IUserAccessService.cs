using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserAccessService
    {
        Task<IUserAccessQueryResult> AuthenticateUserAccess(IUserAccessQuerySignature signature);
        Task LogoutUserAccess(IUserLogoutQuerySignature signature);
    }
}
