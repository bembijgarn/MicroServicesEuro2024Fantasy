using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using System.Reflection;

namespace Euro2024Stat.Web.Service
{
    public class TransactionService : ITransaction
    {
        private readonly IRequestResponse _service;
        public TransactionService(IRequestResponse service)
        {
            _service = service;
        }


        public async Task<ResponseDto?> CreateTransaction(TransactionDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = model,
                Url = ApiHelper.TransactionApiBase + "/api/Transaction/CreateTransaction"
            });
        }

		public async Task<ResponseDto?> DeleteTransactionById(int transactionId)
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.POST,
				Url = ApiHelper.TransactionApiBase + "/api/Admin/Transaction/DeleteTransactionById?transactionId=" + transactionId
			}); ;
		}

		public async  Task<ResponseDto?> GetAllUserTransactions()
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.TransactionApiBase + "/api/Admin/Transaction/GetAllUserTransactions"
            }); ;
        }

        public async Task<ResponseDto?> GetUserTransactions(string userId)
        {

            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.TransactionApiBase + "/api/Transaction/GetUserTransactions?userId=" + userId
            });
        }
    }
}
