using System;
using Newtonsoft.Json;

namespace Lokomotiv.Freeplan
{
    public class Note
    {
        /// <summary>
        /// The key of the note
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// The priority of the note
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }

        /// <summary>
        /// The note's text
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}