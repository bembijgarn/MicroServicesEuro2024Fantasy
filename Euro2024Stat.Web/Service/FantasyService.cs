using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Models.Dto;
using System.Reflection;

namespace Euro2024Stat.Web.Service
{
    public class FantasyService : IFantasy
    {
        private readonly IRequestResponse _service;

        public FantasyService(IRequestResponse service)
        {
            _service = service;
        }

        public async Task<ResponseDto> BuyPlayer(string userId, int playerId, string playerName)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = $"{ApiHelper.FantasyAPIBase}/api/Fantasy/BuyPlayer?userId={userId}&playerId={playerId}&playerName={playerName}"
            });
        }

        public async Task<ResponseDto> SellPlayer(string userId, int playerId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Url = $"{ApiHelper.FantasyAPIBase}/api/Fantasy/SellPlayer?userId={userId}&playerId={playerId}"
            });
        }

        public async Task<ResponseDto> CreateFantasyTeam(FantasyTeamDto model)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = model,
                Url = ApiHelper.FantasyAPIBase + "/api/Fantasy/CreateTeam"
            });
        }

        public async Task<ResponseDto> GetFantasyPlayers(string userId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.FantasyAPIBase + "/api/Fantasy/GetFantasyPlayers?userId=" + userId
            });
        }

       

        public async Task<ResponseDto> HaveUserFantasy(string userId)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.FantasyAPIBase + "/api/Fantasy/HaveUserFantasy?userId=" + userId
            });
        }

        
    }
}
