namespace Euro2024Stat.Web.Models
{
    public class GroupMatchesViewModel
    {
        public List<MatchDto> Matches { get; set; }
        public List<Countrydto> Countries { get; set; }
        public List<MatchDto> MatchResults { get; set; }    

        public GroupMatchesViewModel (List<MatchDto> match, List<Countrydto> country, List<MatchDto> matchResults)
        {
            this.Matches = match;  
            this.Countries = country;
            this.MatchResults = matchResults;
        }
    }
}
