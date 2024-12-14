using Microsoft.EntityFrameworkCore;
using CombatGame.Models;

namespace CombatGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Division> Divisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Core relationships
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Characters)
                .WithOne(c => c.Team)
                .HasForeignKey(c => c.TeamId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Teams)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Moves)
                .WithOne(m => m.Character)
                .HasForeignKey(m => m.CharacterId);

            // Battle relationships
            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Team1)
                .WithMany()
                .HasForeignKey(b => b.Team1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Team2)
                .WithMany()
                .HasForeignKey(b => b.Team2Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed Data
            modelBuilder.Entity<Division>().HasData(
    new Division { Id = 1, Name = "Rookie", Description = "Starting Division" }
);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "FirstPlayer", DivisionId = 1 }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Team One",
                    UserId = 1,
                    Wins = 5,
                    Losses = 2
                }
            );

        }
    }
}
