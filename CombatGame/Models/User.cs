using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CombatGame.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int TotalWins { get; set; }
        public List<Team> Teams { get; set; }
        public List<Achievement> Achievements { get; set; }

        [ForeignKey("Division")]
        public int? DivisionId { get; set; }  // Making this nullable
        public Division Division { get; set; }
    }
}
