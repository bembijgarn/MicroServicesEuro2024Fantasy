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

        public async Task CreatePlayOffMatch(Matches model)
        {
            if (model != null)
            {
                var Matchresults = new MatchResults()
                {
                    HomeScore = 0,
                    AwayScore = 0,
                };
                model.MatchResults = Matchresults;
                _db.Matches.Add(model);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<int>> GetPlayoffMatchCountryIds(string group)
        {
            var homeCountryIds = await _db.Matches
                                        .Where(m => m.Group == group)
                                        .Select(m => m.HomeCountryID)
                                        .Distinct()
                                        .ToListAsync();

            var awayCountryIds = await _db.Matches
                                        .Where(m => m.Group == group)
                                        .Select(m => m.AwayCountryID)
                                        .Distinct()
                                        .ToListAsync();

            var countryIds = homeCountryIds.Union(awayCountryIds).ToList();

            return countryIds;
        }

        public async Task<List<int>> GetPlayoffTeamIds(string group)
        {
            var winningCountryIds = await _db.Matches
               .Where(m => m.MatchResults != null && m.MatchResults.HomeScore != m.MatchResults.AwayScore && m.Group == group)
               .Select(m => m.MatchResults.HomeScore > m.MatchResults.AwayScore ? m.HomeCountryID : m.AwayCountryID)
               .ToListAsync();

            return winningCountryIds;
        }

        public async Task<int> GetWinnerTeamId(string group)
        {

            var winnerTeamId = await _db.Matches
                       .Where(m => m.MatchResults != null && m.MatchResults.HomeScore != m.MatchResults.AwayScore && m.Group == group)
                       .Select(m => m.MatchResults.HomeScore > m.MatchResults.AwayScore ? m.HomeCountryID : m.AwayCountryID)
                       .FirstOrDefaultAsync();
            return winnerTeamId;

        }

        public async Task<int> GetLastMatchId() => await _db.Matches.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefaultAsync();
        
    }
}
