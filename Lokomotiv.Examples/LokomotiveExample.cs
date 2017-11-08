using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Lokomotiv;
using Lokomotiv.Freeplan;

namespace Lokomotiv.Examples
{
    class LokomotiveExample
    {
        private static DBFreeplanClient _freeplanClient;

        static void Main(string[] args)
        {
            _freeplanClient = new DBFreeplanClient();
            
            Task.Run(() => FindLocation("Hamburg"))
                .GetAwaiter()
                .GetResult();
        }

        private static async Task FindLocation(string loc)
        {
            IList<TrainStation> locations = await _freeplanClient.FindLocation(loc);
            
            foreach(TrainStation station in locations)
                Console.WriteLine($"{station.Name} ({station.Latitude}, {station.Longitude})");
        }
    }
}
