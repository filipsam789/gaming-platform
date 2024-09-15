using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DomainModels
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public double Version { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        [ForeignKey("DeveloperId")]
        public string? DeveloperId { get; set; }
      
        public Developer? Developer { get; set; }
        public ICollection<HighScore> HighScores { get; set; } = new List<HighScore>();

    }
}
