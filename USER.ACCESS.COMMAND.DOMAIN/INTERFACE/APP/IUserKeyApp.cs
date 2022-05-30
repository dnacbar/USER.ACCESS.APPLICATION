using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;
using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserKeyApp
    {
        Task CreateUserKey(UserKeySignature signature);
        Task DeleteUserKey(DeleteUserKeySignature signature);
        Task UpdateUserKey(UserKeySignature signature);
    }
}
