using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using System.Reflection;

namespace Euro2024Stat.Web.Service
{
    public class BetService : IBet
    {

        private readonly IRequestResponse _service;
        public BetService(IRequestResponse service)
        {
            _service = service;
        }

        public async Task<ResponseDto?> AddPlayoffBetMatch(BetMatchesDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = model,
                Url = ApiHelper.BetAPIBase + "/api/Admin/Bet/AddPlayoffBetMatch"
            });
        }

        public async Task<ResponseDto?> FinishBetMatch(int matchId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = ApiHelper.BetAPIBase + "/api/Admin/Bet/FinishBetMatch?matchId=" + matchId
            });
        }

        public async Task<ResponseDto?> GetAllBettingMatch()
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.BetAPIBase + "/api/Bet/GetAllBetMatches"
            });
        }

        public async Task<ResponseDto?> GetAllUsersSportBets()
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.BetAPIBase + "/api/Admin/Bet/GetAllUserSportBets"
            });
        }

        public async Task<ResponseDto?> GetUserBetsByUserId(string userId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.BetAPIBase + "/api/Bet/GetUserBetsByUserId?userId=" + userId
            });
        }

        public async Task<ResponseDto?> PlaceBet(BettingBetModelDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = model,
                Url = ApiHelper.BetAPIBase + "/api/Bet/PlaceBet"
            });
        }

        public async Task<ResponseDto?> RollbackBetMatch(int matchId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = ApiHelper.BetAPIBase + "/api/Admin/Bet/RollbackBetMatch?matchId=" + matchId
            });
        }

        public async Task<ResponseDto?> UpdateUserBetStatus(string betId, string betStatus)
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.POST,
				Url = ApiHelper.BetAPIBase + "/api/Admin/Bet/UpdateUserBetStatus?betId=" + betId + "&betStatus=" + betStatus
			});
		}
	}
}
