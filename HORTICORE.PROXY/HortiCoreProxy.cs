using Flurl;
using Flurl.Http;
using HORTI.USER.CROSSCUTTING.HELPER;
using HORTICORE.PROXY.INTERFACE;
using HORTICORE.PROXY.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICORE.PROXY
{
    public sealed class HortiCoreProxy : IHortiCoreProxy
    {
        public async Task<bool> CreateClient(ClientProxySignature signature)
        {
            return (await HelperUrl.UrlCoreCommand.AppendPathSegment("Client/CreateClient").PostJsonAsync(signature)).ResponseMessage.IsSuccessStatusCode;
        }
    }
}
