namespace Euro2024Stat.CountryAPI.Interface
{
    public interface IPrivateCountry
    {
        Task UpdateStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);
        Task RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);
    }
}
