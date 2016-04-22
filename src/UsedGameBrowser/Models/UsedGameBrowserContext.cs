using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsedGameBrowser.Models
{
    public class UsedGameBrowserContext : DbContext
    {
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UsedGameBrowser;integrated security = True");
        }
    }
}
