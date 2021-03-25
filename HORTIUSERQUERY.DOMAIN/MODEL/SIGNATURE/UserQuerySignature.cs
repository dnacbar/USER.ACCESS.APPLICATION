using HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;

namespace HORTIUSERQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserQuerySignature : _BaseQuantityQuerySignature, IUserQuerySignature
    {
        public bool IsActive { get; set; }
    }
}
