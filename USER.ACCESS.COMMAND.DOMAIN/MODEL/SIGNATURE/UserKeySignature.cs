namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserKeySignature
    {
        public Guid IdSystem { get; set; }
        public string Login { get; set; } = null!;
        public string Key { get; set; } = null!;
    }
}
