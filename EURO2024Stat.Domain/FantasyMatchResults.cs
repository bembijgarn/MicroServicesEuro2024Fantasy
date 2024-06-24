using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class FantasyMatchResults
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public char Result {  get; set; }
        public DateTime MatchDate { get; set; } = DateTime.Now;
    }
}
