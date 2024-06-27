using Euro2024Stat.BetAPI.Command;
using Euro2024Stat.BetAPI.Interface;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
	public class UpdateBetStatusCommandHandler : IRequestHandler<UpdateBetStatusCommand, bool>
	{
		private readonly IPrivateBet _betService;

		public UpdateBetStatusCommandHandler(IPrivateBet betService)
		{
			_betService = betService;
		}

		public async Task<bool> Handle(UpdateBetStatusCommand request, CancellationToken cancellationToken) => await _betService.UpdateBetStatus(request.betId, request.betStatus);
		
	}
}
