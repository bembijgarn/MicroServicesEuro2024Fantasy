using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    public class FantasyController : BaseController
    {
        private readonly IFantasy _fantasyService;
        private readonly IPlayer _playerService;
        private readonly IWallet _walletService;
        private readonly ITransaction _transactionService;
        public FantasyController(IWallet walletService, IFantasy fantasyService, IPlayer playerService, ITransaction transactionService) : base(walletService, fantasyService)
        {
            _fantasyService = fantasyService;
            _playerService = playerService;
            _walletService = walletService;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HasTeam = HasFantasyTeam;

            var PlayerIds = new List<FantasyPlayerDto>();
            ResponseDto? fantasyplayerIdssResponse = await _fantasyService.GetFantasyPlayers(Userid);
            ApiHelper.APIGetDeserializedList(fantasyplayerIdssResponse, out PlayerIds);

            var FantasyTeamPlayers = new List<PlayerDto>();
            ResponseDto? fantasyFullTeamResponse = await _playerService.GetPlayersByPlayerIds(PlayerIds);
            ApiHelper.APIGetDeserializedList(fantasyFullTeamResponse, out FantasyTeamPlayers);


            int teamId;
            ResponseDto? teamIdresponse = await _fantasyService.GetTeamIdByUserId(Userid);
            ApiHelper.APIGetDeserializedobject(teamIdresponse, out teamId);

            var FantasyMatchResults = new List<FantasyMatchResultDto>();
            ResponseDto? fantasyMatchResultResponse = await _fantasyService.GetFantasyMatchResultByTeamId(teamId);
            ApiHelper.APIGetDeserializedList(fantasyMatchResultResponse, out FantasyMatchResults);

            var result = new FantasyTeamIndexViewModel(FantasyTeamPlayers, FantasyMatchResults);


            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(FantasyTeamDto model)
        {

            model.UserId = Userid;
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
            if (Balance >= amount)
            {
                await _fantasyService.BuyPlayer(Userid, playerId, playerName);
                await _walletService.Withdraw(Userid, amount); // buy
                await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Buy.ToString(), amount));

            }


            return RedirectToAction("Index", "Fantasy");
        }

        [HttpPost]
        public async Task<IActionResult> SellPlayer(int playerId, decimal amount)
        {
            await _fantasyService.SellPlayer(Userid, playerId);
            await _walletService.Deposit(Userid, (amount * 0.8m)); // Sell
            await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Sell.ToString(), (amount * 0.8m)));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> StartGame()
        {
            return View();
        }

        [HttpPost]
        [Route("Fantasy/DetermineGameResult")]
        public async Task<IActionResult> DetermineGameResult([FromBody] BetModelDto model)
        {
            int teamId;
            await Task.Delay(2000);
            Random random = new Random();
            int result = random.Next(0, 3);

            if (Balance < model.betAmount)
            {
                result = 3;
            }

            await WinnLoose(Userid, result, model.betAmount);

            ResponseDto? teamIdresponse = await _fantasyService.GetTeamIdByUserId(Userid);
            ApiHelper.APIGetDeserializedobject(teamIdresponse, out teamId);

            if (result != 3)
            {
                var matchResult = await returnstringResult(result);
                await _fantasyService.CreateMatchResult(teamId, matchResult);
            }
           

            ViewBag.GameResult = result;

            return PartialView("_GameResultPartial");
        }



        #region Helpers

        private async Task WinnLoose(string userId,int result, decimal amount)
        {
            switch (result)
            {
                case 0:
                    {
                        await _walletService.Withdraw(userId, amount);
                        await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Loss.ToString(), amount));

                        break;
                    }
                case 1:
                    {
                        await _walletService.Deposit(Userid, amount);
                        await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Win.ToString(), amount));

                        break;
                    }
                default:
                    {
                        await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Draw.ToString(), amount));
                        break;
                    }
            }
        }

        private async Task<string> returnstringResult(int result)
        {

            switch (result)
            {
                case 0:
                    {
                        return "Lose";
                    }
                case 1:
                    {
                        return "Win";
                    }
                case 2:
                    {
                        return "Draw";
                    }
                default:
                    {
                        return "Lose";
                    }
            }
        }

        #endregion


    }
}
