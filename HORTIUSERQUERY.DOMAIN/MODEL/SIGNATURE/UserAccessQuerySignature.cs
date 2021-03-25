using HORTI.CORE.CROSSCUTTING.DOMAINOBJECT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Text.Json.Serialization;

namespace HORTIUSERQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class UserAccessQuerySignature : IUserAccessQuerySignature
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsProducer { get; set; }
        public bool SessionExpire { get; set; }
        
        [JsonIgnore]
        public string IpAddress { get; set; }
        [JsonIgnore]
        public EmailObject EmailObject => new EmailObject(Login);
        [JsonIgnore]
        public PasswordObject PasswordObject => new PasswordObject(Password);
    }
}
