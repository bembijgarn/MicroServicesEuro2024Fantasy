using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class Countries
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public char Group {  get; set; }
        public int Point {  get; set; }
        public int Matches { get; set; }
        public int GoalsFor {  get; set; }
        public int GoalsAgainst { get; set; }
    }
}
