using HORTI.USER.CROSSCUTTING.CONSTANT;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL
{
    public sealed class UserSession
    {
        public UserSession() { }

        public UserSession(ISessionCommandSignature signature)
        {
            DsLogin = signature.Login;
            IpAddress = signature.IpAddress.ToString();
            BoSessionExpire = signature.SessionExpire;
            DsToken = signature.Token;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DsLogin { get; set; }
        [BsonIgnore]
        public string DsPassword { get; set; }
        [BsonIgnore]
        public bool BoSessionExpire { get; set; }
        public string DsToken { get; set; }
        public string IpAddress { get; set; }
        [BsonRepresentation(BsonType.String)]
        public DateTime DtCreation => DateTime.Now;
        [BsonRepresentation(BsonType.String)]
        public DateTime DtSessionLimit => BoSessionExpire ? DateTime.Now.AddMinutes(Constant.SessionLimit) : DateTime.MaxValue;
    }
}
