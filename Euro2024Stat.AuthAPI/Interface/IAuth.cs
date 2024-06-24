using Euro2024Stat.AuthAPI.Models.Dto;

namespace Euro2024Stat.AuthAPI.Interface
{
    public interface IAuth
    {
        Task<string> Register(RegisterUserDto user);
        Task<LoginResponseDto> Login(LoginDto user);
        Task<bool> GiveRole(string email, string role);
    }
}
