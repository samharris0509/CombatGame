using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;

public class CharacterController : Controller
{
    private readonly ApplicationDbContext _context;

    public CharacterController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult<IEnumerable<Character>> Index()
    {
        var characters = _context.Characters.ToList();
        return View(characters);
    }


    public ActionResult<Character> Create()
    {
        return View();
    }

    
        [HttpPost]
        public ActionResult<Character> Create(Character character)
        {
            character.UserId = 1;
            character.TeamId = null;
            character.Moves = new List<Move>();
            character.Health = Math.Max(1, character.Health);
            character.Attack = Math.Max(1, character.Attack);
            character.Defense = Math.Max(1, character.Defense);

            _context.Characters.Add(character);
            _context.SaveChanges();

            TempData["Message"] = $"Character {character.Name} created successfully!";
            return RedirectToAction("Index", "Home");
        }

        
    }



