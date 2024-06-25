using EURO2024Stat.Domain;

namespace Euro2024Stat.CountryAPI.Interface
{
    public interface IPrivateCountry
    {
        Task UpdateStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);
        Task RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);
        Task<List<Countries>> GetGroupWinners();
        Task<List<Countries>> GetGroupTop3ThPlace(List<int> countryIds);
    }
}
