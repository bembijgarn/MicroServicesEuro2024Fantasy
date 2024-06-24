using Euro2024Stat.AuthAPI.Models.Dto;
using MediatR;

namespace Euro2024Stat.AuthAPI.Commands
{
    public record RegisterUserCommand(RegisterUserDto registerUserdto) : IRequest<string>
    {
    }
}
