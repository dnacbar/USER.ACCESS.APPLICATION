using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Text.Json.Serialization;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class SessionCommandSignature : ISessionCommandSignature
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public string IdSession { get; set; }
        public bool SessionExpire { get; set; }
        [JsonIgnore]
        public string IpAddress { get; set; }
    }
}