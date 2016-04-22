using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using UsedGameBrowser.Models;

namespace UsedGameBrowser.Controllers
{
    public class GamesController : Controller
    {
        private UsedGameBrowserContext db = new UsedGameBrowserContext();
        public IActionResult Index()
        {
            return View(db.Games.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisGame = db.Games.FirstOrDefault(games => games.GameId == id);
            return View(thisGame);
        }
    }
}
