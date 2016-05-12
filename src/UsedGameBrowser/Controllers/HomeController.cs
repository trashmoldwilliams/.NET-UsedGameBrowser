using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using UsedGameBrowser.Models;
using UsedGameBrowser.ViewModels;

namespace UsedGameBrowser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

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
            game.Footage = Game.GetYoutubeLink(game);
            return View(game);
        }

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult SearchGames(string search)
        {
            var output = Game.SearchGames(search);
            return Json(output);
        }
    }
}