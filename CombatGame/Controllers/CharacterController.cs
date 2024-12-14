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
            character.Health = Math.Max(1, Math.Min(100, character.Health));
            character.Attack = Math.Max(1, Math.Min(50, character.Attack));
            character.Defense = Math.Max(1, Math.Min(50, character.Defense));
            character.Moves = new List<Move>();

            _context.Characters.Add(character);
            _context.SaveChanges();

            TempData["Message"] = $"Character {character.Name} created successfully!";
            return RedirectToAction("Index", "Home");
        }

    }
}
