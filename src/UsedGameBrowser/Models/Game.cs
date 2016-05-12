using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace UsedGameBrowser.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }
        public string Footage { get; set; }

        public static List<Game> GetPlatformGames(int id)
        {
            var offset = 0;
            List<Game> gameList = new List<Game>();
            for (int i = 0; i < 50; i++)
            {
                var client = new RestClient("https://www.igdb.com/api/v1/");
                var request = new RestRequest("platforms/" + id + "/games?offset=" + offset + "&token=" + EnvironmentVariables.AuthToken, Method.GET);
                offset += 25;
                var response = client.Execute(request);
                JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
                var addItem = JsonConvert.DeserializeObject<List<Game>>(jsonResponse["games"].ToString());
                foreach (Game item in addItem)
                {
                    gameList.Add(item);
                } 
            }
            return gameList;
        }

        public static Game GetGameDetails(int id)
        {
            var client = new RestClient("https://www.igdb.com/api/v1/");
            var request = new RestRequest("games/" + id + "?token=" + EnvironmentVariables.AuthToken, Method.GET);
            var response = client.Execute(request);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
            var game = JsonConvert.DeserializeObject<Game>(jsonResponse["game"].ToString());
            return game;
        }

        public static string GetEbayLink(Game game)
        {
            var formattedName = Uri.EscapeUriString(game.Name);
            var url = "http://www.ebay.com/sch/Video%20Game%20" + formattedName;
            return url;
        }

        public static string GetYoutubeLink(Game game)
        {
            var formattedName = Uri.EscapeUriString(game.Name);
            var url = "http://m.youtube.com/results?q=Longplay%20" + formattedName;
            return url;
        }

        public static string SearchGames(string search)
        {
            var formattedSearch = Uri.EscapeUriString(search);
            var client = new RestClient("https://www.igdb.com/api/v1/");
            var request = new RestRequest("/games/search?q=" + formattedSearch + "&token=" + EnvironmentVariables.AuthToken, Method.GET);
            var response = client.Execute(request);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
            var addItem = JsonConvert.DeserializeObject<List<Game>>(jsonResponse["games"].ToString());
            var output = "";
            foreach (Game item in addItem)
            {
                output += "<li> <a href='/Home/GameDetails/" + item.Id + "' target='_blank'>" + item.Name + "</a> </li>";
            }
            return output;
        }
    }
}