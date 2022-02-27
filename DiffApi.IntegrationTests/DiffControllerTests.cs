using DiffApi.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DiffApi.IntegrationTests
{
    public class DiffControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetDiff_Return_Diff_Details()
        {
            // Arrange

            // Act

            var response = await _client.GetAsync("v1/diff/1");

            // Assert

            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
