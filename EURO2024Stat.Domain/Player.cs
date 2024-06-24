using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class Player
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
