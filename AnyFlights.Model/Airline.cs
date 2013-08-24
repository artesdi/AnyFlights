using System.Collections.Generic;

namespace AnyFlights.Model
{
    public class Airline
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public object Fares { get; set; }
        public List<FaresFull> FaresFull { get; set; }
    }
}