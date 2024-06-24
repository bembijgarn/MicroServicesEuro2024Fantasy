using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Euro2024Stat.Web.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IAuth _authService;
        private readonly IToken _tokenService;
        private readonly IWallet _walletService;
        public AuthenticateController(IAuth authService, IToken tokenService, IWallet walletService)
        {
            _authService = authService;
            _tokenService = tokenService;
            _walletService = walletService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginDto Logindto = new();
            return View(Logindto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto obj)
        {
            var loginResponseDto = new LoginResponseDto();
            ResponseDto responseDto = await _authService.Login(obj);           

            ApiHelper.APIGetDeserializedobject(responseDto, out loginResponseDto);
            if (loginResponseDto != null)
            {               
                await SignInUser(loginResponseDto);
                _tokenService.SetToken(loginResponseDto.Token);
                return RedirectToAction("Index", "Country");
            }else
            {
                TempData["error"] = responseDto.Message;
                return View(obj);
            }          
        }


        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=ApiHelper.RoleAdmin,Value=ApiHelper.RoleAdmin},
                new SelectListItem{Text=ApiHelper.RoleCustomer,Value=ApiHelper.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto dtoUser)
        {
            ResponseDto result = await _authService.Register(dtoUser);
            ResponseDto assingRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(dtoUser.Role))
                {
                    dtoUser.Role = ApiHelper.RoleCustomer;
                }
                assingRole = await _authService.GiveRole(dtoUser);
                if (assingRole != null && assingRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Register));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=ApiHelper.RoleAdmin,Value=ApiHelper.RoleAdmin},
                new SelectListItem{Text=ApiHelper.RoleCustomer,Value=ApiHelper.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View(dtoUser);
        }

        #region Helpers

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenService.ClearToken();
            return RedirectToAction("Login", "Authenticate");
        }

        private async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            
            var jwt = handler.ReadJwtToken(model.Token);
           
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
       
            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));



            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        #endregion
    }
}
