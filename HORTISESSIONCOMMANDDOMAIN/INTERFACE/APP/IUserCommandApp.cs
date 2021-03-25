using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserCommandApp
    {
        Task CreateUser(ICreateUserCommandSignature signature);
        Task InactiveUser(IDeleteUserCommandSignature signature);
        Task UpdateUser(IUpdateUserCommandSignature signature);
    }
}
