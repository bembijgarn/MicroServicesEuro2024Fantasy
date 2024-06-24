namespace Euro2024Stat.Web.Models
{
    public class PlayerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int TshirtNumber { get; set; }
        public int Age { get; set; }
        public int CountryID { get; set; }
        public decimal FantasyPrice { get; set; }
    }
}
