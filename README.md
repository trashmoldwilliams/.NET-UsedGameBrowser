# Used Game Browser

This is a work in progress .NET site, a devoted browser for used games using the eBay or Amazon API. The current build has basic database relations to eventually handle outputs from an API, but will be modified in the coming weeks.

## Prerequisites

You will need the following things properly installed on your computer.

* [Git](http://git-scm.com/)
* [Microsoft SQL Server Management Studio](https://msdn.microsoft.com/en-us/library/mt238290.aspx)
* [Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)

## Installation

* `git clone <https://github.com/trashmoldwilliams/UsedGameBrowser.git>`
* open UsedGameBrowser.sql and create database
* after bulding, in project folder, run:
  * dnx ef migrations add Initial -c ApplicationDbContext
  * dnx ef database update -c ApplicationDbContext
* open project file in visual studio and run
