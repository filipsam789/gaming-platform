using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IHighScoreService
    {
        public List<HighScore> GetHighScores();
        public HighScore GetHighScoreById(Guid? id);
        public HighScore CreateNewHighScore(HighScore highScore);
        public HighScore UpdateHighScore(HighScore highScore);
        public HighScore DeleteHighScore(HighScore highScore);
        }
}