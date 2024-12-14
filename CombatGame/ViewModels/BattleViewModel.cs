using CombatGame.Models;

namespace CombatGame.ViewModels
{
    public class BattleViewModel
    {
        public List<Team> Teams { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
    }
}
