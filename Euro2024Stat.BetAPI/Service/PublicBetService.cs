using Euro2024Stat.BetAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.BetAPI.Service
{
    public class PublicBetService : IPublicBet
    {
        private BetContext _db;

        public PublicBetService(BetContext db)
        {
            _db = db;
        }
      

        public async Task<IEnumerable<BetMatches>> GetAllBettingMatches() => await Task.FromResult(_db.BetMatches);

        public async Task<IEnumerable<Bet>> GetBetsByUserId(string userId) => await _db.Bets.Where(x => x.UserID == userId).ToListAsync();
        

        public async Task<bool> PlaceBet(Bet model)
        {
            try
            {
                if (model != null)
                {
                    model.BetID = Guid.NewGuid().ToString();
                    model.DatePlaced = DateTime.Now;

                    _db.Bets.Add(model);
                    await _db.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }                      
        }
    }
}
