using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Query
{
    public record GetBetsByUserIdQuery(string userId) : IRequest<IEnumerable<Bet>>
    {
    }
}
