namespace Euro2024Stat.Web.Models
{
    public class BetMatchesDto
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        public int HomeCountryId { get; set; }
        public string HomeCountryName { get; set; }
        public string AwayCountryName { get; set; }
        public int AwayCountryId { get; set; }
        public decimal HomeCoefficient { get; set; }
        public decimal DrawCoefficient { get; set; }
        public decimal AwayCoefficient { get; set; }
        public bool isFinished { get; set; }
    }
}
