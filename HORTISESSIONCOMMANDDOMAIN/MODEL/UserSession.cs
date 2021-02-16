using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Net;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL
{
    public sealed class UserSession
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string IpAddress { get; set; }
        public DateTime SessionLimit { get; set; }
        public bool SessionExpire { get; set; }    


        public static UserSession ToUserSession(IUserSessionSignature signature)
        {
            return new UserSession
            {
                IdUser = signature.IdUser.ToString(),
                IpAddress = signature.ToString(),
                SessionLimit = signature.SessionLimit,
                SessionExpire = signature.SessionExpire
            };
        }
    }
}
