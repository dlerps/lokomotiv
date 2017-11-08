using System;
using Newtonsoft.Json;

namespace DDev.Lokomotiv.Freeplan
{
    public class JourneyEvent
    {
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
        /// The latitude value of the train stations coordinates.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude value of the train stations coordinates.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "lon")]
        public string Longitude { get; set; }

        /// <summary>
        /// The time of the depature at the train station.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "depTime")]
        public string DepatureTime { get; set; }

        /// <summary>
        /// The number identifier of the train (e.g. ICE 834)
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "train")]
        public string TrainNumber { get; set; }

        /// <summary>
        /// The name of the train model (e.g. ICE)
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string TrainType { get; set; }

        /// <summary>
        /// The name of the operator
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Notes for this journey
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "notes")]
        public Note[] Notes { get; set; }
    }
}