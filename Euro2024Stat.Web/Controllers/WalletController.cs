using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize]
    public class WalletController : BaseController
    {
        private readonly IWallet _walletService;

        public WalletController(IWallet walletService, IFantasy fantasyService) : base(walletService, fantasyService)
        {
            _walletService = walletService; 
        }

        public async Task <IActionResult> Index()
        {
     
            ResponseDto? responsewalletDto = await _walletService.CreateWallet(Userid, UserName);         
            ViewBag.Balance = Balance;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            ResponseDto? responseDto = await _walletService.Deposit(Userid, amount);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            bool isSuccess = true;
            ResponseDto? responseDto = await _walletService.Withdraw(Userid, amount);


            return RedirectToAction("Index");
        }

    }
}
