using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Queries
{
	public record GetGroupWinnerCountriesQuery : IRequest<List<Countries>>
	{
	}
}
