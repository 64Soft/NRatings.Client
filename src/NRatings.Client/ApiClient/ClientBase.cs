using Flurl.Http;

namespace NRatings.Client.ApiClient
{
    public abstract class ClientBase
    {
        protected APIClientSettings settings;

        protected ClientBase(APIClientSettings settings)
        {
            this.settings = settings;
        }

        protected IFlurlRequest GetApiFlurlRequest()
        {
            var request = new FlurlRequest(this.settings.ApiBaseUri);

            return request;
        }
    }
}
