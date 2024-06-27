using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class Bet
    {
        public int ID { get; set; }
        public string BetID { get; set; }
        public string UserID { get; set; }
        public decimal Coefficient { get; set; }
        public decimal BetAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public string BetStatus { get; set; }

    }
}
