namespace Euro2024Stat.Web.Models
{
	public class MatchDto
	{
		public int ID { get; set; }
		public int HomeCountryID { get; set; }
		public int AwayCountryID { get; set; }
		public string Stadium { get; set; }
		public DateTime MatchDatetime { get; set; }
		public bool IsFinished { get; set; }
		public string Group { get; set; }
		public MatchResultDto MatchResults { get; set; }
		public MatchDto() {
            MatchResults = new MatchResultDto();
		}
	}
}
