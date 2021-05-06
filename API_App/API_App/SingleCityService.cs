using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace API_App
{
    public class SingleCityService
    {
        #region Properties

        // Restsharp object for API
        public RestClient Client;

        // Newtonsoft object for JSON response
        public JObject ResponseJsonContent { get; set; }

        public TeleportResponse teleportJsonResponseObject { get; set; }

        // the City used in teh API call
        public string CitySelected   { get; set;}

        #endregion


        // constructor - creates RestClient
        public SingleCityService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };

        }

        public async Task MakeRequestAsync(string slug)
        {

            // Setup request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var city = slug;

            // define request resource
            request.Resource = $"api/urban_areas/{city}/";

            // make request
            IRestResponse response = await Client.ExecuteAsync(request);

            ResponseJsonContent = JObject.Parse(response.Content);

            teleportJsonResponseObject = JsonConvert.DeserializeObject<TeleportResponse>(response.Content);


        }
    }

   

}
