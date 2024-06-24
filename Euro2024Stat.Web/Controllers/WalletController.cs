using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWallet _walletService;

        public WalletController(IWallet walletService)
        {
            _walletService = walletService;
        }

        public async Task <IActionResult> Index()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            var userName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name)?.FirstOrDefault()?.Value;
            ResponseDto? responsewalletDto = await _walletService.CreateWallet(userId, userName);

            decimal Balance = 0;
            ResponseDto? responseDto = await _walletService.GetBalance(userId);
            ApiHelper.APIGetDeserializedobject(responseDto, out Balance);
            ViewBag.Balance = Balance;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? responseDto = await _walletService.Deposit(userId, amount);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            bool isSuccess = true;
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? responseDto = await _walletService.Withdraw(userId, amount);


            return RedirectToAction("Index");
        }

    }
}
