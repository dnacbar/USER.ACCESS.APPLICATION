namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserSystemSignature
    {
        public Guid IdSystem { get; set; }
        public string System { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
