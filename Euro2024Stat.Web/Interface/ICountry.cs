using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface ICountry
    {
        Task<ResponseDto?> GetAllCountry();
        Task<ResponseDto?> GetCountryById(int Id);
        Task<ResponseDto?> GetCountriesByGroup(char group);
        Task<ResponseDto?> UpdateStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);
        Task<ResponseDto?> RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals);

    }
}
