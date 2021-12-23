namespace HttpClientResilient
{
    public partial class HttpClientResilient
    {
        public Uri? BaseAddress 
        { 
            get { return _httpClient.BaseAddress;  }
            set { _httpClient.BaseAddress = value; }
        }
    }
}