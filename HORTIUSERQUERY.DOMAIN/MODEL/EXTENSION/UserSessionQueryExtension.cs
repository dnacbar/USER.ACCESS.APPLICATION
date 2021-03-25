using HORTI.USER.CROSSCUTTING.CONSTANT;
using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTIUSERQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class UserSessionQueryExtension
    {
        public static UserSession ToUserSession(this IUserAccessQuerySignature signature)
        {
            return new UserSession
            {
                DsLogin = signature.Login,
                DsPassword = signature.Password,
                BoSessionExpire = signature.SessionExpire
            };
        }
    }
}
