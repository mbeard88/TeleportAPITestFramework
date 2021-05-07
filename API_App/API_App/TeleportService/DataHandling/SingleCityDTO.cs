using Newtonsoft.Json;

namespace API_App.TeleportService
{
    public class SingleCityDTO
    {
        public SingleCityResponse SingleCityResponse { get; set; }
        public void DeserialiseResponse(string cityResponse)
        {
            SingleCityResponse = JsonConvert.DeserializeObject<SingleCityResponse>(cityResponse);

        }
    }
       
}
