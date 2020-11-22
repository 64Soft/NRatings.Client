namespace NRatings.Client.ApiClient
{
    public class APIClientSettings
    {
        public string ApiBaseUri { get; set; }

        public APIClientSettings(string apiBaseUri)
        {
            this.ApiBaseUri = apiBaseUri;
        }

    }
}
