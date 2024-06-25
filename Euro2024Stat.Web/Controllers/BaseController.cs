using Euro2024Stat.Web.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Helper;
using System.IdentityModel.Tokens.Jwt;
using Euro2024Stat.Web.Service;

namespace Euro2024Stat.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IWallet _walletService;
        private readonly IFantasy _fantasyService;
        protected decimal Balance;
        protected string Userid;
        protected string UserName;
        protected bool HasFantasyTeam;


        public BaseController(IWallet walletService, IFantasy fantasyService)
        {
            _walletService = walletService;
            _fantasyService = fantasyService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            //await base.OnActionExecutionAsync(context, next);

            Userid = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            UserName = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Name)?.FirstOrDefault()?.Value;


            ResponseDto? responseDto = await _walletService.GetBalance(Userid);
            ApiHelper.APIGetDeserializedobject(responseDto, out Balance);

            ResponseDto? response = await _fantasyService.HaveUserFantasy(Userid);
            HasFantasyTeam = (bool)response.Result;

            await next();

        }
    }
}
