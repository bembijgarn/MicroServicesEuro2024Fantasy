using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Euro2024Stat.FantasyAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using EURO2024Stat.Domain;
using Euro2024Stat.FantasyAPI.Command;
using Euro2024Stat.FantasyAPI.Query;

namespace Euro2024Stat.FantasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FantasyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;

        public FantasyController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }


        [HttpPost]
        [Route("CreateTeam")]
        public async Task<ResponseDto> CreateTeam(FantasyTeam model)
        {
            try
            {
                await _mediator.Send(new CreateTeamCommand(model));
                return _response;
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("BuyPlayer")]
        public async Task<ResponseDto> BuyPlayer(string userId, int playerId, string playerName)
        {
            try
            {
                await _mediator.Send(new BuyPlayerCommand(userId, playerId, playerName));
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("HaveUserFantasy")]
        public async Task<ResponseDto> HaveUserFantasy(string userId)
        {
            try
            {
                bool haveuserFantasy = await _mediator.Send(new HaveUserFantasyQuery(userId));
                _response.Result = haveuserFantasy;
                return _response;
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
