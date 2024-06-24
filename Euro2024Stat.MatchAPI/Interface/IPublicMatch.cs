using EURO2024Stat.Domain;

namespace Euro2024Stat.MatchAPI.Interface
{
	public interface IPublicMatch
	{
		Task<IEnumerable<Matches>> GetAllMatch();
		Task<IEnumerable<Matches>> GetAllMatchByCountryId(int countryId);
		Task<IEnumerable<Matches>> GetMatchesWithResults();
		Task<IEnumerable<Matches>> GetAllGroupMatchByGroupId(string group);
		Task<IEnumerable<Matches>> GetAllGroupMatchWithResultByGroupId(string groupId);

	}
}
