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
        private readonly IBet _betService;
        private readonly IWallet _walletService;


        public AdminEntitiesController(IMatch matchService, ICountry countryService, ITransaction transactionService, IBet betService, IWallet waleltService)
        {
            _matchService = matchService;
            _countryService = countryService;
            _transactionService = transactionService;
            _betService = betService;
            _walletService = waleltService;
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
            await _betService.RollbackBetMatch(matchId);
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
             await _betService.FinishBetMatch(matchId);

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

       

        [HttpPost]
        public async Task<IActionResult> AddMatch(PlayoffMatchDto model)
        {
            await _matchService.CreatePlayOffMatch(model);
            int lastMatchId;
            ResponseDto? lastMatchIdResponse = await _matchService.GetLastMatchId();
            ApiHelper.APIGetDeserializedobject(lastMatchIdResponse, out lastMatchId);



            var betmachDto = new BetMatchesDto()
            {
                MatchId = lastMatchId,
                HomeCountryId = model.homeCountryId,
                HomeCountryName = await GetPlayoffBetCountryNames(model.homeCountryId),
                AwayCountryId = model.awayCountryId,
                AwayCountryName = await GetPlayoffBetCountryNames(model.awayCountryId),

            };

            await _betService.AddPlayoffBetMatch(betmachDto);

            return RedirectToAction(nameof(ManagePlayoffs));
        }

        private  async Task<string> GetPlayoffBetCountryNames(int countryId)
        {
            string countryName = string.Empty;
            var Country = new Countrydto();
            ResponseDto? Response = await _countryService.GetCountryById(countryId);
            ApiHelper.APIGetDeserializedobject(Response, out Country);

            return Country.CountryName;
        }

        [HttpPost]
        public async Task<IActionResult> WinSportTicket (string betId, string userId, decimal coef, decimal betAmount)
        {
            ResponseDto? UpdateUserBetTicketResponse = await _betService.UpdateUserBetStatus(betId, ApiHelper.SportBetStatus.Win.ToString());
            bool isSuccessUpdate = (bool)UpdateUserBetTicketResponse.Result;

            if (isSuccessUpdate)
            {
                var winAmount = betAmount * coef;
				await _walletService.Deposit(userId, winAmount); //SportWin
				await _transactionService.CreateTransaction(new TransactionDto(userId, "SportWin", ApiHelper.TranType.SportBet.ToString(), winAmount));
			}
            
            return RedirectToAction("AdminManageBettingTickets", "Bet");
        }


		[HttpPost]
		public async Task<IActionResult> LossSportTicket(string betId, string userId, decimal betAmount)
		{
			ResponseDto? UpdateUserBetTicketResponse = await _betService.UpdateUserBetStatus(betId, ApiHelper.SportBetStatus.Loss.ToString());
			bool isSuccessUpdate = (bool)UpdateUserBetTicketResponse.Result;

			if (isSuccessUpdate)
			{
				await _transactionService.CreateTransaction(new TransactionDto(userId, "SportLose", ApiHelper.TranType.SportBet.ToString(), betAmount));
			}

			return RedirectToAction("AdminManageBettingTickets", "Bet");
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


        #endregion

    }
}
