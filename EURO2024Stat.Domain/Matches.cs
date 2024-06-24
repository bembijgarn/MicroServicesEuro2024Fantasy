using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class Matches
    {
        public int ID { get; set; }
        public int HomeCountryID { get; set; }
        public int AwayCountryID { get; set; }
        public string Stadium {  get; set; }
        public DateTime MatchDatetime { get; set; }
        public bool IsFinished { get; set; }
        public string Group { get; set; }
        public MatchResults? MatchResults { get; set; }
       
    }
}
