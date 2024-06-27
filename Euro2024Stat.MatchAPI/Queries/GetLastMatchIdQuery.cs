using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetLastMatchIdQuery() : IRequest<int>
    {
    }
}
