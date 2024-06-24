using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.Domain
{
    public class Wallet
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }

    }
}
