using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize]
    public class FantasyController : BaseController
    {
        private readonly IFantasy _fantasyService;
        private readonly IPlayer _playerService;
        private readonly IWallet _walletService;
        public FantasyController(IWallet walletService,IFantasy fantasyService, IPlayer playerService) : base (walletService, fantasyService)
        {
            _fantasyService = fantasyService;
            _playerService = playerService;
            _walletService = walletService; 
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

            return View(FantasyTeamPlayers);
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
            }

            await _walletService.Withdraw(Userid, amount); // buy
           
            return RedirectToAction("Index","Fantasy");
        }

        [HttpPost]
        public async Task<IActionResult> SellPlayer(int playerId, decimal amount)
        {
            await _fantasyService.SellPlayer(Userid, playerId);
            await _walletService.Deposit(Userid, (amount * 0.8m)); // Sell

            return RedirectToAction(nameof(Index));
        }

       
    }
}
