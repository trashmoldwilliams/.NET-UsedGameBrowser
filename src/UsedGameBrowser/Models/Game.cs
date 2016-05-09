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

        public static List<Game> GetPlatformGames(int id)
        {
            var client = new RestClient("https://www.igdb.com/api/v1/");
            var request = new RestRequest("/platforms/" + id + "/games?token=ozkH_hQbsV8YA2Zk0MojOgnPlkunpS-oSCBlabKehYU&?offset=26", Method.GET);
            var response = client.Execute(request);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
            var platformList = JsonConvert.DeserializeObject<List<Game>>(jsonResponse["games"].ToString());
            return platformList;
        }

        public static Game GetGameDetails(int id)
        {
            var client = new RestClient("https://www.igdb.com/api/v1/");
            var request = new RestRequest("/games/" + id + "?token=ozkH_hQbsV8YA2Zk0MojOgnPlkunpS-oSCBlabKehYU", Method.GET);
            var response = client.Execute(request);
            JObject jsonresponse = (JObject)JsonConvert.DeserializeObject(response.Content);
            var game = JsonConvert.DeserializeObject<Game>(jsonresponse["game"].ToString());

            ////price
            //var client2 = new RestClient("http://open.api.ebay.com/");
            //var request2 = new RestRequest("shopping?callname=findproducts&responseencoding=json&appid=williamj-usedvide-prd-34d8cb02c-7eb407fa&siteid=0&version=525&querykeywords=" + game.name + "&availableitemsonly=true&maxentries=1", Method.GET);
            //var response2 = client2.Execute(request2);
            //JObject jsonresponse2 = (JObject)JsonConvert.DeserializeObject(response2.Content);
            //var platformlist = JsonConvert.DeserializeObject<List<Game>>(jsonresponse["games"].ToString());

            return game;
        }
    }
}