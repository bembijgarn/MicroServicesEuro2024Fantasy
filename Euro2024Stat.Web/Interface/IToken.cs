namespace Euro2024Stat.Web.Interface
{
    public interface IToken
    {
        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
