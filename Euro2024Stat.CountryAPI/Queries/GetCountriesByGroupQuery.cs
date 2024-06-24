using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Queries
{
    public record GetCountriesByGroupQuery(char Group) : IRequest<IEnumerable<Countries>>
    {
    }
}
