using Flurl;
using Flurl.Http;
using HORTICORE.PROXY.INTERFACE;
using HORTICORE.PROXY.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICORE.PROXY
{
    public sealed class HortiCoreProxy : IHortiCoreProxy
    {
        private const string UrlCoreCommand = @"http://localhost:8000/";

        public async Task<bool> CreateClient(ClientProxySignature signature)
        {
            return (await UrlCoreCommand.AppendPathSegment("Client/CreateClient").PostJsonAsync(signature)).ResponseMessage.IsSuccessStatusCode;
        }
    }
}
