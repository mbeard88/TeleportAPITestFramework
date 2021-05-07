using System;
using System.Threading.Tasks;
using RestSharp;

namespace API_App.TeleportService
{
    public class CallManager
    {
        // Restsharp object that handles API comms
        readonly IRestClient _client;

        public IRestResponse response { get; set;  }
        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        /// <summary>
        /// defines and makes API request and stores the response
        /// </summary>
        /// <param name="slug">The slug is a key value pair e.g. slug:shanghai</param>
        /// <returns>The response</returns>
        public async Task<string> MakeCityRequest(string slug)
        {
            // Setup request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var city = slug;

            // define request resource
            request.Resource = $"api/urban_areas/{city}/";

            // make request
            response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
