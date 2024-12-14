using CombatGame.Models;

namespace CombatGame.ViewModels
{
    public class LeaderboardViewModel
    {
        public List<User> TopUsers { get; set; }
        public List<Team> TopTeams { get; set; }
        public List<Division> Divisions { get; set; }
    }
}
