namespace AnyFlights.Model
{
    public class Arrival
    {
        public string AirportCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Airport { get; set; }
        public string Terminal { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DayOfWeek { get; set; }
        public object Displacement { get; set; }
    }
}