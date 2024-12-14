using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CombatGame.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int WinningTeamId { get; set; }
        public DateTime BattleDate { get; set; }

        [ForeignKey("Team1Id")]
        public Team Team1 { get; set; }

        [ForeignKey("Team2Id")]
        public Team Team2 { get; set; }
    }
}