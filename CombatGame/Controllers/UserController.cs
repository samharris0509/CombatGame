using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CombatGame.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<User>> Index()
        {
            var users = _context.Users
                .Include(u => u.Teams)
                .Include(u => u.Division)
                .ToList();
            return View(users);
        }

        public ActionResult<User> Create()
        {
            ViewBag.Divisions = _context.Divisions.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            user.TotalWins = 0;
            user.DivisionId = 1;
            user.Teams = new List<Team>();
            user.Achievements = new List<Achievement>();

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Message"] = $"User {user.Username} created successfully!";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult<User> Profile(int id)
        {
            var user = _context.Users
                .Include(u => u.Teams)
                .Include(u => u.Achievements)
                .Include(u => u.Division)
                .FirstOrDefault(u => u.Id == id);

            return View(user);
        }

        [HttpPost]
        public ActionResult<User> UpdateDivision(int userId, int divisionId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.DivisionId = divisionId;
                _context.SaveChanges();
            }
            return RedirectToAction("Profile", new { id = userId });
        }
    }
}
