using USER.ACCESS.COMMAND.DOMAIN.MODEL;

namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.RESULT.QUERY
{
    public sealed class UserQueryResult
    {
        public UserQueryResult()
        {
        }
        public UserQueryResult(User user)
        {
            Id = user.IdSystem;
            Login = user.DsLogin;
            Email = user.DsEmail;
            User = user.DsUser;
            Phone = user.DsPhone;
            Active = user.BoActive.GetValueOrDefault();
        }

        public Guid? Id { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string User { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Active { get; set; }
    }

    public static class UserQueryResultExtension
    {
        public static HashSet<UserQueryResult> ListOfUserExtension(this List<User> listOfUser)
        {
            var result = new HashSet<UserQueryResult>();
            foreach (var user in listOfUser)
            {
               result.Add(new UserQueryResult(user));
            }  
            return result;
        }
    }
}
