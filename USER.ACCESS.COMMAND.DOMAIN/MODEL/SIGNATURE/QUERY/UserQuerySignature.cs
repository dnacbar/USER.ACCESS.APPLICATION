namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE.QUERY
{
    public sealed class UserQuerySignature : _BaseQuerySignature
    {
        public Guid IdSystem { get; set; }
        public string? DsLogin { get; set; }
        public string? DsEmail { get; set; }
        public string? DsUser { get; set; }

    }
}
