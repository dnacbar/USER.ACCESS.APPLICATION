using USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE.QUERY;
using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESSQUERY.REPOSITORY.USER.INTERFACE
{
    public interface IUserRepository
    {
        Task<User> GetActiveUserByFilter(UserQuerySignature signature);
        Task<List<User>> GetListOfActiveUser(UserQuerySignature signature);
        Task<bool> VerifyActiveUserExists(User user);
    }
}
