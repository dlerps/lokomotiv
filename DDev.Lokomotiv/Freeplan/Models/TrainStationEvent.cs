using System;
using Newtonsoft.Json;

namespace DDev.Lokomotiv.Freeplan
{
    public class TrainStationEvent
    {
        /// <summary>
        /// The number identifier of the train (e.g. ICE 834)
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "name")]
        public string TrainNumber { get; set; }

        /// <summary>
        /// The name of the train model (e.g. ICE)
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string TrainType { get; set; }

        /// <summary>
        /// The id of the board
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "boardId")]
        public long BoardId { get; set; }

        /// <summary>
        /// The id of the train station
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "stopId")]
        public long TrainStationId { get; set; }

        /// <summary>
        /// The name of the train station
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "stopName")]
        public string TrainStationName { get; set; }

        /// <summary>
        /// The timestamp of this arrival event
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "dateTime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The platform on which the train is arriving
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "track")]
        public string Platform { get; set; }

        /// <summary>
        /// The details id
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "detailsId")]
        public string DetailsId { get; set; }

        /// <summary>
        /// The name of the origin train station
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }
    }
}