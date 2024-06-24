using Euro2024Stat.AuthAPI.Commands;
using Euro2024Stat.AuthAPI.Interface;
using MediatR;

namespace Euro2024Stat.AuthAPI.Handlers
{
    public class GiveRoleToUserCommandHandler : IRequestHandler<GiveRoleToUserCommand, bool>
    {
        private readonly IAuth _authService;
        public GiveRoleToUserCommandHandler(IAuth authService) => _authService = authService;
        public Task<bool> Handle(GiveRoleToUserCommand request, CancellationToken cancellationToken) => _authService.GiveRole(request.Email, request.Role);
       
    }
}
