using CombatGame.Models;

namespace CombatGame.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalBattles { get; set; }
        public int TotalTeams { get; set; }
        public List<Battle> RecentBattles { get; set; }
    }
}