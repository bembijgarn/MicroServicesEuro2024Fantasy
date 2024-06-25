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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("SellPlayer")]
        public async Task<ResponseDto> SellPlayer(string userId, int playerId)
        {
            try
            {
                await _mediator.Send(new SellPlayerCommand(userId, playerId));
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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetTeamIdByUserId")]
        public async Task<ResponseDto> GetTeamIdByUserId(string userId)
        {
            try
            {
                int TeamId = await _mediator.Send(new GetTeamIdByUserIdQuery(userId));
                _response.Result = TeamId;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetFantasyPlayers")]
        public async Task<ResponseDto> GetFantasyPlayers(string userId)
        {
            try
            {
                var Fantasyplayers = await _mediator.Send(new GetPlayerIdsQuery(userId));
                _response.Result = Fantasyplayers;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("CreateMatchResult")]
        public async Task<ResponseDto> CreateMatchResult(int teamId, string result)
        {
            try
            {
                await _mediator.Send(new CreateMatchResultCommand(teamId, result));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetFantasyMatchResultsByTeamId")]
        public async Task<ResponseDto> GetFantasyMatchResultsByTeamId(int teamId)
        {
            try
            {
               var fantasyMatchResults =  await _mediator.Send(new GetMatchResultsByTeamIdQuery(teamId));
                _response.Result = fantasyMatchResults;
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
