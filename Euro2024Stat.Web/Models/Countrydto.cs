using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024Stat.Web.Models
{
    public class Countrydto
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
