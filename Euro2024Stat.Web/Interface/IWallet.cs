using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IWallet
    {
        Task<ResponseDto> CreateWallet(string userId, string userName);
        Task<ResponseDto> GetBalance(string userId);
        Task<ResponseDto> Deposit(string userId, decimal amount);
        Task<ResponseDto> Withdraw(string userId, decimal amount);

    }
}
