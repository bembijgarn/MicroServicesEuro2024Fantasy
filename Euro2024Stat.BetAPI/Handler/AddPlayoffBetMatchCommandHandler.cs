using Euro2024Stat.BetAPI.Command;
using Euro2024Stat.BetAPI.Interface;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class AddPlayoffBetMatchCommandHandler : IRequestHandler<AddPlayoffBetMatchCommand, Unit>
    {
        private readonly IPrivateBet _betService;

        public AddPlayoffBetMatchCommandHandler(IPrivateBet betService)
        {
            _betService = betService;
        }

        public async Task<Unit> Handle(AddPlayoffBetMatchCommand request, CancellationToken cancellationToken)
        {
            await _betService.AddPlayoffBetMatch(request.model);
            return Unit.Value;
        }
    }
}
