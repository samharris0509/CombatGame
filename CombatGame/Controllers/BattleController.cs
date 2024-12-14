using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class BattleController : Controller
{
    private readonly ApplicationDbContext _context;

    public BattleController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var viewModel = new BattleViewModel
        {
            Teams = _context.Teams.Include(t => t.Characters).ToList()
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult StartBattle(BattleViewModel model)
    {
        var team1 = _context.Teams.Find(model.Team1Id);
        var team2 = _context.Teams.Find(model.Team2Id);

        // Record the battle
        var battle = new Battle
        {
            Team1Id = model.Team1Id,
            Team2Id = model.Team2Id,
            BattleDate = DateTime.Now,
            WinningTeamId = team1.Id  // For now, Team1 always wins
        };

        _context.Battles.Add(battle);

        // Update team stats
        team1.Wins++;
        team2.Losses++;

        _context.SaveChanges();

        TempData["Message"] = $"Battle Complete! {team1.Name} defeated {team2.Name}!";
        return RedirectToAction("Index");
    }
}
