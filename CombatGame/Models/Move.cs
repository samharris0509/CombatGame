using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Move
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Power { get; set; }

        [Range(1, 100)]
        public int Accuracy { get; set; }

        [Required]
        public string Type { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}