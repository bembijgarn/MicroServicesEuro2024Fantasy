using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IAuth
    {
        Task<ResponseDto?> Register(RegisterUserDto registrationRequestDto);
        Task<ResponseDto?> GiveRole(RegisterUserDto registrationRequestDto);
        Task<ResponseDto?> Login(LoginDto registrationRequestDto);

    }
}
