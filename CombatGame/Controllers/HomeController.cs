using System.Diagnostics;
using CombatGame.Models;
using CombatGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CombatGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult<IEnumerable<Team>> Index()
        {
            if (!_context.Teams.Any())
            {
                return View(new List<Team>());
            }

            var topTeams = _context.Teams
                .Include(t => t.User)
                .OrderByDescending(t => t.Wins)
                .Take(5)
                .ToList();
            return View(topTeams);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}