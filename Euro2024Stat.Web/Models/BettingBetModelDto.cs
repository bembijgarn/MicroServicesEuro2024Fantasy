namespace Euro2024Stat.Web.Models
{
    public class BettingBetModelDto
    {
        public string BetID { get; set; }
        public string UserID { get; set; }
        public decimal Coefficient { get; set; }
        public decimal BetAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public string BetStatus { get; set; }
    }
}
