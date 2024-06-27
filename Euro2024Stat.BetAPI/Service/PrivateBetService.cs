using Euro2024Stat.BetAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.BetAPI.Service
{
    public class PrivateBetService : IPrivateBet
    {

        private BetContext _db;

        public PrivateBetService(BetContext db)
        {
            _db = db;
        }

        public async Task AddPlayoffBetMatch(BetMatches model)
        {
            if(model != null)
            {
                model.HomeCoefficient = GetRandomCoefficient();
                model.DrawCoefficient = GetRandomCoefficient(2.80m, 4.00m);
                model.AwayCoefficient = GetRandomCoefficient();

                _db.BetMatches.Add(model);
                await _db.SaveChangesAsync();

            }
        }

        private decimal GetRandomCoefficient(decimal min = 1.20m, decimal max = 12.00m)
        {
            Random random = new Random();
            double range = (double)(max - min);
            double sample = random.NextDouble();
            double scaled = (sample * range) + (double)min;
            return Math.Round((decimal)scaled, 2);
        }

        public async Task FinishBetMatch(int matchId)
        {
            var match = await _db.BetMatches.SingleOrDefaultAsync(x => x.MatchId == matchId);
            if (match != null)
            {
                match.isFinished = true;

                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Bet>> GetAllUserSportBets() => await Task.FromResult(_db.Bets);

        public async Task RollbackBetMatch(int matchId)
        {
            var match = await _db.BetMatches.SingleOrDefaultAsync(x => x.MatchId == matchId);
            if (match != null)
            {
                match.isFinished = false;

                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateBetStatus(string betId, string betStatus)
		{
            try
            {
				var bet = await _db.Bets.SingleOrDefaultAsync(x => x.BetID == betId);
				if (bet != null)
				{
					bet.BetStatus = betStatus;

					await _db.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception ex)
            {
                return false;
            }
           
		}
	}
}
