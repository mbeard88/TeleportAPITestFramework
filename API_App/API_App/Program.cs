using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace API_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("https://api.teleport.org/");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Content-Type", "application/json");
            //Don't timeout
            restRequest.Timeout = -1;

            var city = "slug:shanghai";

            restRequest.Resource = $"api/urban_areas/{city}/";

            var restResponse = restClient.Execute(restRequest);

            var teleportJsonResponse = JObject.Parse(restResponse.Content);
            

            var teleportJsonResponseObject = JsonConvert.DeserializeObject<TeleportResponse>(restResponse.Content);

            var uaName = teleportJsonResponseObject._links.curies[2].name;
            var cityName = teleportJsonResponseObject.name;
            //var latitude = teleportJsonResponseObject.
            // JSON access method
            //var cityName = teleportJsonResponse["name"];
            //var urbanArea = teleportJsonResponse["_links"]["curies"][2]["name"];
            Console.WriteLine(uaName);
            Console.WriteLine(cityName);
            var geonameId = teleportJsonResponse["geoname_id"];
            teleportJsonResponseObject = JsonConvert.DeserializeObject<TeleportResponse>(restResponse.Content);
            float geoN = teleportJsonResponseObject.bounding_box.latlon.north;
            float geoS = teleportJsonResponseObject.bounding_box.latlon.south;
            float geoE = teleportJsonResponseObject.bounding_box.latlon.east;
            float geoW = teleportJsonResponseObject.bounding_box.latlon.west;
            //string lat = 
            //string lon = teleportJsonResponse["location"]["latlon"]["longitude"];
            Console.WriteLine("\n\n\n\n");

            restClient = new RestClient("https://api.postcodes.io/postcodes");

            restRequest.Method = Method.POST;
            restRequest.AddHeader("Content-Type", "application/json");
            //Don't timeout
            restRequest.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "__cfduid=d07ff89d6ceb11516cec847fedae7636c1619439989");
            request.AddParameter("application/json", "{\r\n  \"postcodes\" : [\"PR3 0SG\", \"M45 6GN\", \"EX165BL\"]\r\n}", ParameterType.RequestBody);
            IRestResponse response = restClient.Execute(request);

            Console.WriteLine("\n\n\n\n");
            var bulkResponse = JObject.Parse(response.Content);



            
            var bulkJsonResponseObject = JsonConvert.DeserializeObject<BulkPostcodesResponse>(response.Content);

            
            var adminDistrict = bulkJsonResponseObject.result[1].result.admin_district;


        }
    }
}
