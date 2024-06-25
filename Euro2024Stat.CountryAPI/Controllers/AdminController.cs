using Euro2024Stat.CountryAPI.Commands;
using Euro2024Stat.CountryAPI.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024Stat.CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }


        [HttpPut]
        [Route("Country/UpdateStatistic")]
        public async Task<ResponseDto> UpdateStatistic (int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            try
            {
                await _mediator.Send(new UpdateStatisticCommand(homeCountryId, awayCountryId, homeGoals, awayGoals));

            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Route("Country/RollBackStatistic")]
        public async Task<ResponseDto> RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            try
            {
                await _mediator.Send(new RollBackStatisticCommand(homeCountryId, awayCountryId, homeGoals, awayGoals));

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
