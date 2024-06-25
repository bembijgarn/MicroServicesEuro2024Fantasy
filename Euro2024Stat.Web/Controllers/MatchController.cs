using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Euro2024Stat.Web.Controllers
{
    [Authorize]
    public class MatchController : Controller
    {

        private readonly IMatch _matchService;
        private readonly ICountry _countryService;


        public MatchController( IMatch matchService, ICountry countryService)
        {
        
            _matchService = matchService;
            _countryService = countryService;
        }
        public async Task<IActionResult> Matches()
        {
            var Matches = new List<MatchDto>();

            ResponseDto? matchResponse = await _matchService.GetAllMatch();

            ApiHelper.APIGetDeserializedList(matchResponse,out Matches);

            return View(Matches);

        }

        public async Task<IActionResult> MatchResults()
        {
            var Matches = new List<MatchDto>();

            ResponseDto? matchResponse = await _matchService.GetMatchesWithResults();

            ApiHelper.APIGetDeserializedList(matchResponse, out Matches);


            return View(Matches);

        }

        public async Task<IActionResult> GroupMatches(string groupId)
        {
            var GroupMatches = new List<MatchDto>();
            var Countries = new List<Countrydto>();
            var GroupMatchResults = new List<MatchDto>();

            ResponseDto? matchResponse = await _matchService.GetAllGroupMatchByGroupId(groupId);
            ResponseDto? response = await _countryService.GetCountriesByGroup(Convert.ToChar(groupId));
            ResponseDto? matchResultResponse = await _matchService.GetGroupMatchResultsByGroupId(groupId);


            ApiHelper.APIGetDeserializedList(response, out Countries);
            ApiHelper.APIGetDeserializedList(matchResponse,out GroupMatches);
            ApiHelper.APIGetDeserializedList(matchResultResponse, out GroupMatchResults);

            var ViewModel = new GroupMatchesViewModel(GroupMatches, Countries, GroupMatchResults);
            ViewModel.Countries = ViewModel.Countries.OrderByDescending(x => x.Point).ThenByDescending(x => x.GoalsFor).ToList();

            ViewBag.group = groupId;

            return View(ViewModel);
        }



    }
}
