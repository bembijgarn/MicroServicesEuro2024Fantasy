using Euro2024Stat.TransactionAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.TransactionAPI.Service
{
    public class PrivateTransactionService : IPrivateTransaction
    {
        private readonly TransactionContext _db;

        public PrivateTransactionService(TransactionContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

		public async Task DeleteTransactionById(int transactionId)
		{
            var transaction = await _db.Transactions.SingleOrDefaultAsync(x => x.ID == transactionId);
            if (transaction != null)
            {
                _db.Transactions.Remove(transaction);
                await _db.SaveChangesAsync();
            }
		}

		public async Task<IEnumerable<Transactions>> GetAllUserTransactions() => await Task.FromResult(_db.Transactions);
        
    }
}
