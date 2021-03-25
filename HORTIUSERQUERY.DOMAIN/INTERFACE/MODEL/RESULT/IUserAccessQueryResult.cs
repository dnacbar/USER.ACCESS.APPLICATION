namespace HORTIUSERQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IUserAccessQueryResult
    {
        string IdSession { get; set; }
        string Login { get; }
        string Token { get; }
    }
}
