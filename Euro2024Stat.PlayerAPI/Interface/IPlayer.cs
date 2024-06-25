using Euro2024Stat.PlayerAPI.Models.Dto;
using EURO2024Stat.Domain;

namespace Euro2024Stat.PlayerAPI.Interface
{
    public interface IPlayer
    {
         Task<IEnumerable<Player>> GetAllPlayer();
         Task<Player> GetPlayerById(int Id);
         Task<IEnumerable<Player>> GetPlayerByCountryId(int CountryId);
        Task<IEnumerable<Player>> GetPlayersByPlayerIds(List<FantasyPlayerDto> playerDto);


    }
}
