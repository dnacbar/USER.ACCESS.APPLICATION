namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DeleteUserKeySignature
    {
        public Guid IdSystem { get; set; }
        public string Login { get; set; } = null!;
        public bool Active => false;
    }
}
