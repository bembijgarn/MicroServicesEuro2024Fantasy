using EURO2024Stat.Domain;

namespace Euro2024Stat.CountryAPI.Interface
{
    public interface IPublicCountry
    {
        Task<IEnumerable<Countries>> GetAllCountry();
        Task<Countries> GetCountryById(int Id);
        Task<IEnumerable<Countries>> GetCountriesByGroup(char Group);
    }
}
