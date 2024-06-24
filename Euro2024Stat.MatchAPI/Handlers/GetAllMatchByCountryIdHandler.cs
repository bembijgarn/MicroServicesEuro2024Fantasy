using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
	public class GetAllMatchByCountryIdHandler : IRequestHandler<GetAllMatchByCountryIdQuery, IEnumerable<Matches>>
	{
		private readonly IPublicMatch _matchService;
		public GetAllMatchByCountryIdHandler(IPublicMatch matchService) => _matchService = matchService;

		public Task<IEnumerable<Matches>> Handle(GetAllMatchByCountryIdQuery request, CancellationToken cancellationToken)
		{
			var Matches = _matchService.GetAllMatchByCountryId(request.countryId);
			return Matches;
		}
	}
}
