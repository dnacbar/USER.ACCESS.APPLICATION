using HORTIUSERCOMMAND.DOMAIN.MODEL;
using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIUSERQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class UserQueryResult : IUserQueryResult
    {
        public UserQueryResult(User user)
        {
            Id = user.IdUser;
            Login = user.DsLogin;
            Phone = user.DsPhone;
            IsActive = user.BoActive;
        }

        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }
    }
}
