using Euro2024Stat.CountryAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.CountryAPI.Service
{
    public class PublicCountryService : IPublicCountry
    {
        private readonly CountryContext _db;

        public PublicCountryService(CountryContext db) => _db = db;
        public async Task<IEnumerable<Countries>> GetAllCountry() => await Task.FromResult(_db.Countries);

        public async Task<IEnumerable<Countries>> GetCountriesByGroup(char Group) => await Task.FromResult(_db.Countries.Where(x => x.Group == Group));
       

        public async Task<Countries> GetCountryById(int Id)
        {
            var Country = await _db.Countries.FirstOrDefaultAsync(x => x.ID == Id);
            return Country;
        }
    }
}
