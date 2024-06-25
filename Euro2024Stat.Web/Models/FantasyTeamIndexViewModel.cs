using Euro2024Stat.Web.Models.Dto;

namespace Euro2024Stat.Web.Models
{
    public class FantasyTeamIndexViewModel
    {
        public List<PlayerDto> fantasyPlayers { get; set; }
        public List<FantasyMatchResultDto> fantasyMatches { get; set; }

        public FantasyTeamIndexViewModel(List<PlayerDto> fp, List<FantasyMatchResultDto> fm)
        {
            this.fantasyPlayers = fp;
            this.fantasyMatches = fm;
        }
    }
}
