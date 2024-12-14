using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}