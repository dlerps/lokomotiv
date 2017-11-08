using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDev.Lokomotiv.Net
{
    internal static class LokomotivHttpClient
    {
        public static async Task<RType> Get<RType>(HttpClient http, string url)
        {
            try
            {
                HttpResponseMessage response = await http.GetAsync(url);

                // the response indicates an error
                if (!response.IsSuccessStatusCode)
                    throw new LokomotivException($"{response.StatusCode} error calling the DB Api");

                string jsonBody = await response.Content.ReadAsStringAsync();

                // did not receive any response body
                if (String.IsNullOrEmpty(jsonBody))
                    throw new LokomotivException("Received empty response from DB Api");

                RType rtype = JsonConvert.DeserializeObject<RType>(jsonBody);

                // can't deserialise response body
                if (rtype == null)
                    throw new LokomotivException("Received invalid response body from DB Api");

                return rtype;
            }
            catch(Exception ex)
            {
                if (ex.GetType().Name == "LokomotivException")
                    throw ex;
                else
                    throw new LokomotivException("Error accesing the DB Api", ex);
            }
            
        }
    }
}