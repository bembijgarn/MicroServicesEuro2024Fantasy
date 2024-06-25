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
        private readonly ITransaction _transactionService;


        public AdminEntitiesController(IMatch matchService, ICountry countryService, ITransaction transactionService)
        {
            _matchService = matchService;
            _countryService = countryService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> EditMatch(int matchId, int homeId, int awayId, string group)
        {
            ViewBag.Home = homeId;
            ViewBag.away = awayId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditMatch(int matchId, int homeId, int awayId, MatchResultDto model, string group)
        {

            ResponseDto? responseDto = await _matchService.EditMatchResult(matchId, model);
            if (isGroupMatch(group))
            {
                await _countryService.UpdateStatistic(homeId, awayId, model.HomeScore, model.AwayScore);
            }

            return RedirectToAction("MatchResults", "Match");
        }

        [HttpPost]
        public async Task<IActionResult> ResetMatch(int matchId, int homeCountryId, int awayCountryId, int homeScore, int awayScore, string groupId)
        {
            await _matchService.ResetMatch(matchId);
            if (isGroupMatch(groupId))
            {
				await _countryService.RollBackStatistic(homeCountryId, awayCountryId, homeScore, awayScore);

			}

            return RedirectToAction("MatchResults", "Match");
        }

        [HttpPost]
        public async Task<IActionResult> FinishMatch(int matchId)
        {
             await _matchService.FinishMatch(matchId);

            return RedirectToAction("MatchResults", "Match");
        }

        [HttpGet]
        public async Task<IActionResult> UsersTransactions()
        {
            var userTransactions = new List<TransactionDto>();

            ResponseDto? responseTransactionsDto = await _transactionService.GetAllUserTransactions();
            ApiHelper.APIGetDeserializedList(responseTransactionsDto, out userTransactions);

            return View(userTransactions);
        }

        public async Task<IActionResult> DeleteTransaction(int transactionId)
        {

            await _transactionService.DeleteTransactionById(transactionId);
            return RedirectToAction(nameof(UsersTransactions));
        }

        [HttpGet]
        public async Task<IActionResult> ManagePlayoffs()
        {

            #region Round8
            var groupWinnerCountries = new List<Countrydto>();

            ResponseDto? groupWinners = await _countryService.GetGroupWinnerCountries();
            ApiHelper.APIGetDeserializedList(groupWinners, out groupWinnerCountries);

            List<int> topTwelveCountries = groupWinnerCountries.Select(c => c.ID).ToList();
            ResponseDto? top3thCountriesResponseDto = await _countryService.GetTop3thPlaces(topTwelveCountries);
            var top3thGroupWinners = new List<Countrydto>();
            ApiHelper.APIGetDeserializedList(top3thCountriesResponseDto, out top3thGroupWinners);

            groupWinnerCountries.AddRange(top3thGroupWinners);

            var Round8countryIds = new List<int>();
            ResponseDto? Round8CountryIdResponse = await _matchService.GetPlayoffCountryIdsByGroup(ApiHelper.PlayoffType.round8.ToString());
            ApiHelper.APIGetDeserializedList(Round8CountryIdResponse, out Round8countryIds);

            groupWinnerCountries = groupWinnerCountries
            .Where(country => !Round8countryIds.Contains(country.ID))
            .ToList();


            ViewBag.Round8Teams = groupWinnerCountries;

            #endregion

            #region Round4
          
            var Round4Teams = await PlayoffHelper(ApiHelper.PlayoffType.round8, ApiHelper.PlayoffType.round4);
            ViewBag.Round4Teams = Round4Teams;

            #endregion

            #region Round2

            var Round2Teams = await PlayoffHelper(ApiHelper.PlayoffType.round4, ApiHelper.PlayoffType.round2);
            ViewBag.Round2Teams = Round2Teams;

            #endregion

            #region Final

            var FinalTeams = await PlayoffHelper(ApiHelper.PlayoffType.round2, ApiHelper.PlayoffType.final);
            ViewBag.FinalTeams = FinalTeams;

            #endregion
            
            return View();
        }

        private async Task<List<Countrydto>> PlayoffHelper(ApiHelper.PlayoffType winnerType, ApiHelper.PlayoffType coupledType)
        {
            var Teams = new List<Countrydto>();

            var winnerTeamIds = new List<int>();
            ResponseDto? winnerTeamIdsResponse = await _matchService.GetPlayoffWinnerTeamIds(winnerType.ToString());
            ApiHelper.APIGetDeserializedList(winnerTeamIdsResponse, out winnerTeamIds);


            ResponseDto? countriesResponseDto = await _countryService.GetAllCountry();
            ApiHelper.APIGetDeserializedList(countriesResponseDto, out Teams);

            Teams = Teams.Where(c => winnerTeamIds.Contains(c.ID)).ToList();

            var RoundcountryIds = new List<int>();
            ResponseDto? RoundCountryIdResponse = await _matchService.GetPlayoffCountryIdsByGroup(coupledType.ToString());
            ApiHelper.APIGetDeserializedList(RoundCountryIdResponse, out RoundcountryIds);

            Teams = Teams.Where(x => !RoundcountryIds.Contains(x.ID)).ToList();


            return Teams;
        }

        [HttpPost]
        public async Task<IActionResult> AddMatch(PlayoffMatchDto model)
        {
            await _matchService.CreatePlayOffMatch(model);

            return RedirectToAction(nameof(ManagePlayoffs));
        }

        #region HELPERS

        private bool isGroupMatch(string group)
        {
            var validGroups = new HashSet<string> { "A", "B", "C", "D", "E", "F" };

            if (validGroups.Contains(group))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion

    }
}
