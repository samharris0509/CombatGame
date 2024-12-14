using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace CombatGame.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult<Character> Create(int teamId)
        {
            ViewBag.TeamId = teamId;
            return View();
        }

        [HttpPost]
        public ActionResult<Character> Create(Character character)
        {
            character.UserId = 1;
            character.TeamId = null;
            character.Moves = new List<Move>();

            _context.Characters.Add(character);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
