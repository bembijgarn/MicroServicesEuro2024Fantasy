using Euro2024Stat.AuthAPI.Models.Dto;
using MediatR;

namespace Euro2024Stat.AuthAPI.Commands
{
    public record LoginUserCommand (LoginDto loginDto) : IRequest<LoginResponseDto> 
    {
    }
}
