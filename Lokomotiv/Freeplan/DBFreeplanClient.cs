using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;

using Lokomotiv.Net;

namespace Lokomotiv.Freeplan
{
    public class DBFreeplanClient
    {
        private string _apiToken;
        private string _apiBaseUrl;
        private string _apiBasePath;

        private HttpClient _http;

        #region Constructors

        public DBFreeplanClient() : this(null)
        {
        }

        public DBFreeplanClient(string apiAccessToken)
        {
            _http = new HttpClient();
            _apiBaseUrl = "https://api.deutschebahn.com/";
            _apiBasePath = "freeplan/v1/";

            if (!String.IsNullOrWhiteSpace(apiAccessToken))
            {
                _apiToken = apiAccessToken;
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiAccessToken);
            }
        }

        #endregion

        #region Locations

        public async Task<IList<TrainStation>> FindLocation(string locName)
        {
            if (String.IsNullOrWhiteSpace(locName))
                throw new LokomotivException("Cannot lookup empty name");

            string reqAddr = $"{_apiBaseUrl}{_apiBasePath}location/{locName}";

            return await LokomotivHttpClient.Get<List<TrainStation>>(_http, reqAddr);
        }

        #endregion

        #region Arrivals & Departures

        public async Task<IList<TrainStationEvent>> GetArrivals(long stationId, DateTime dateTime)
        {
            return await GetTrainStationEvents(stationId, dateTime, "arrivalBoard");
        }
        
        public async Task<IList<TrainStationEvent>> GetArrivals(long stationId)
        {
            return await GetArrivals(stationId, DateTime.Now);
        }
        
        public async Task<IList<TrainStationEvent>> GetDepartures(long stationId, DateTime dateTime)
        {
            return await GetTrainStationEvents(stationId, dateTime, "depatureBoard");
        }
        
        public async Task<IList<TrainStationEvent>> GetDepartures(long stationId)
        {
            return await GetDepartures(stationId, DateTime.Now);
        }

        private async Task<IList<TrainStationEvent>> GetTrainStationEvents(
            long stationId, 
            DateTime dateTime, 
            string endpoint)
        {
            string dt = dateTime.ToString("s", CultureInfo.InvariantCulture);
            string reqAddr = $"{_apiBaseUrl}{_apiBasePath}{endpoint}/{stationId}?date={dt}";
            
            return await LokomotivHttpClient.Get<List<TrainStationEvent>>(_http, reqAddr);
        }

        #endregion

        #region Journeys

        public async Task<IList<JourneyEvent>> GetJourneyDetails(string detailsId)
        {
            if (String.IsNullOrWhiteSpace(detailsId))
                throw new LokomotivException("Cannot lookup empty name");

            string reqAddr = $"{_apiBaseUrl}{_apiBasePath}journeyDetails/{detailsId}";

            return await LokomotivHttpClient.Get<List<JourneyEvent>>(_http, reqAddr);
        }

        #endregion
    }
}