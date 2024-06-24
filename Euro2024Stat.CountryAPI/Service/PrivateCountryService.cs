using Euro2024Stat.CountryAPI.Interface;
using EURO2024Stat.DATA;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.CountryAPI.Service
{
    public class PrivateCountryService : IPrivateCountry
    {
        private readonly CountryContext _db;
        public PrivateCountryService(CountryContext db) => _db = db;

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
