using Polly;
using Polly.Retry;
using System.Net;

namespace HttpClientResilient
{
    public partial class HttpClientResilient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private AsyncRetryPolicy _retryPolicy;

        public HttpClientResilient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, retryAttempt => {
                    var timeToWait = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                    Console.WriteLine($"Waiting {timeToWait.TotalSeconds} seconds");
                    return timeToWait;
                }
                );
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}