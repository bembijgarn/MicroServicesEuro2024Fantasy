using Euro2024Stat.MatchAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Euro2024Stat.MatchAPI.Service
{
	public class PublicMatchService : IPublicMatch
	{
		private readonly MatchContext _db;
		public PublicMatchService(MatchContext db) => _db = db;

        public async Task<IEnumerable<Matches>> GetAllGroupMatchByGroupId(string group) => await Task.FromResult(_db.Matches.Where(x => x.Group == group && !x.IsFinished));      

        public async Task<IEnumerable<Matches>> GetAllMatch() => await Task.FromResult(_db.Matches.Where(x => !x.IsFinished));

		public async Task<IEnumerable<Matches>> GetAllMatchByCountryId(int countryId) => await Task.FromResult(_db.Matches.Where(x => x.HomeCountryID == countryId || x.AwayCountryID == countryId));

        public async Task<IEnumerable<Matches>> GetMatchesWithResults()
        {
            var matchesWithResults = await _db.Matches
                           .Include(m => m.MatchResults)
                           .Where(x => x.IsFinished)
                           .ToListAsync();

            return matchesWithResults;
        }

        public async Task<IEnumerable<Matches>> GetAllGroupMatchWithResultByGroupId(string groupId)
        {
            var groupMatchesWithResults = await _db.Matches
                          .Include(m => m.MatchResults)
                          .Where(x => x.Group == groupId &&  x.IsFinished)
                          .ToListAsync();

            return groupMatchesWithResults;
        }





    }
}
