using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize(Roles = ApiHelper.RoleAdmin)]
    public class AdminEntitiesController : Controller
    {
        private readonly IMatch _matchService;
        private readonly ICountry _countryService;


        public AdminEntitiesController (IMatch matchService, ICountry countryService)
        {         
            _matchService = matchService;
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> EditMatch(int matchId, int homeId, int awayId)
        {
            ViewBag.Home = homeId;
            ViewBag.away = awayId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditMatch(int matchId, int homeId, int awayId ,MatchResultDto model)
        {

            ResponseDto? responseDto = await _matchService.EditMatchResult(matchId, model);
            ResponseDto? responseDtoStatistic = await _countryService.UpdateStatistic(homeId, awayId, model.HomeScore, model.AwayScore);

            return RedirectToAction("MatchResults", "Match");
        }

        [HttpPost]
        public async Task<IActionResult> ResetMatch(int matchId, int homeCountryId, int awayCountryId, int homeScore, int awayScore)
        {
            ResponseDto? responseDto = await _matchService.ResetMatch(matchId);
            ResponseDto? rollbackResponseDto = await _countryService.RollBackStatistic(homeCountryId, awayCountryId, homeScore, awayScore);

            return RedirectToAction("MatchResults", "Match");
        }

        [HttpPost]
        public async Task<IActionResult> FinishMatch(int matchId)
        {
            ResponseDto? responseDto = await _matchService.FinishMatch(matchId);

            return RedirectToAction("MatchResults", "Match");
        }
    }
}
