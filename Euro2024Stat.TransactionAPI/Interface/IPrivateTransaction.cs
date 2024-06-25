using EURO2024Stat.Domain;

namespace Euro2024Stat.TransactionAPI.Interface
{
    public interface IPrivateTransaction
    {
        Task<IEnumerable<Transactions>> GetAllUserTransactions();
        Task DeleteTransactionById(int transactionId);
    }
}
