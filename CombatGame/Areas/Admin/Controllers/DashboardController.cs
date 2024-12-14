using CombatGame.Areas.Admin.Models;
using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CombatGame.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<AdminDashboardViewModel> Index()
        {
            var viewModel = new AdminDashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                TotalBattles = _context.Battles.Count(),
                TotalTeams = _context.Teams.Count(),
                RecentBattles = _context.Battles
                    .Include(b => b.Team1)
                    .Include(b => b.Team2)
                    .OrderByDescending(b => b.BattleDate)
                    .Take(10)
                    .ToList()
            };
            return View(viewModel);
        }
    }
}