using HORTICORE.PROXY.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICORE.PROXY.INTERFACE
{
    public interface IHortiCoreProxy
    {
        Task<bool> CreateClient(ClientProxySignature signature);
    }
}
