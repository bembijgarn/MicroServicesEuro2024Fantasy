using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Commands
{
    public record CreatePlayOffMatchCommand(Matches model) : IRequest<Unit>
    {
    }
}
