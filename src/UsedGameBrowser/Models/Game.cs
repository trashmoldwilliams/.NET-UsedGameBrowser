using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsedGameBrowser.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AveragePrice { get; set; }
        public int PlatformId { get; set; }
        public virtual Platform Platform { get; set; }

        public override bool Equals(System.Object otherGame)
        {
            if (!(otherGame is Game))
            {
                return false;
            }
            else
            {
                Game newGame = (Game)otherGame;
                return this.GameId.Equals(newGame.GameId);
            }
        }

        public override int GetHashCode()
        {
            return this.GameId.GetHashCode();
        }
    }
}
