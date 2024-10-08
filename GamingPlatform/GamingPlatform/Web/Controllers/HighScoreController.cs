using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using IntegratedSystems.Domain.DomainModels;
using IntegratedSystems.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;
using IntegratedSystems.Domain;

namespace IntegratedSystems.Web.Controllers
{
    [Authorize]
    public class HighScoreController : Controller
    {
        private readonly IHighScoreService _highScoreService;
        private readonly IGameService _gameService;
        private readonly IUsersService _usersService;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _mailService;

        public HighScoreController(IHighScoreService highScoreService, IGameService gameService, IUsersService usersService, ApplicationDbContext context, IEmailService mailService)
        {
            _highScoreService = highScoreService;
            _gameService = gameService;
            _context = context;
            _usersService = usersService;
            _mailService = mailService;
        }

        // GET: HighScores
        public IActionResult Index()
        {
            var highScores = _highScoreService.GetHighScores()
                .OrderByDescending(h => h.Score)
                .ToList();
            return View(highScores);
        }

        // GET: HighScores/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highScore = _highScoreService.GetHighScoreById(id);
            if (highScore == null)
            {
                return NotFound();
            }
            
            return View(highScore);
        }

        // GET: HighScores/Create
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.GameList = new SelectList(_gameService.GetGames(), "Id", "Name");
            ViewBag.UserId = userId;
            return View();
        }

        // POST: HighScores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public IActionResult Create([Bind("Score,DateAchieved,GameId")] AddGameHighScoreDTO highScoreDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            highScoreDto.UserId = Guid.Parse(userId);
            var game = _gameService.GetGameById(highScoreDto.GameId);
            if (ModelState.IsValid)
            {
                var result = _gameService.AddGameHighScore(highScoreDto);
                if (result)
                {
                    var emailMessage = new EmailMessage
                    {
                        Id = Guid.NewGuid(),
                        Content = $"Congratulations on having a new high score of  {highScoreDto.Score} in the game {game.Name}!",
                        Subject = $"New high score in {game.Name}!",
                        MailTo = "berna.hodzhin@students.finki.ukim.mk"
                    };
                    _mailService.SendEmailAsync(emailMessage);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }
            }

            ViewBag.GameList = new SelectList(_gameService.GetGames(), "Id", "Name", highScoreDto.GameId);
            ViewBag.UserId = userId; 
            return View(highScoreDto);
        }
        
        // GET: HighScores/Delete/5
        [Authorize(Roles = "User")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highScore = _highScoreService.GetHighScoreById(id);
            if (highScore == null)
            {
                return NotFound();
            }

            return View(highScore);
        }

        // POST: HighScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var highScore = _highScoreService.GetHighScoreById(id);
            if (highScore != null)
            {
                _highScoreService.DeleteHighScore(highScore);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View();
        }
        
        private bool HighScoreExists(Guid id)
        {
            return _highScoreService.GetHighScoreById(id) != null;
        }
    }
}
