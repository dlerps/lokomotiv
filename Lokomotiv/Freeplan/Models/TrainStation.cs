using Newtonsoft.Json;

namespace Lokomotiv.Freeplan
{
    public class TrainStation
    {
        /// <summary>
        /// Id of the train station
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// the name of the train station
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The longitude value of the train stations coordinates.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
        
        /// <summary>
        /// The latitude value of the train stations coordinates.
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
    }
}