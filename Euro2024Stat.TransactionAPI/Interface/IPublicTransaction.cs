using EURO2024Stat.Domain;
namespace Euro2024Stat.TransactionAPI.Interface
{
    public interface IPublicTransaction
    {
        Task CreateTransaction(Transactions model);
        Task <IEnumerable<Transactions>> GetUserTransactions(string userId);
    }
}
