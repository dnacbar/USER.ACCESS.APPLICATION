namespace USER.ACCESS.COMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class DeleteUserSystemSignature
    {
        public Guid IdSystem { get; set; }
        public string Login { get; set; } = null!;
        public bool Active => false;
    }
}
