using CombatGame.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int? TeamId { get; set; }
    public int UserId { get; set; }  // Add this line
    public User User { get; set; }    // And this line
    public Team Team { get; set; }
    public List<Move> Moves { get; set; }
}
