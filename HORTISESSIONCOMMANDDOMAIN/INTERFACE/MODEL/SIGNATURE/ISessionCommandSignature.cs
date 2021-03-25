using System.Net;

namespace HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface ISessionCommandSignature
    {
        string Login { get; set; }
        bool SessionExpire { get; set; }
        string IpAddress { get; set; }
    }
}
