using Euro2024Stat.AuthAPI.Commands;
using Euro2024Stat.AuthAPI.Models.Dto;
using Euro2024Stat.AuthAPI.Service;
using EURO2024Stat.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024Stat.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;



        private ResponseDto _response;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDto();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var loginResponse = await _mediator.Send(new LoginUserCommand(model));
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {

            var errorMessage = await _mediator.Send(new RegisterUserCommand(model));
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response); 
            }
            return Ok(_response);
        }

        [HttpPost("GiveRole")]
        public async Task<IActionResult> GiveRole([FromBody] RegisterUserDto model)
        {
            var assignRoleSuccessful = await _mediator.Send(new GiveRoleToUserCommand(model.Email, model.Role.ToUpper()));
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);

        }
    }
}
