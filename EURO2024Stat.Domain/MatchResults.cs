using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class MatchResults
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Matches Match { get; set; }

	}
}
