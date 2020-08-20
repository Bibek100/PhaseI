using System.Net;
using System.Threading.Tasks;
using FA20.P01.Tests.Web.Helpers;
using FA20.P01.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FA20.P01.Tests.Web
{
    [TestClass]
    public class WeatherForecastTests
    {
        private WebTestContext context;

        [TestInitialize]
        public void Init()
        {
            context = new WebTestContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Dispose();
        }

        [TestMethod]
        public async Task GetWeather_ReturnsData()
        {
            //arrange
            var webClient = context.GetStandardWebClient();

            //act
            var result = await webClient.GetAsync("weatherForecast");

            //assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = result.Content.ReadAsJsonAsync<WeatherForecast[]>();
            content.Result.Should().NotBeNull().And.HaveCount(5);
        }
    }
}
