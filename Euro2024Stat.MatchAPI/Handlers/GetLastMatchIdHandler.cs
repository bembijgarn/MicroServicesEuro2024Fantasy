using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetLastMatchIdHandler : IRequestHandler<GetLastMatchIdQuery, int>
    {
        private readonly IPrivateMatch _matchService;

        public GetLastMatchIdHandler(IPrivateMatch matchService)
        {
            _matchService = matchService;
        }

        public async Task<int> Handle(GetLastMatchIdQuery request, CancellationToken cancellationToken)
        {
            var lastMatchId = await _matchService.GetLastMatchId();
            return lastMatchId;
        }
    }
}
