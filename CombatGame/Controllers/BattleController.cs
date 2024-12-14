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

        public ActionResult<Battle> Create()
        {
            ViewBag.Teams = _context.Teams.Include(t => t.Characters).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult<Battle> Create(int team1Id, int team2Id)
        {
            var battle = new Battle
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                BattleDate = DateTime.Now
            };

            _context.Battles.Add(battle);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}