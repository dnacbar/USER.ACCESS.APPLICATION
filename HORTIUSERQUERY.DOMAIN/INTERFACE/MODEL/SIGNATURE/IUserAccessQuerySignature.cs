using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;

namespace HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IUserAccessQuerySignature
    {
        string Login { get; set; }
        string Password { get; set; }
        bool IsProducer { get; set; }
        bool SessionExpire { get; set; }
        string IpAddress { get; set; }

        EmailObject EmailObject { get; }
        PasswordObject PasswordObject { get; }
    }
}
