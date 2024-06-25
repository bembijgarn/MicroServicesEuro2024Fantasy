using Euro2024Stat.MatchAPI.Queries;
using Euro2024Stat.MatchAPI.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using EURO2024Stat.Domain;
using Euro2024Stat.MatchAPI.Commands;

namespace Euro2024Stat.MatchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class MatchController : ControllerBase
	{
		private readonly IMediator _mediator;
		private ResponseDto _response;

		public MatchController(IMediator mediator)
		{
			_mediator = mediator;
			_response = new ResponseDto();
		}

		[HttpGet]
		[Route("GetAllMatches")]
		public async Task<ResponseDto> GetAllMatches ()
		{
			try
			{
				var Matches = await _mediator.Send(new GetAllMatchQuery());
				_response.Result = Matches;

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;

			
		}

		[HttpGet]
		[Route("GetAllMatchesByCountryId")]
		public async Task<ResponseDto> GetAllMatchesByCountryId(int countryId)
		{
			try
			{
				var Matches = await _mediator.Send(new GetAllMatchByCountryIdQuery(countryId));
				_response.Result = Matches;

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;

			
		}

        [HttpGet]
        [Route("GetMatchesWithResults")]
        public async Task<ResponseDto> GetMatchesWithResults()
        {
            try
            {
                var Matches = await _mediator.Send(new GetMatchesWithResultsQuery());
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    
                };

                
                var json = JsonSerializer.Serialize(Matches, options);
                _response.Result = json;

            }
            catch (Exception ex)
            {
				_response.IsSuccess = false;
				_response.Message = ex.Message;
            }
			return _response;
		}

        [HttpGet]
        [Route("GetGroupMatchResultsByGroupId")]
        public async Task<ResponseDto> GetGroupMatchResultsByGroupId(string groupId)
        {
            try
            {
                var Matches = await _mediator.Send(new GetAllGroupMatchWithResultBygroupIdQuery(groupId));
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                };


                var json = JsonSerializer.Serialize(Matches, options);
                _response.Result = json;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetAllGroupMatchByGroupId")]
        public async Task<ResponseDto> GetAllGroupMatchByGroupId(string groupId)
        {
            try
            {
                var Matches = await _mediator.Send(new GetAllGroupMatchByGroupIdQuery(groupId));
                _response.Result = Matches;

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
