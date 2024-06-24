using MediatR;

namespace Euro2024Stat.AuthAPI.Commands
{
    public record GiveRoleToUserCommand(string Email, string Role) : IRequest<bool>
    {
    }
}
