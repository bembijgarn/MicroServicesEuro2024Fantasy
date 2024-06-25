using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using System.Reflection;

namespace Euro2024Stat.Web.Service
{
	public class MatchService : IMatch
	{
		private readonly IRequestResponse _service;
		public MatchService(IRequestResponse service)
		{
			_service = service;
		}

        public async Task<ResponseDto?> EditMatchResult(int matchId, MatchResultDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.PUT,
				Data = model,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/UpdateMatchResult?matchId=" + matchId
            });
        }

        public async Task<ResponseDto?> ResetMatch(int matchId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/ResetMatch?matchId=" + matchId
            });
        }

        public async Task<ResponseDto?> FinishMatch(int matchId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/FinishMatch?matchId=" + matchId
            });
        }

        public async Task<ResponseDto?> GetAllMatch()
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.GET,
				Url = ApiHelper.MatchAPIBase + "/api/Match/GetAllMatches"
			});
		}

		public async Task<ResponseDto?> GetCountryMatches(int Id)
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.GET,
				Url = ApiHelper.MatchAPIBase + "/api/Match/GetAllMatchesByCountryId?countryId=" + Id
			});
		}

        public async Task<ResponseDto?> GetMatchesWithResults()
        {
            return  await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Match/GetMatchesWithResults"
            });
        }

        public async Task<ResponseDto?> GetAllGroupMatchByGroupId(string groupId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Match/GetAllGroupMatchByGroupId?groupId=" + groupId
            });
        }

        public async  Task<ResponseDto?> GetGroupMatchResultsByGroupId(string groupId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Match/GetGroupMatchResultsByGroupId?groupId=" + groupId
            });
        }

        public async Task<ResponseDto?> CreatePlayOffMatch(PlayoffMatchDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = model,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/CreatePlayOffMatch"
            });
        }

        public async Task<ResponseDto?> GetPlayoffCountryIdsByGroup(string groupId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/GetPlayoffCountryIdsByGroup?group=" + groupId
            });
        }

        public async Task<ResponseDto?> GetPlayoffWinnerTeamIds(string groupId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/GetPlayoffWinnerTeamIds?group=" + groupId
            });
        }

        public async Task<ResponseDto?> GetWinnerTeamId(string groupId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.MatchAPIBase + "/api/Admin/Match/GetWinnerTeamId?group=" + groupId
            });
        }
    }
}
