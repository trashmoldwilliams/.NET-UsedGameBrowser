using Microsoft.AspNet.Mvc;
using UsedGameBrowser.Models;

namespace UsedGameBrowser.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var allPlatforms = Platform.GetPlatformsList();
            return View(allPlatforms);
        }

        public IActionResult PlatformGames(int id)
        {
            var platformGames = Game.GetPlatformGames(id);
            return View(platformGames);
        }

        public IActionResult GameDetails(int id)
        {
            var game = Game.GetGameDetails(id);
            game.Link = Game.GetEbayLink(game);
            return View(game);
        }
    }
}