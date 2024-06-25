using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Service
{
    public class CountryService : ICountry
    {
        private readonly IRequestResponse _service;
        public CountryService(IRequestResponse service)
        {
            _service= service;
        }
        public async Task<ResponseDto?> GetAllCountry()
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.CountryAPIBase + "/api/Country/GetCountries"
            });
        }

        public async Task<ResponseDto?> GetCountriesByGroup(char group)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.GET,
                Url = ApiHelper.CountryAPIBase + "/api/Country/GetCountriesByGroup?Group=" + group
            });
        }

        public async Task<ResponseDto?> GetCountryById(int Id)
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.GET,
				Url = ApiHelper.CountryAPIBase + "/api/Country/GetCountryById?Id=" + Id
			});
		}

        public async Task<ResponseDto?> UpdateStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Url = ApiHelper.CountryAPIBase + "/api/Admin/Country/UpdateStatistic?homeCountryId=" + homeCountryId + "&awayCountryId=" + awayCountryId + "&homeGoals=" + homeGoals + "&awayGoals=" + awayGoals
            });
        }

        public async Task<ResponseDto?> RollBackStatistic(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.PUT,
                Url = ApiHelper.CountryAPIBase + "/api/Admin/Country/RollBackStatistic?homeCountryId=" + homeCountryId + "&awayCountryId=" + awayCountryId + "&homeGoals=" + homeGoals + "&awayGoals=" + awayGoals
            });
        }

		public async Task<ResponseDto?> GetGroupWinnerCountries()
		{
			return await _service.SendAsync(new RequestDto()
			{
				ApiType = ApiHelper.ApiType.GET,
				Url = ApiHelper.CountryAPIBase + "/api/Admin/Country/GetGroupWinnerCountries"
			});
		}

        public async Task<ResponseDto?> GetTop3thPlaces(List<int> countryIds)
        {
            return await _service.SendAsync(new RequestDto()
            {
                ApiType = ApiHelper.ApiType.POST,
                Data = countryIds,
                Url = ApiHelper.CountryAPIBase + "/api/Admin/Country/GetTop3ThCountries?"
            });
        }
    }
}
