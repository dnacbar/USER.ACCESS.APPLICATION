using System.Net;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface ISessionCommandSignature
    {
        string IdSession { get; set; }
        string Login { get; set; }
        string IpAddress { get; set; }
        string Token { get; set; }
        bool SessionExpire { get; set; }
    }
}
