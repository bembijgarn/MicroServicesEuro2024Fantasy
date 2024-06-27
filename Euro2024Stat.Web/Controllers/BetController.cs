using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Euro2024Stat.Web.Controllers
{
    public class BetController : BaseController
    {
        private readonly IBet _betService;
        private readonly IWallet _walletService;
        private readonly ITransaction _transactionService;

        public BetController (IBet betService, IWallet walletService, ITransaction transactionService ,IFantasy fantasyService) : base (walletService, fantasyService)
        {
            _betService = betService;
            _walletService = walletService;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            var allBettingMatches = new List<BetMatchesDto>();
            ResponseDto? allBettingMatchesResponse = await _betService.GetAllBettingMatch();
            ApiHelper.APIGetDeserializedList(allBettingMatchesResponse, out allBettingMatches);

            allBettingMatches = allBettingMatches.Where(x => !x.isFinished).ToList();

            return View(allBettingMatches);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBet (BettingBetModelDto userBet)
        {
            

            if (Balance >= userBet.BetAmount)
            {
                userBet.UserID = Userid;
                userBet.BetStatus = ApiHelper.SportBetStatus.New.ToString();

                ResponseDto? betStatusResponse = await _betService.PlaceBet(userBet);
                bool isBetSuccess = (bool)betStatusResponse.Result;

                if (isBetSuccess)
                {
                    await _walletService.Withdraw(Userid, userBet.BetAmount);
                    await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.SportBet.ToString(), userBet.BetAmount));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AdminManageBettingTickets()
        {
            var allUsersSportBets = new List<BettingBetModelDto>();
            ResponseDto? allUsersSportBetsResponse = await _betService.GetAllUsersSportBets();
            ApiHelper.APIGetDeserializedList(allUsersSportBetsResponse, out allUsersSportBets);

            allUsersSportBets = allUsersSportBets.Where(x => x.BetStatus == ApiHelper.SportBetStatus.New.ToString()).ToList();

            return View(allUsersSportBets);
        }

        public async Task<IActionResult> UserBetHistory()
        {
            var userBets = new List<BettingBetModelDto>();
            ResponseDto? userBetsResponse = await _betService.GetUserBetsByUserId(Userid);
            ApiHelper.APIGetDeserializedList(userBetsResponse, out userBets);
            return View(userBets);
        }


    }
}
