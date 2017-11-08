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
            _http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "UTF-8");

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

        /// <summary>
        /// Looks up train stations by location name
        /// </summary>
        /// <param name="locName">Location search term</param>
        /// <returns></returns>
        public async Task<IList<TrainStation>> FindLocation(string locName)
        {
            if (String.IsNullOrWhiteSpace(locName))
                throw new LokomotivException("Cannot lookup empty name");

            string reqAddr = $"{_apiBaseUrl}{_apiBasePath}location/{locName}";

            return await LokomotivHttpClient.Get<List<TrainStation>>(_http, reqAddr);
        }

        #endregion

        #region Arrivals & Departures

        /// <summary>
        /// Returns all the arrivals for a station
        /// </summary>
        /// <param name="stationId">Id of the train station</param>
        /// <param name="dateTime">Timestamp for the board</param>
        /// <returns></returns>
        public async Task<IList<TrainStationEvent>> GetArrivals(long stationId, DateTime dateTime)
        {
            return await GetTrainStationEvents(stationId, dateTime, "arrivalBoard");
        }
        
        /// <summary>
        /// Returns all arrivals for a particular station for the current local time
        /// </summary>
        /// <param name="stationId">Id of the train station</param>
        /// <returns></returns>
        public async Task<IList<TrainStationEvent>> GetArrivals(long stationId)
        {
            return await GetArrivals(stationId, DateTime.Now);
        }
        
        /// <summary>
        /// Returns all the depatures for a station
        /// </summary>
        /// <param name="stationId">Id of the train station</param>
        /// <param name="dateTime">Timestamp for the board</param>
        /// <returns></returns>
        public async Task<IList<TrainStationEvent>> GetDepartures(long stationId, DateTime dateTime)
        {
            return await GetTrainStationEvents(stationId, dateTime, "depatureBoard");
        }
        
        /// <summary>
        /// Returns all depatures for a particular station for the current local time
        /// </summary>
        /// <param name="stationId">Id of the train station</param>
        /// <returns></returns>
        public async Task<IList<TrainStationEvent>> GetDepartures(long stationId)
        {
            return await GetDepartures(stationId, DateTime.Now);
        }

        /// <summary>
        /// Inyternal method to retrieve depatures and arrivals
        /// </summary>
        /// <param name="stationId">Id of the train station</param>
        /// <param name="dateTime">The timestamp for the request</param>
        /// <param name="endpoint">arrivalBoard or depatureBoard</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the details of a journey.
        /// </summary>
        /// <param name="detailsId">The journey id can be retrieved from a arrival/depature list</param>
        /// <returns></returns>
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