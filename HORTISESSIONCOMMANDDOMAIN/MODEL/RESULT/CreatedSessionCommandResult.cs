using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL.RESULT
{
    public sealed class CreatedSessionCommandResult : ICreatedSessionCommandResult
    {
        public CreatedSessionCommandResult(UserSession userSession)
        {
            IdSession = userSession.Id;
            SessionExpire = userSession.BoSessionExpire;
            SessionLimit = userSession.DtSessionLimit;
            Login = userSession.DsLogin;
        }

        public string IdSession { get; set; }
        public bool SessionExpire { get; set; }
        public DateTime SessionLimit { get; set; }
        public string Login { get; set; }
    }
}
