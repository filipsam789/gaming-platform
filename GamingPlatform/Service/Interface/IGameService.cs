using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGameService
    {
        public List<Game> GetGames();
        public Game GetGameById(Guid? id);
        public Game CreateNewGame(Game game);
        public Game UpdateGame(Game game);
        public Game DeleteGame(Game game);
        public bool AddGameHighScore(AddGameHighScoreDTO gameHighScoreDTO);
    }
}
