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
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IUsersService _usersService;
        private readonly ApplicationDbContext _context;


        public GameController(IGameService gameService, IUsersService usersService, ApplicationDbContext context)
        {
            _gameService = gameService;
            _context = context;
            _usersService = usersService;
        }

        // GET: Games
        public IActionResult Index()
        {
            return View(_gameService.GetGames());
        }

        // GET: Games/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
           return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Platform,Genre,Version,Price,ReleaseDate,DeveloperId")] Game game)
        {
            if (ModelState.IsValid)
            {
                game.Id = Guid.NewGuid();
                _gameService.CreateNewGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }


        // GET: Games/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Description,Platform,Genre,Version,Price,ReleaseDate,DeveloperId,Id")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gameService.UpdateGame(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        // GET: Games/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var game = _gameService.GetGameById(id);
            if (game != null)
            {
                _gameService.DeleteGame(game);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Games/AddGameHighScore
        public IActionResult AddGameHighScore(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            AddGameHighScoreDTO model = new AddGameHighScoreDTO
            {
                GameId = id,
                UserId = Guid.Parse(userId),
                GameName = _gameService.GetGameById(id).Name,
            };

            return View(model);
        }

        // POST: Games/AddGameHighScore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGameHighScore([Bind("GameId,UserId,Score,DateAchieved")] AddGameHighScoreDTO model)
        {
            if (ModelState.IsValid)
            {
                
                var result = _gameService.AddGameHighScore(model);
                if (result)
                {
                    return RedirectToAction(nameof(Details), new { id = model.GameId });
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }
            }
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

        private bool GameExists(Guid id)
        {
            return _gameService.GetGameById(id) != null;
        }
    }
}
