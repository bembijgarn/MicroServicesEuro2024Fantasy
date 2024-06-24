namespace Euro2024Stat.Web.Models
{
    public class CountryDetailViewModel
    {
        public Countrydto Country { get; set; }
        public List<PlayerDto> Players { get; set; }
		public List<MatchDto> Matches { get; set; }
        public List<MatchDto> MatchResults { get; set; }

        public CountryDetailViewModel(Countrydto country, List<PlayerDto> player, List<MatchDto> matches, List<MatchDto> matchresult)
        {
            this.Country = country;
            this.Players = player;
            this.Matches = matches;
            this.MatchResults = matchresult;
        }
	}
}