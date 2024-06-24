using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Service
{
    public class AuthService : IAuth
    {
        private readonly IRequestResponse _service;
        public AuthService(IRequestResponse service)
        {
            _service = service;
        }

        public async Task<ResponseDto?> GiveRole(RegisterUserDto registrationRequestDto)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = registrationRequestDto,
                Url = ApiHelper.AuthAPIBase + "/api/Auth/GiveRole"
            });
        }

        public async Task<ResponseDto?> Login(LoginDto registrationRequestDto)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = registrationRequestDto,
                Url = ApiHelper.AuthAPIBase + "/api/Auth/Login"
            });
        }

        public async Task<ResponseDto?> Register(RegisterUserDto registrationRequestDto)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = registrationRequestDto,
                Url = ApiHelper.AuthAPIBase + "/api/Auth/Register"
            });
        }
    }
}
