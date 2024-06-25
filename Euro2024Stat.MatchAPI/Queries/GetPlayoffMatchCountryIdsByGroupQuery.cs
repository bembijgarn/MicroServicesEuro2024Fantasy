using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetPlayoffMatchCountryIdsByGroupQuery(string group) : IRequest<List<int>>
    {
    }
}
