using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsedGameBrowser.Controllers;
using UsedGameBrowser.Models;
using Xunit;

namespace UsedGameBrowser.Tests
{
    public class GamesControllerTest
    {
        [Fact]
        public void Post_MethodAddsGames_Test()
        {
            // Arrange
            GamesController controller = new GamesController();
            Game testGame = new Game();
            Platform testPlatform = new Platform();


            testPlatform.PlatformId = 1;
            testPlatform.Name = "Console";
            testPlatform.Description = "Xbox";
            testPlatform.AveragePrice = 15;

            testGame.Title = "SSB";
            testGame.AveragePrice = 10;
            testGame.Description = "Awesome game super broken as link.";
            testGame.PlatformId = 1;

            testGame.Platform = testPlatform;


            // Act
            controller.Create(testGame);
            ViewResult indexView = new GamesController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Game>;

            // Assert
            Assert.Contains<Game>(testGame, collection);
        }

    }
}



