using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using API_App.TeleportService;

namespace API_App.TeleportService
{
    public class SingleCityService
    {
        #region Properties

        public CallManager CallManager { get; }
        // Newtonsoft object for JSON response
        public JObject ResponseJsonContent { get; set; }

        public SingleCityDTO SingleCityDTO { get; set; }

        // the City used in the API call
        public string CitySelected   { get; set;}

        public string CityResponse { get; set; }

        #endregion


        // constructor - creates RestClient
        public SingleCityService()
        {
            CallManager = new CallManager();
            SingleCityDTO = new SingleCityDTO();

        }

        public int CountInResponse()
        {
            return ResponseJsonContent.Count;
        }

        public async Task MakeRequestAsync(string slug)
        {
            CitySelected = slug;
            // make request
            CityResponse = await CallManager.MakeCityRequest(slug);

            ResponseJsonContent = JObject.Parse(CityResponse);


            ResponseJsonContent = JObject.Parse(CityResponse);

            SingleCityDTO.DeserialiseResponse(CityResponse);


        }
    }

   

}
