using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
	public record GetAllMatchByCountryIdQuery(int countryId) : IRequest<IEnumerable<Matches>>
	{
	}
}
