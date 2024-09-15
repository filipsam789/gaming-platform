using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Service.Interface;

namespace Service.Implementation
{
    public class HighScoreService : IHighScoreService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<HighScore> _highScoreRepository;

        public HighScoreService(IUserRepository userRepository, IRepository<Game> gameRepository,
            IRepository<HighScore> highScoreRepository)
        {

            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _highScoreRepository = highScoreRepository;
        }

        public HighScore CreateNewHighScore(HighScore highScore)
        {
            return _highScoreRepository.Insert(highScore);
        }

        public HighScore DeleteHighScore(HighScore highScore)
        {
            return _highScoreRepository.Delete(highScore);
        }

        public HighScore GetHighScoreById(Guid? id)
        {
            return _highScoreRepository.Get(id);
        }

        public List<HighScore> GetHighScores()
        {
            return _highScoreRepository.GetAll().ToList();
        }

        public HighScore UpdateHighScore(HighScore highScore)
        {
            return _highScoreRepository.Update(highScore);
        }
    }
}
