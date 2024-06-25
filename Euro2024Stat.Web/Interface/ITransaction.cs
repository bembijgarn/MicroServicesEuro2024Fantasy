using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface ITransaction
    {
        Task<ResponseDto?> CreateTransaction(TransactionDto model);
        Task<ResponseDto?> GetUserTransactions(string userId);
        Task<ResponseDto?> GetAllUserTransactions();
		Task<ResponseDto?> DeleteTransactionById(int transactionId);



	}
}
