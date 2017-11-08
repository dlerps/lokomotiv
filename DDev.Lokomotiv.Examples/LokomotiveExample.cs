using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDev.Lokomotiv;
using DDev.Lokomotiv.Freeplan;

namespace DDev.Lokomotiv.Examples
{
    class LokomotiveExample
    {
        private static DBFreeplanClient _freeplanClient;

        static void Main(string[] args)
        {
            _freeplanClient = new DBFreeplanClient();

            Task.Run(() => GetArrivals("Altona"))
                .GetAwaiter()
                .GetResult();
        }

        private static async Task FindLocation(string loc)
        {
            IList<TrainStation> locations = await _freeplanClient.FindLocation(loc);
            
            foreach(TrainStation station in locations)
                Console.WriteLine($"{station.Name} ({station.Latitude}, {station.Longitude})");
        }

        private static async Task GetArrivals(string loc)
        {
            IList<TrainStationEvent> board = await _freeplanClient.GetArrivals(loc);

            if (board.Any())
                Console.WriteLine(board[0].TrainStationName + "\n-------");

            foreach (TrainStationEvent tse in board)
                Console.WriteLine($"{tse.TrainNumber} from {tse.Origin} at {tse.DateTime:HH:MM} on platform {tse.Platform}");
        }
    }
}
