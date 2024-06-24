using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
    public class MatchResultContext :DbContext
    {
        public MatchResultContext(DbContextOptions<MatchResultContext> options) : base(options)
        {

        }

        public DbSet<MatchResults> MatchResults { get; set; }
    }
}
