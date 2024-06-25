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
        private readonly ITransaction _transactionService;

        public WalletController(IWallet walletService, IFantasy fantasyService, ITransaction transactionService) : base(walletService, fantasyService)
        {
            _walletService = walletService;
            _transactionService = transactionService;
        }

        public async Task <IActionResult> Index()
        {
            var userTransactions = new List<TransactionDto>();

            ResponseDto? responsewalletDto = await _walletService.CreateWallet(Userid, UserName);         
            ViewBag.Balance = Balance;

            ResponseDto? responseTransactionsDto = await _transactionService.GetUserTransactions(Userid);
            ApiHelper.APIGetDeserializedList(responseTransactionsDto, out userTransactions);




            return View(userTransactions);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            ResponseDto? responseDto = await _walletService.Deposit(Userid, amount);
            await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Deposit.ToString(), amount));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            bool isSuccess = true;
            ResponseDto? responseDto = await _walletService.Withdraw(Userid, amount);
            if (isSuccess)
            {
                await _transactionService.CreateTransaction(new TransactionDto(Userid, UserName, ApiHelper.TranType.Withdraw.ToString(), amount));
            }



            return RedirectToAction("Index");
        }

    }
}
