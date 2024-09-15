using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Service.Interface;

namespace Service.Implementation
{
    public class GameService : IGameService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<HighScore> _highScoreRepository;

        public GameService(IUserRepository userRepository, IRepository<Game> gameRepository, IRepository<HighScore> highScoreRepository)
        {

            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _highScoreRepository = highScoreRepository;
        }

        public Game CreateNewGame(Game game)
        {
            return _gameRepository.Insert(game);
        }

        public Game DeleteGame(Game game)
        {
            return _gameRepository.Delete(game);
        }

        public Game GetGameById(Guid? id)
        {
            return _gameRepository.Get(id);
        }

        public List<Game> GetGames()
        {
            return _gameRepository.GetAll().ToList();
        }

        public Game UpdateGame(Game game)
        {
            return _gameRepository.Update(game);
        }

        public bool AddGameHighScore(AddGameHighScoreDTO gameHighScoreDTO)
        {
            if (gameHighScoreDTO == null)
                throw new ArgumentNullException(nameof(gameHighScoreDTO));

            var user = _userRepository.Get(gameHighScoreDTO.UserId.ToString());
            var game = _gameRepository.Get(gameHighScoreDTO.GameId);
    
            if (game == null || user == null)
                return false;

            var highestScore = _highScoreRepository.GetAll()
                .Where(h => h.GameId == game.Id)
                .OrderByDescending(h => h.Score) 
                .FirstOrDefault()?.Score ?? 0;
            
            if (gameHighScoreDTO.Score > highestScore)
            {
                var highScore = new HighScore
                {
                    Score = gameHighScoreDTO.Score,
                    DateAchieved = gameHighScoreDTO.DateAchieved,
                    UserId = gameHighScoreDTO.UserId,
                    GameId = game.Id
                };

                _highScoreRepository.Insert(highScore);
                return true;
            }

            return false;
        }


    }
}
