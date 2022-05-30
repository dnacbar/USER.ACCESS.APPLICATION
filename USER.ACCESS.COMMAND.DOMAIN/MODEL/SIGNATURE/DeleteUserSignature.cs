namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DeleteUserSignature
    {
        public Guid IdSystem { get; set; }
        public string Login { get; set; } = null!;
        public bool Active => false;
    }
}
