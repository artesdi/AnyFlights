using System.Collections.Generic;

namespace AnyFlights.Model
{
    public class Segment
    {
        public int Id { get; set; }
        public string TravelTime { get; set; }
        public List<Trip> Trips { get; set; }
        public object MinAvailableSeats { get; set; }
    }
}