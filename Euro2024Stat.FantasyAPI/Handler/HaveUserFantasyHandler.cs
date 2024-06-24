using Euro2024Stat.FantasyAPI.Interface;
using Euro2024Stat.FantasyAPI.Query;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class HaveUserFantasyHandler : IRequestHandler<HaveUserFantasyQuery, bool>
    {

        private readonly IPublicFantasy _fantasyService;

        public HaveUserFantasyHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public async Task<bool> Handle(HaveUserFantasyQuery request, CancellationToken cancellationToken) => await _fantasyService.HaveUserFantasy(request.userId);
        
    }
}
