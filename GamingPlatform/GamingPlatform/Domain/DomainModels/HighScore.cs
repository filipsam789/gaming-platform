using System.ComponentModel.DataAnnotations.Schema;

namespace IntegratedSystems.Domain.DomainModels
{
    public class HighScore : BaseEntity
    {
        public int Score { get; set; }
        public DateTime DateAchieved { get; set; }
        public virtual User User { get; set; }  
        [ForeignKey("UserId")]
        public string UserId { get; set; }
      
        public virtual Game Game { get; set; }
        public Guid GameId { get; set; }

        public HighScore()
        {
        }

        public HighScore(int score, DateTime dateAchieved, string userId, Guid gameId, Game game, User user)
        {
            Score = score;
            DateAchieved = dateAchieved;
            UserId = userId;
            GameId = gameId;
            User = user;
            Game = game;
        }
    }
}

