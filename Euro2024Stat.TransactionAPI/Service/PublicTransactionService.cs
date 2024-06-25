using Euro2024Stat.TransactionAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;

namespace Euro2024Stat.TransactionAPI.Service
{
    public class PublicTransactionService : IPublicTransaction
    {
        private readonly TransactionContext _db;

        public PublicTransactionService(TransactionContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task CreateTransaction(Transactions model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _db.Transactions.Add(model);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transactions>> GetUserTransactions(string userId) => await Task.FromResult(_db.Transactions.Where(x => x.UserID == userId));
        
    }
}
