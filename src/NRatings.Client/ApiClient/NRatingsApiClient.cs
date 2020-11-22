using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using NRatings.Client.ApiClient.DTO;

namespace NRatings.Client.ApiClient
{
    public class NRatingsApiClient : ClientBase
    {
        public NRatingsApiClient(APIClientSettings settings) : base(settings)
        {
        }

        public async Task<IList<TrackType>> GetTrackTypesAsync()
        {
            var request = this.GetApiFlurlRequest();

            request.AppendPathSegment("tracktypes");

            return await request.GetJsonAsync<List<TrackType>>();

        }

        public async Task<IList<Series>> GetSeriesAsync()
        {
            var request = this.GetApiFlurlRequest();

            request.AppendPathSegment("series");

            return await request.GetJsonAsync<List<Series>>();

        }

        public async Task<IList<Race>> GetRacesAsync(int seasonId)
        {
            var request = this.GetApiFlurlRequest();

            request.AppendPathSegment("races");
            request.SetQueryParam("seasonId", seasonId);

            return await request.GetJsonAsync<List<Race>>();

        }

        public async Task<RacesDetails> GetRacesDetailsAsync(IList<int> raceIds)
        {
            var request = this.GetApiFlurlRequest();

            request.AppendPathSegment("races/details");
            return await request.PostJsonAsync(raceIds).ReceiveJson<RacesDetails>();

        }

    }
}
