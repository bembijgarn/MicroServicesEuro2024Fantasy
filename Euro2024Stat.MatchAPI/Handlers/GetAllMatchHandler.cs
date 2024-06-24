using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
	public class GetAllMatchHandler : IRequestHandler<GetAllMatchQuery, IEnumerable<Matches>>
	{
		private readonly IPublicMatch _matchService;
		public GetAllMatchHandler(IPublicMatch matchService) => _matchService = matchService;
		public Task<IEnumerable<Matches>> Handle(GetAllMatchQuery request, CancellationToken cancellationToken)
		{
			var Matches = _matchService.GetAllMatch();
			return Matches;
		}
	}
}
