using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserSystemApp
    {
        Task CreateUserSystem(UserSystemSignature signature);
        Task DeleteUserSystem(DeleteUserSystemSignature signature);
        Task UpdateUserSystem(UserSystemSignature signature);
    }
}
