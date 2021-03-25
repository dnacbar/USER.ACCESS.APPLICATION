using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserQueryRepository
    {
        Task<bool> VerifyUserExists(User user);
        Task<List<User>> ListOfUser(User signature);    
    }
}
