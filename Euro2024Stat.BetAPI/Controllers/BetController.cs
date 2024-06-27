using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Euro2024Stat.BetAPI.Models.Dto;
using Euro2024Stat.BetAPI.Query;
using EURO2024Stat.Domain;
using Euro2024Stat.BetAPI.Command;
using Microsoft.AspNetCore.Authorization;

namespace Euro2024Stat.BetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class BetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;

        public BetController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }


        [HttpGet]
        [Route("GetAllBetMatches")]
        public async Task<ResponseDto> GetAllBetMatches()
        {
            try
            {
                var allBettingMatches = await _mediator.Send(new GetAllBettingMatchesQuery());
                _response.Result = allBettingMatches;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("PlaceBet")]
        public async Task<ResponseDto> PlaceBet(Bet model)
        {
            try
            {
               var isBetSuccess = await _mediator.Send(new PlaceBetCommand(model));
                _response.Result = isBetSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetUserBetsByUserId")]
        public async Task<ResponseDto> GetUserBetsByUserId(string userid)
        {
            try
            {
                var userBets = await _mediator.Send(new GetBetsByUserIdQuery(userid));
                _response.Result = userBets;
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
