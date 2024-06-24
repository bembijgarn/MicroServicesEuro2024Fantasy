using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Service
{
    public class WalletService : IWallet
    {
        private readonly IRequestResponse _service;
        public WalletService(IRequestResponse service)
        {
            _service = service;
        }
        public async Task<ResponseDto> CreateWallet(string userId, string userName)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = ApiHelper.WalletAPIBase + "/api/Wallet/CreateWallet/?userId=" + userId + "&userName=" + userName
            });
        }

       

        public async Task<ResponseDto> GetBalance(string userId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.WalletAPIBase + "/api/Wallet/GetBalance/?userId=" + userId
            });
        }
        public async Task<ResponseDto> Deposit(string userId, decimal amount)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = ApiHelper.WalletAPIBase + "/api/Wallet/Deposit/?userId=" + userId + "&amount=" + amount
            });
        }

        public async Task<ResponseDto> Withdraw(string userId, decimal amount)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = ApiHelper.WalletAPIBase + "/api/Wallet/Withdraw/?userId=" + userId + "&amount=" + amount
            });
        }
    }
}
