using Euro2024Stat.AuthAPI.Commands;
using Euro2024Stat.AuthAPI.Interface;
using MediatR;

namespace Euro2024Stat.AuthAPI.Handlers
{
    public class RegisterUserCommandHanlder : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuth _authService;
        public RegisterUserCommandHanlder(IAuth authService) => _authService = authService;
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Register(request.registerUserdto);
            return result;

        }
    }
}
