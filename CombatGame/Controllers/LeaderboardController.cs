using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CombatGame.ViewModels;
using CombatGame.ViewModels;

namespace CombatGame.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<LeaderboardViewModel> Index()
        {
            var viewModel = new LeaderboardViewModel
            {
                TopUsers = _context.Users
                    .Include(u => u.Division)
                    .OrderByDescending(u => u.TotalWins)
                    .Take(10)
                    .ToList(),
                TopTeams = _context.Teams
                    .Include(t => t.User)
                    .OrderByDescending(t => t.Wins)
                    .Take(10)
                    .ToList(),
                Divisions = _context.Divisions
                    .Include(d => d.Users)
                    .ToList()
            };
            return View(viewModel);
        }
    }
}
