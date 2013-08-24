namespace AnyFlights.Model
{
    public class Trip
    {
        public string Class { get; set; }
        public string ReservationType { get; set; }
        public string FlightNumber { get; set; }
        public string FlightDuration { get; set; }
        public string OnEarth { get; set; }
        public int Stops { get; set; }
        public object Airline { get; set; }
        public Carrier Carrier { get; set; }
        public Plane Plane { get; set; }
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
    }
}