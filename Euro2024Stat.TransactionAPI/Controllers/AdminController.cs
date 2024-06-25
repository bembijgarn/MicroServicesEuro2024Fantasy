using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Euro2024Stat.TransactionAPI.Models.Dto;
using Euro2024Stat.TransactionAPI.Query;
using Euro2024Stat.TransactionAPI.Command;
using Microsoft.AspNetCore.Authorization;

namespace Euro2024Stat.TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;


        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();

        }

        [HttpGet]
        [Route("Transaction/GetAllUserTransactions")]
        public async Task<ResponseDto> GetAllUserTransactions()
        {
            try
            {
                var transactions = await _mediator.Send(new GetAllUserTransactionsQuery());
                _response.Result = transactions;

            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

		[HttpPost]
		[Route("Transaction/DeleteTransactionById")]
		public async Task<ResponseDto> DeleteTransactionById(int transactionId)
		{
			try
			{
				var transactions = await _mediator.Send(new DeleteTransactonByIdCommand(transactionId));
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

	}
}
