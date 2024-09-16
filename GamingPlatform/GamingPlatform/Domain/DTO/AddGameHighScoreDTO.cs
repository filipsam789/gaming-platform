using IntegratedSystems.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTO
{
    public class AddGameHighScoreDTO
    {
        [Display(Name = "Game")]
        public Guid GameId { get; set; }
        public Guid? UserId { get; set; }
        public Game? Game { get; set; } 
        public string? PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime DateAchieved { get; set; } = DateTime.Today;
    }
}
