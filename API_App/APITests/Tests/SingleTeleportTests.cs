using NUnit.Framework;
using System;
using Newtonsoft.Json.Linq;

using API_App;
using System.Threading.Tasks;

namespace APITeleportTests.Tests

{
    public class WhenCityIsCalledWith_WithValidSlug
    {
        SingleCityService _singleCityService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singleCityService = new SingleCityService();
            await _singleCityService.MakeRequestAsync("slug:london");
        }

        [Test]
        public void CityIsReturned_WhenCityProvidedIsLondon()
        {
            Assert.That(_singleCityService.ResponseJsonContent.HasValues, Is.EqualTo(true));
     
        }
        [TestCase("east", 0.593299985f)]
        [TestCase("west", -0.9531f)]
        [TestCase("north", 51.795f)]
        [TestCase("south", 51.1776f)]
        public void CorrectGeolocationsAreReturned_WhenCityProvidedIsLondon(string compass, float latlon)
        {
            
            switch (compass)
            {
                case "east":
                    Assert.That(_singleCityService.teleportJsonResponseObject.bounding_box.latlon.east, Is.EqualTo(latlon));
                    break;
                case "west":
                    Assert.That(_singleCityService.teleportJsonResponseObject.bounding_box.latlon.west, Is.EqualTo(latlon));
                    break;
                case "north":
                    Assert.That(_singleCityService.teleportJsonResponseObject.bounding_box.latlon.north, Is.EqualTo(latlon));
                    break;
                case "south":
                    Assert.That(_singleCityService.teleportJsonResponseObject.bounding_box.latlon.south, Is.EqualTo(latlon));
                    break;
            }
        }
    }
}
