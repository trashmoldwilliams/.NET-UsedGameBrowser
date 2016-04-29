using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsedGameBrowser.Models;
using Xunit;

namespace UsedGameBrowser.Tests
{
    public class GameTest
    {
        [Fact]
        public void GetTitleTest()
        {
            //Arrange
            var game = new Game();
            game.Title = "Super Metroid";

            //Act
            var result = game.Title;

            //Assert
            Assert.Equal("Super Metroid", result);
        }

        [Fact]
        public void GetPriceTest()
        {
            //Arrange
            var game = new Game();
            game.AveragePrice = 10;

            //Act
            var result = game.AveragePrice;

            //Assert
            Assert.Equal(10, result);
        }


    }
}
