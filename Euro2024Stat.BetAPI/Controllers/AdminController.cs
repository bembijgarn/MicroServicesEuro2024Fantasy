using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Euro2024Stat.BetAPI.Models.Dto;
using System.Runtime.CompilerServices;
using Euro2024Stat.BetAPI.Query;
using Euro2024Stat.BetAPI.Command;
using EURO2024Stat.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Euro2024Stat.BetAPI.Controllers
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
        [Route("Bet/GetAllUserSportBets")]
        public async Task<ResponseDto> GetAllUserSportBets()
        {
            try
            {
                var usersSportBets = await _mediator.Send(new GetAllUserSportBetsQUery());
                _response.Result = usersSportBets;

            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

		[HttpPost]
		[Route("Bet/UpdateUserBetStatus")]
		public async Task<ResponseDto> UpdateUserBetStatus(string betId, string betStatus)
		{
			try
			{
				var isUpdated = await _mediator.Send(new UpdateBetStatusCommand(betId, betStatus));
				_response.Result = isUpdated;

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

        [HttpPost]
        [Route("Bet/FinishBetMatch")]
        public async Task<ResponseDto> FinishBetMatch(int matchId)
        {
            try
            {
                await _mediator.Send(new FinishBetMatchCommand(matchId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("Bet/RollbackBetMatch")]
        public async Task<ResponseDto> RollbackBetMatch(int matchId)
        {
            try
            {
                await _mediator.Send(new RollbackBetMatchCommand(matchId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("Bet/AddPlayoffBetMatch")]
        public async Task<ResponseDto> AddPlayoffBetMatch(BetMatches model)
        {
            try
            {
                await _mediator.Send(new AddPlayoffBetMatchCommand(model));
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
