using Euro2024Stat.MatchAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.MatchAPI.Service
{
    public class PrivateMatchService : IPrivateMatch
    {
        private readonly MatchContext _db;
        public PrivateMatchService(MatchContext db) => _db = db;


        public async Task EditMatchResult(int matchId, MatchResults model)
        {
            var match = await _db.Matches.Include(m => m.MatchResults).FirstOrDefaultAsync(m => m.ID == matchId);
            if (match != null)
            {
                match.IsFinished = true;

                match.MatchResults.HomeScore = model.HomeScore;
                match.MatchResults.AwayScore = model.AwayScore;

                await _db.SaveChangesAsync();
            }
        }

        public async Task ResetMatch(int matchId)
        {
            var match = await _db.Matches.Include(x => x.MatchResults).FirstOrDefaultAsync(s => s.ID == matchId);
            if (match != null)
            {
                match.IsFinished = false;
                match.MatchResults.HomeScore = 0;
                match.MatchResults.AwayScore = 0;

                await _db.SaveChangesAsync();
            }
        }

        public async Task FinishMatch(int matchId)
        {
            var match = await _db.Matches.FirstOrDefaultAsync(x => x.ID == matchId);
            
            if (match != null)
            {
                match.IsFinished = true;
                await _db.SaveChangesAsync();
            }
        }

       

      
    }
}
