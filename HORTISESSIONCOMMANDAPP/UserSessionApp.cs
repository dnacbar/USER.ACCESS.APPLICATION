using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.APP
{
    public sealed class UserSessionApp : IUserSessionApp
    {
        public UserSessionApp() { }

        public Task CreateSessionApp(IUserSessionCommandSignature signature)
        {
            return new Task(null);
        }

        public Task DeleteSessionApp(IUserSessionCommandSignature signature)
        {
            throw new NotImplementedException();
        }

        private Task UpdateSessionApp(IUserSessionCommandSignature signature)
        {
            return Task.Run(() => null);
        }
    }
}
