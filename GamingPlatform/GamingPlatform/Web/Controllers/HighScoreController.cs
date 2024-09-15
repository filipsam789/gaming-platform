using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using IntegratedSystems.Domain.DomainModels;
using IntegratedSystems.Domain.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Interface;

namespace IntegratedSystems.Web.Controllers
{
    public class HighScoreController : Controller
    {
        private readonly IHighScoreService _highScoreService;
        private readonly IGameService _gameService;
        private readonly IUsersService _usersService;
        private readonly ApplicationDbContext _context;

        public HighScoreController(IHighScoreService highScoreService, IGameService gameService, IUsersService usersService, ApplicationDbContext context)
        {
            _highScoreService = highScoreService;
            _gameService = gameService;
            _context = context;
            _usersService = usersService;
        }

        // GET: HighScores
        public IActionResult Index()
        {
            
            return View(_highScoreService.GetHighScores());
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
        public IActionResult Create([Bind("Score,DateAchieved,GameId")] AddGameHighScoreDTO highScoreDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            highScoreDto.UserId = Guid.Parse(userId);
            if (ModelState.IsValid)
            {
                var result = _gameService.AddGameHighScore(highScoreDto);
                if (result)
                {
                    _gameService.AddGameHighScore(highScoreDto);
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
