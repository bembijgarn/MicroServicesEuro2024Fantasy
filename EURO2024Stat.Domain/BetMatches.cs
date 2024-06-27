using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class BetMatches
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        public int HomeCountryId { get; set; }
        public string HomeCountryName { get; set; }
        public string AwayCountryName { get; set; }
        public int AwayCountryId { get; set; }
        
        public decimal HomeCoefficient { get; set; }
        public decimal DrawCoefficient { get; set; }
        public decimal AwayCoefficient { get; set;}
        public bool isFinished { get; set; }
    }
}
