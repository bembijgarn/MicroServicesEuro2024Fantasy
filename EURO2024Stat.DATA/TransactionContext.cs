using Microsoft.EntityFrameworkCore;
using EURO2024Stat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EURO2024Stat.DATA
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }

        public DbSet<Transactions> Transactions { get; set; }
    }
}
