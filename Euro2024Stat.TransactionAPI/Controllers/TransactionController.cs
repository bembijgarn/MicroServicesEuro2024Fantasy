using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Euro2024Stat.TransactionAPI.Models.Dto;
using EURO2024Stat.Domain;
using Euro2024Stat.TransactionAPI.Command;
using Euro2024Stat.TransactionAPI.Query;
using Microsoft.AspNetCore.Authorization;

namespace Euro2024Stat.TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;


        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();

        }


        [HttpPost]
        [Route("CreateTransaction")]
        public async Task<ResponseDto> CreateTransaction(Transactions model)
        {
            try
            {
               await _mediator.Send(new CreateTransactionCommand(model));
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetUserTransactions")]
        public async Task<ResponseDto> GetUserTransactions(string userId)
        {
            try
            {
                var userTransactions = await _mediator.Send(new GetUserTransactionsQuery(userId));
                _response.Result = userTransactions;
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
