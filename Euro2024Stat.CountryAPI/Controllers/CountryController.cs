using Euro2024Stat.CountryAPI.Queries;
using Euro2024Stat.PlayerAPI.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024Stat.CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseDto _response;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }
        [HttpGet]
        [Route("GetCountries")]
        public async Task<ResponseDto> GetAllCountry()
        {
            try
            {
                var Countries = await _mediator.Send(new GetAllCountriesQuery());
                _response.Result = Countries;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetCountryById")]
        [Authorize]
        public async Task<ResponseDto> GetCountryById(int Id)
        {
            try
            {
                var Country = await _mediator.Send(new GetCountryByIdQuery(Id));
                _response.Result = Country;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            
            return _response;
        }

        [HttpGet]
        [Route("GetCountriesByGroup")]
        public async Task<ResponseDto> GetCountriesByGroup(char Group)
        {
            try
            {
                var Countries = await _mediator.Send(new GetCountriesByGroupQuery(Group));
                _response.Result = Countries;
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
