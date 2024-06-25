using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Euro2024Stat.WalletAPI.Models.Dto;
using Euro2024Stat.WalletAPI.Command;
using Euro2024Stat.WalletAPI.Query;
using Microsoft.AspNetCore.Authorization;

namespace Euro2024Stat.WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;



        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }

        [HttpPost]
        [Route("CreateWallet")]
        public async Task<ResponseDto> CreateWallet(string userId, string userName)
        {
            try
            {
                await _mediator.Send(new CreateWalletCommand(userId, userName));
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetBalance")]
        public async Task<ResponseDto> GetBalance(string userId)
        {
            try
            {
               var Balance  = await _mediator.Send(new GetBalanceQuery(userId));
               _response.Result = Balance;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("Deposit")]
        public async Task<ResponseDto> Deposit (string userId, decimal amount)
        {
            try
            {
                await _mediator.Send(new DepositCommand(userId, amount));
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("Withdraw")]
        public async Task<ResponseDto> Withdraw(string userId, decimal amount)
        {
            try
            {
                bool isSuccess = await _mediator.Send(new WithdrawCommand(userId, amount));
                _response.Result= isSuccess;
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
