using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.APP
{
    public sealed class SessionCommandApp : ISessionCommandApp
    {
        public SessionCommandApp() { }

        public Task CreateSessionApp(ISessionCommandSignature signature)
        {
            return new Task(null);
        }

        public Task DeleteSessionApp(ISessionCommandSignature signature)
        {
            throw new NotImplementedException();
        }

        private Task UpdateSessionApp(ISessionCommandSignature signature)
        {
            return Task.Run(() => null);
        }
    }
}
