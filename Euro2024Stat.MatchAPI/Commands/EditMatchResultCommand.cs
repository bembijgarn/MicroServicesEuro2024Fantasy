using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Commands
{
    public record EditMatchResultCommand(int matchId,MatchResults model) :  IRequest<Unit>
    {
    }
}
