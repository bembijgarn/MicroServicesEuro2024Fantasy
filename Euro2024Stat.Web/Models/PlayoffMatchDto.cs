namespace Euro2024Stat.Web.Models
{
    public class PlayoffMatchDto
    {
        public int homeCountryId { get; set; }
        public int awayCountryId { get; set; }
        public string stadium {  get; set; }
        public DateTime matchDate { get; set; }
        public string group { get; set; }
    }
}
