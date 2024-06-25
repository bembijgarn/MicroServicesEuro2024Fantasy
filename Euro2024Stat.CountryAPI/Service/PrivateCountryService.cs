using Euro2024Stat.CountryAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Euro2024Stat.CountryAPI.Service
{
    public class PrivateCountryService : IPrivateCountry
    {
        private readonly CountryContext _db;
        public PrivateCountryService(CountryContext db) => _db = db;

        public async Task<List<Countries>> GetGroupTop3ThPlace(List<int> countryIds)
        {
            
            var top3ThCountries = await _db.Countries
                .Where(c => !countryIds.Contains(c.ID))
                .OrderByDescending(c => c.Point)
                .ThenByDescending(c => c.GoalsFor - c.GoalsAgainst)
                .Take(4) 
                .ToListAsync();

            return top3ThCountries;
        }

        public async Task<List<Countries>> GetGroupWinners()
		{
			List<char> Groups = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F' };
			var groupWinnerCountries = new List<Countries>();

			foreach (var group in Groups)
			{
				var winners = await _db.Countries
									   .Where(c => c.Group == group && c.Matches == 3)
									   .OrderByDescending(c => c.Point) 
									   .ThenByDescending(c => c.GoalsFor - c.GoalsAgainst)
									   .Take(2)
									   .ToListAsync();

				groupWinnerCountries.AddRange(winners);
			}

			return groupWinnerCountries;
		}


		public async Task RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            var homecountry = await _db.Countries.FirstOrDefaultAsync(x => x.ID == homeCountryId);
            var awaycountry = await _db.Countries.FirstOrDefaultAsync(x => x.ID == awayCountryId);

            if (homecountry != null && awaycountry != null)
            {
                homecountry.Matches -= 1;
                awaycountry.Matches -= 1;

                homecountry.GoalsFor -= homeGoals;
                awaycountry.GoalsFor -= awayGoals;

                homecountry.GoalsAgainst -= awayGoals;
                awaycountry.GoalsAgainst -= homeGoals;

                if (homeGoals > awayGoals)
                {
                    homecountry.Point -= 3;
                }else if (homeGoals == awayGoals)
                {
                    homecountry.Point -= 1;
                    awaycountry.Point -= 1;
                }else
                {
                    awaycountry.Point -= 3;
                }
               await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            var homecountry = await _db.Countries.FirstOrDefaultAsync(x => x.ID == homeCountryId);
            var awaycountry = await _db.Countries.FirstOrDefaultAsync(x => x.ID == awayCountryId);

            if (homecountry != null && awaycountry != null)
            {
                homecountry.Matches += 1;
                awaycountry.Matches += 1;

                homecountry.GoalsFor += homeGoals;
                homecountry.GoalsAgainst += awayGoals;

                awaycountry.GoalsFor += awayGoals;
                awaycountry.GoalsAgainst += homeGoals;

                if (homeGoals > awayGoals)
                {
                    homecountry.Point += 3;
                }else if (homeGoals == awayGoals) {
                    homecountry.Point += 1;
                    awaycountry.Point += 1;
                }else
                {
                    awaycountry.Point += 3;
                }
                await _db.SaveChangesAsync();
            }

        }
    }
}
