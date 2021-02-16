using HORTIUSERCOMMAND.DOMAIN.INTERFACE.APP;
using HORTIUSERCOMMAND.DOMAIN.INTERFACE.SIGNATURE;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HORTIUSERCOMMAND.APP
{
    public sealed class SessionApp : ISessionApp
    {
        public SessionApp() { }

        public async Task CreateSessionApp(IUserSessionSignature signature)
        {

        }

        public Task DeleteSessionApp(IUserSessionSignature signature)
        {
            throw new NotImplementedException();
        }

        private async Task UpdateSessionApp(IUserSessionSignature signature)
        {
            await Task.Run(() => null);
        }
    }
}
