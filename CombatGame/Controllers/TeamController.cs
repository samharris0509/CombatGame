using CombatGame.Data;
using CombatGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class TeamController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult<Team> Index()
    {
        var teams = _context.Teams.Include(t => t.Characters).ToList();
        return View(teams);
    }

    public ActionResult<Team> Create()
    {
        var availableCharacters = _context.Characters.Where(c => c.TeamId == null).ToList();
        ViewBag.Characters = availableCharacters;
        return View();
    }

    [HttpPost]
    public ActionResult<Team> Create(Team team)
    {
        team.UserId = 1;
        team.Wins = 0;
        team.Losses = 0;

        _context.Teams.Add(team);
        _context.SaveChanges();

        TempData["Message"] = $"Team {team.Name} created successfully!";
        return RedirectToAction("Index", "Home");
    }
}
