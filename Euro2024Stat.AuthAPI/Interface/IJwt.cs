using EURO2024Stat.Domain;

namespace Euro2024Stat.AuthAPI.Interface
{
    public interface IJwt
    {
        string GenerateToken(User applicationUser, IEnumerable<string> roles);
    }
}
