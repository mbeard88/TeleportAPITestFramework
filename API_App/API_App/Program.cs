using System;
using Newtonsoft.Json.Linq;
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

            var cityId = "geonameid:1796236";

            restRequest.Resource = $"api/cities/{cityId}/";

            var restResponse = restClient.Execute(restRequest);

            //Console.WriteLine("Response content (string):");
            //Console.WriteLine(restResponse.Content);
            Console.WriteLine("\n\n\n\n");

            var jsonResponse = JObject.Parse(restResponse.Content);
            Console.WriteLine("\nRespone content as JObject");
            Console.WriteLine(jsonResponse);

            var cityName = jsonResponse["name"];
            var urbanArea = jsonResponse["_links"]["curies"][2]["name"];
            Console.WriteLine(cityName);
            Console.WriteLine(urbanArea);
            var geonameId = jsonResponse["geoname_id"];
            var lat = jsonResponse["location"]["latlon"]["latitude"];
            var lon = jsonResponse["location"]["latlon"]["longitude"];
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
            //Console.WriteLine(response.Content);






            //Console.WriteLine("Response content (string):");
            //Console.WriteLine(restResponse.Content);
            Console.WriteLine("\n\n\n\n");
            jsonResponse = JObject.Parse(response.Content);
            Console.WriteLine("\nRespone content as JObject");
            Console.WriteLine(jsonResponse);


            foreach (var i in jsonResponse["result"]) {
                var adminDistrict = i["result"]["admin_district"];
                var pPostCode = i["result"]["postcode"];
                Console.WriteLine(adminDistrict);
                Console.WriteLine(pPostCode);
            }
            //var geonameId = jsonResponse["geoname_id"];
            //var lat = jsonResponse["location"]["latlon"]["latitude"];
            //var lon = jsonResponse["location"]["latlon"]["longitude"];



            // POST example using postcodes

            //var client = new RestClient("https://api.postcodes.io/postcodes");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "__cfduid=d07ff89d6ceb11516cec847fedae7636c1619439989");
            //request.AddParameter("application/json", "{\r\n  \"postcodes\" : [\"PR3 0SG\", \"M45 6GN\", \"EX165BL\"]\r\n}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
        }
    }
}
