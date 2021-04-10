namespace HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IUserLogoutQuerySignature
    {
        string IdSession { get; set; }
        string Login { get; set; }
        string Token { get; set; }
    }
}
