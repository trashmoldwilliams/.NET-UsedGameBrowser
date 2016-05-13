# Used Game Browser

This application browses a library of video games using the IGDB API, and will bring up Ebay search results and Youtube footage of a selected game.

Using the https://www.igdb.com/ API.


## Prerequisites

You will need the following things properly installed on your computer.

* [Git](http://git-scm.com/)
* [Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)
* API Key from https://www.igdb.com/api/v1/documentation

## Installation

* `git clone <https://github.com/trashmoldwilliams/UsedGameBrowser.git>`
* open and build project in Visual Studio
* `cd .NET-UsedGameBrowser/src/UsedGameBrowser`
* `dnx ef database update`
* create Class file "EnvironmentVariables.cs" in the Models folder of the project:

  namespace UsedGameBrowser.Models
  {
    public static class EnvironmentVariables
    {
        public static string AuthToken = "YOUR-API-KEY-HERE";
    }
  }

* run the project using Visual Studio
