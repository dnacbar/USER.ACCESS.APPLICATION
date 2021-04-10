using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserLogoutQuerySignature : IUserLogoutQuerySignature
    {
        public string IdSession { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
