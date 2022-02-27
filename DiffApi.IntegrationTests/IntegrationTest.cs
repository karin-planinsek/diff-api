using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace DiffApi.IntegrationTests
{
    public class IntegrationTest
    {
        public readonly HttpClient _client;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }
    }
}