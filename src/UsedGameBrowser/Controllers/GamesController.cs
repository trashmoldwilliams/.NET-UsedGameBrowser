using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using UsedGameBrowser.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace UsedGameBrowser.Controllers
{
    public class GamesController : Controller
    {
        private UsedGameBrowserContext db = new UsedGameBrowserContext();
        public IActionResult Index()
        {
            return View(db.Games.Include(games => games.Platform).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisGame = db.Games.FirstOrDefault(games => games.GameId == id);
            return View(thisGame);
        }

        public IActionResult Create()
        {
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisGame = db.Games.FirstOrDefault(games => games.GameId == id);
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "Name");
            return View(thisGame);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisGame = db.Games.FirstOrDefault(items => items.GameId == id);
            return View(thisGame);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisGame = db.Games.FirstOrDefault(items => items.GameId == id);
            db.Games.Remove(thisGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
