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
            var offset = 0;
            List<Platform> platformList = new List<Platform>();
            for (int i = 0; i < 5; i++)
            {
                var client = new RestClient("https://www.igdb.com/api/v1/");
                var request = new RestRequest("platforms?token=" + EnvironmentVariables.AuthToken + "&offset=" + offset, Method.GET);
                offset += 25;
                var response = client.Execute(request);
                JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
                var addItem = JsonConvert.DeserializeObject<List<Platform>>(jsonResponse["platforms"].ToString());
                foreach ( Platform item in addItem)
                {
                    platformList.Add(item);
                }  
            }

            return platformList;
        }
    }
}