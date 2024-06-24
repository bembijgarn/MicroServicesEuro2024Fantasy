using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize]
    public class FantasyController : Controller
    {
        private readonly IFantasy _fantasyService;
        private readonly IPlayer _playerService;
        public FantasyController(IFantasy fantasyService, IPlayer playerService)
        {
            _fantasyService = fantasyService;
            _playerService = playerService;
        }

        public async Task<IActionResult> Index()
        {
            
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _fantasyService.HaveUserFantasy(userId);
            ViewBag.HasTeam = (bool)response.Result;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(FantasyTeamDto model)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            model.UserId = userId;
            ResponseDto? responseDto = await _fantasyService.CreateFantasyTeam(model);
            TempData["success"] = "Team  Created Successful";


            return View(model); 
        }
        [HttpGet]
        public async Task<IActionResult> BuyPlayer(int playerId)
        {
            PlayerDto player = new PlayerDto();
            ResponseDto? responseDto = await _playerService.GetPlayerById(playerId);
            ApiHelper.APIGetDeserializedobject(responseDto, out player);
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> BuyPlayer(int playerId, decimal amount, string playerName)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? responseDto = await _fantasyService.BuyPlayer(userId, playerId, playerName);

            //TODO : wallet balance!!!
            return RedirectToAction("Index","Country");
        }
    }
}
