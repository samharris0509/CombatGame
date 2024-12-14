using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Character> Characters { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}