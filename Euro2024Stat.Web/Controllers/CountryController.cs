using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Euro2024Stat.Web.Controllers
{
    
    public class CountryController : BaseController
    {
        private readonly ICountry _countryservice;
        private readonly IPlayer _playerService;
        private readonly IMatch _matchService;
        private readonly IFantasy _fantasyService;


        public CountryController(IWallet walletService,ICountry countryservice, IPlayer playerService, IMatch matchService, IFantasy fantasyService) : base (walletService, fantasyService)
        {
            _countryservice = countryservice;
            _playerService = playerService;
            _matchService = matchService;
            _fantasyService = fantasyService;
        }

       


        public async Task<IActionResult> Index()
        {           
            List<Countrydto>? list = new();

            
            ResponseDto? response = await _countryservice.GetAllCountry();
            ApiHelper.APIGetDeserializedList(response,out list);
           

            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> CountryDetail(int countryId)
        {

            ResponseDto? countryResponse = await _countryservice.GetCountryById(countryId);
            ResponseDto? playersResponse = await _playerService.GetPlayerByCountryId(countryId);
			ResponseDto? matchResponse = await _matchService.GetCountryMatches(countryId);
            ResponseDto? matchResultResponse = await _matchService.GetMatchesWithResults();
            ResponseDto? response = await _fantasyService.HaveUserFantasy(Userid);
            ViewBag.HasTeam = HasFantasyTeam;

            var country = new Countrydto();
            var players = new List<PlayerDto>();
            var matches = new List<MatchDto>();
            var matchresults = new List<MatchDto>();

            ApiHelper.APIGetDeserializedobject(countryResponse, out country);
            ApiHelper.APIGetDeserializedList(playersResponse, out players);
            ApiHelper.APIGetDeserializedList(matchResponse, out matches);
            ApiHelper.APIGetDeserializedList(matchResultResponse, out matchresults);


            var viewModel = new CountryDetailViewModel(country, players, matches, matchresults);
            viewModel.Matches = viewModel.Matches.Where(x => !x.IsFinished).ToList();
            viewModel.MatchResults = viewModel.MatchResults.Where(x => x.AwayCountryID == country.ID || x.HomeCountryID == country.ID).ToList();

            return View(viewModel);
        }

        
        public async Task<IActionResult> CountryGroups()
        {
            List<Countrydto>? list = new();


            ResponseDto? response = await _countryservice.GetAllCountry();
            ApiHelper.APIGetDeserializedList(response, out list);

            var GroupA = list.Where(x => x.Group == 'A').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();
            var GroupB = list.Where(x => x.Group == 'B').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();
            var GroupC = list.Where(x => x.Group == 'C').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();
            var GroupD = list.Where(x => x.Group == 'D').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();
            var GroupE = list.Where(x => x.Group == 'E').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();
            var GroupF = list.Where(x => x.Group == 'F').OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();

            var FilteredGroups = new CountyGroupsViewModel(GroupA, GroupB, GroupC, GroupD, GroupE, GroupF);

            return View(FilteredGroups);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
