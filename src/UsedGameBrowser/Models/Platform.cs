using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace UsedGameBrowser.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Platform> GetPlatformsList()
        {
            var client = new RestClient("https://www.igdb.com/api/v1/");
            var request = new RestRequest("platforms?token=ozkH_hQbsV8YA2Zk0MojOgnPlkunpS-oSCBlabKehYU&?offset=26", Method.GET);
            var response = client.Execute(request);
            Console.WriteLine(response);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
            var platformList = JsonConvert.DeserializeObject<List<Platform>>(jsonResponse["platforms"].ToString());
            return platformList;
        }
    }
}