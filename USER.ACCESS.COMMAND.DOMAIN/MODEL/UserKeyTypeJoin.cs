namespace USER.ACCESS.COMMAND.DOMAIN.MODEL
{
    public partial class Userkeytypejoin
    {
        public Guid IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public Guid IdUserkeytype { get; set; }
    }
}
