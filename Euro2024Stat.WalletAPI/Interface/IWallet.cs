namespace Euro2024Stat.WalletAPI.Interface
{
    public interface IWallet
    {
        Task CreateWallet(string userId, string userName);
        Task<decimal> GetBalance(string userId);
        Task Deposit(string userId, decimal amount);
        Task <bool>Withdraw(string userId, decimal amount);
    }
}
