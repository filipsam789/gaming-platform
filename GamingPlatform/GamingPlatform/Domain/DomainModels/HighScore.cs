using IntegratedSystems.Domain.IdentityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegratedSystems.Domain.DomainModels
{
    public class HighScore : BaseEntity
    {
        public int Score { get; set; }
        public DateTime DateAchieved { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public Guid? UserId { get; set; }
        public virtual Game Game { get; set; }
        public Guid GameId { get; set; }

        public HighScore()
        {
        }
    }
}

