using System.ComponentModel.DataAnnotations;

namespace CombatGame.Models
{
    public class Division
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public List<User> Users { get; set; }
    }
}