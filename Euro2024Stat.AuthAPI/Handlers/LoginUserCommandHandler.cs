using Euro2024Stat.AuthAPI.Commands;
using Euro2024Stat.AuthAPI.Interface;
using Euro2024Stat.AuthAPI.Models.Dto;
using MediatR;

namespace Euro2024Stat.AuthAPI.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IAuth _authService;
        public LoginUserCommandHandler(IAuth authService) => _authService = authService;
        public Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var Response = _authService.Login(request.loginDto);
            return Response;
        }
    }
}
