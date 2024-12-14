using CombatGame.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int? TeamId { get; set; }
    public virtual Team Team { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual List<Move> Moves { get; set; }
}
