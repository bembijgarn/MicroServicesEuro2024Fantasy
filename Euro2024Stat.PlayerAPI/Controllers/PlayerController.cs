using Euro2024Stat.PlayerAPI.Models.Dto;
using Euro2024Stat.PlayerAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Euro2024Stat.PlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;


        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();

        }

        [HttpGet]
        public async Task<ResponseDto> GetAllPlayer()
        {
            try
            {
                var Players = await _mediator.Send(new GetAllPlayerQuery()) ?? null;
                _response.Result = Players;             
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
           
        }

        [HttpGet]
        [Route("GetPlayerById")]
        public async Task<ResponseDto> GetPlayerById(int Id)
        {
            try
            {
                var Player = await _mediator.Send(new GetPlayerByIdQuery(Id));
                _response.Result = Player;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetPlayersByCountryId")]
        public async Task<ResponseDto> GetPlayersByCountryId(int CountryId)
        {
            try
            {
                var Player = await _mediator.Send(new GetPlayersByCountryIdQuery(CountryId));
                _response.Result = Player;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("GetPlayersByIds")]
        public async Task<ResponseDto> GetPlayersByIds(List<FantasyPlayerDto> playerIds)
        {
            try
            {
                var Player = await _mediator.Send(new GetPlayersByIdsQuery(playerIds));
                _response.Result = Player;

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
