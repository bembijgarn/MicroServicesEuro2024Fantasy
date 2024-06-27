using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Command
{
    public record AddPlayoffBetMatchCommand(BetMatches model) : IRequest<Unit>
    {
    }
}
