using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
    public class FantasyContext : DbContext
    {
        public FantasyContext(DbContextOptions<FantasyContext> options) : base(options)
        {

        }

        public DbSet<FantasyTeam> Teams { get; set; }
        public DbSet<FantasyTeamPlayers> TeamPlayers { get; set; }
        public DbSet<FantasyMatchResults> MatchResults { get; set; }
    }

}
