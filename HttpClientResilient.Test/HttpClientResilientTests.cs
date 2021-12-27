using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientResilient.Integration.Test
{
    [TestClass]
    public class HttpClientResilientTests
    {
        private static HttpClient _httpClient;

        [ClassInitialize]
        public static void ClassInitializeAttribute(TestContext testContext) 
        { 
            _httpClient = new HttpClient();
        }

        [TestMethod]
        public void MakeGetRequest_Successful()
        {

            HttpClientResilient client = new HttpClientResilient(_httpClient);

            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new System.Uri("https://httpbin.org/ip");

            var response = client.SendResilient(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task MakeGetRequestAsync_SuccessfulAsync()
        {
            HttpClientResilient client = new HttpClientResilient(_httpClient);

            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new System.Uri("https://httpbin.org/ip");

            var response = await client.SendAsyncResilient(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanupAttribute()
        {
            _httpClient.Dispose();
        }
    }
}