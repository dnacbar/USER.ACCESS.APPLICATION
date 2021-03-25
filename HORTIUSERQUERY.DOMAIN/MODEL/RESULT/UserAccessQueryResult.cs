using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;

namespace HORTIUSERQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class UserAccessQueryResult : IUserAccessQueryResult
    {
        public UserAccessQueryResult(string strLogin, string strToken)
        {
            Login = strLogin;
            Token = strToken;
        }

        public string IdSession { get; set; }
        public string Login { get; private set; }
        public string Token { get; private set; }
    }
}
