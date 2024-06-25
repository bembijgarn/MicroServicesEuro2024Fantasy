using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Queries
{
    public record GetGroupTop3thPlacesQuery(List<int> countryIds) : IRequest<List<Countries>>
    {
    }
}
