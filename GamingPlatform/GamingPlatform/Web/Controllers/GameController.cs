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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IntegratedSystems.Domain.IdentityModels;
using AutoMapper;
namespace IntegratedSystems.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IUsersService _usersService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<GamingPlatformUser> _userManager;

        public GameController(IGameService gameService, IUsersService usersService, ApplicationDbContext context, UserManager<GamingPlatformUser> userManager)
        {
            _gameService = gameService;
            _context = context;
            _usersService = usersService;
            _userManager = userManager;
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
        [Authorize(Roles = "Developer")]
        public IActionResult Create()
        {
            ViewBag.DeveloperList = _usersService.GetDevelopers();
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Developer")]
        public IActionResult Create([Bind("Name,Description,Platform,Genre,Version,Price,ReleaseDate,DeveloperId")] Game game)
        {
            if (ModelState.IsValid)
            {
                game.Id = Guid.NewGuid();
                var developer = _usersService.GetDeveloperById(game.DeveloperId.ToString());
                game.Developer = developer;
                _gameService.CreateNewGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }


        // GET: Games/Edit/5
        [Authorize(Roles = "Developer")]
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
        [Authorize(Roles = "Developer")]
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
        [Authorize(Roles = "Developer")]
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
        [Authorize(Roles = "User")]
        public IActionResult AddGameHighScore(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var player = _usersService.GetPlatformUserById(userId);

            AddGameHighScoreDTO model = new AddGameHighScoreDTO
            {
                GameId = id,
                UserId = Guid.Parse(userId),
                PlayerName = player.FirstName,
                Game = _gameService.GetGameById(id),
            };

            return View(model);
        }

        // POST: Games/AddGameHighScore
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
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
