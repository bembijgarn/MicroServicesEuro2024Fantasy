using Euro2024Stat.WalletAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.WalletAPI.Service
{
    public class WalletService : IWallet
    {
        private readonly WalletContext _db;


        public WalletService(WalletContext db) => _db = db;
        public async Task CreateWallet(string userId, string userName)
        {
            var existingWallet = await _db.Wallet.SingleOrDefaultAsync(x => x.UserID == userId);

            if (existingWallet == null)
            {
                var newWallet = new Wallet()
                {
                    UserID = userId,
                    UserName = userName,
                    Balance = 0,
                };

                _db.Wallet.Add(newWallet);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<decimal> GetBalance(string userId)
        {
            var user = _db.Wallet.SingleOrDefault(x => x.UserID == userId);
            if (user != null)
            {
                decimal Balance = user.Balance;
                return Balance;
            }
            return 0.00m;
        }

        public async Task Deposit(string userId, decimal amount)
        {
            var userwallet = _db.Wallet.SingleOrDefault(y => y.UserID == userId);
            if (userwallet != null)
            {
                userwallet.Balance += amount;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> Withdraw(string userId, decimal amount)
        {
            var userwallet = _db.Wallet.SingleOrDefault(y => y.UserID == userId);
            if (userwallet != null)
            {
                if (userwallet.Balance >= amount)
                {
                    userwallet.Balance -= amount;
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
