using MediatR;

namespace Euro2024Stat.BetAPI.Command
{
	public record UpdateBetStatusCommand(string betId, string betStatus) : IRequest<bool>
	{
	}
}
