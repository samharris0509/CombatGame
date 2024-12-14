using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CombatGame.ViewModels;


namespace CombatGame.Controllers
{
    public class BattleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BattleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<BattleViewModel> Index()
        {
            var teams = _context.Teams.Include(t => t.Characters).ToList();
            var viewModel = new BattleViewModel { Teams = teams };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult<Battle> StartBattle(int team1Id, int team2Id)
        {
            var team1 = _context.Teams.Include(t => t.Characters).FirstOrDefault(t => t.Id == team1Id);
            var team2 = _context.Teams.Include(t => t.Characters).FirstOrDefault(t => t.Id == team2Id);

            var battle = new Battle
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                BattleDate = DateTime.Now,
                // Add battle logic here to determine winner
                WinningTeamId = team1Id // Placeholder
            };

            _context.Battles.Add(battle);
            _context.SaveChanges();

            return View("BattleResult", battle);
        }
    }
}