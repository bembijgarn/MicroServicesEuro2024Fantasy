﻿using Euro2024Stat.MatchAPI.Commands;
using Euro2024Stat.PlayerAPI.Models.Dto;
using EURO2024Stat.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024Stat.MatchAPI.Controllers
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
        [Route("Match/UpdateMatchResult")]
        public async Task<ResponseDto> UpdateMatchResult(int matchId, [FromBody] MatchResults model)
        {
            try
            {
                 await _mediator.Send(new EditMatchResultCommand(matchId, model));
                 return _response;

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Route("Match/FinishMatch")]
        public async Task<ResponseDto> FinishMatch(int matchId)
        {
            try
            {
                await _mediator.Send(new FinishMatchCommand(matchId));
                return _response;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Route("Match/ResetMatch")]
        public async Task<ResponseDto> ResetMatch(int matchId)
        {
            try
            {
                await _mediator.Send(new ResetMatchCommand(matchId));
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