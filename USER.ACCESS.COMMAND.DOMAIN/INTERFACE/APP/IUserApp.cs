using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE;

namespace USER.ACCESS.COMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserApp
    {
        Task CreateUser(UserSignature signature);
        Task DeleteUser(DeleteUserSignature signature);
        Task UpdateUser(UserSignature signature);
        Task UpdateUserOnlyFilledField(UserSignature signature);
    }
}
