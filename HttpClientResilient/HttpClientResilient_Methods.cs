namespace HttpClientResilient
{
    public partial class HttpClientResilient
    {
        public HttpResponseMessage SendResilient(HttpRequestMessage request)
        {
            var response = _httpClient.Send(request);

            return response;
        }

        public async Task<HttpResponseMessage> SendAsyncResilient(HttpRequestMessage request)
        {
            var result = await _httpClient.SendAsync(request);

            return result;
        }
    }
}