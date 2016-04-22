using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsedGameBrowser.Models
{
    [Table("Platforms")]
    public class Platform
    {
        public Platform()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AveragePrice { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
