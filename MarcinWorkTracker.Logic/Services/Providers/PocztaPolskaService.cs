using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace MarcinWorkTracker.Logic.Services.Providers
{
    public class PocztaPolskaService : ITrackProvider
    {
        private RestClient restClient;
        private String json;

        public PocztaPolskaService()
        {
            this.restClient = new RestClient("http://192.168.1.22/PPTrackingSoapClient");
        }

        public void Track(string number)
        {
            var request = new RestRequest("Api/Track/{number}", Method.GET);
            request.AddUrlSegment("number", number);
            IRestResponse response = restClient.Execute(request);
            json = response.Content;
        }

        public string ToJson()
        {
            return json;
        }
    }
}
