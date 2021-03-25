using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIUSERQUERY.DOMAIN.MODEL.RESULT;
using System.Collections.Generic;

namespace HORTIUSERQUERY.DOMAIN.MODEL.EXTENSION
{
    public static class UserQueryExtension
    {
        public static IEnumerable<IUserQueryResult> ToListOfUserResult(this IEnumerable<User> listOfUser)
        {
            foreach (var item in listOfUser)
                yield return new UserQueryResult(item);
        }

        public static User ToUser(this IUserQuerySignature signature)
        {
            return new User
            {
                Page = signature.Page.GetValueOrDefault(),
                Quantity = signature.Quantity.GetValueOrDefault(),
                BoActive = signature.IsActive
            };
        }
        public static User ToUser(this IUserAccessQuerySignature signature)
        {
            return new User
            {
                DsLogin = signature.Login,
                DsPassword = signature.Password,
                BoActive = true                
            };
        }
    }
}
