using MediatR;

namespace Euro2024Stat.FantasyAPI.Query
{
    public record HaveUserFantasyQuery(string userId) : IRequest<bool>
    {
    }
}
