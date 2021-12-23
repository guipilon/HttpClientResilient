namespace HttpClientResilient
{
    public partial class HttpClientResilient : IDisposable
    {
        private readonly HttpClient _httpClient;
        public HttpClientResilient() 
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}