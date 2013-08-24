using System.Collections.Generic;

namespace AnyFlights.Model
{
    public class FaresFull
    {
        public Pricing Pricing { get; set; }
        public string TotalAmount { get; set; }
        public string TotalAmountNonCeiled { get; set; }
        public string Error { get; set; }
        public string Currency { get; set; }
        public string Available { get; set; }
        public Passengers Passengers { get; set; }
        public string RequestId { get; set; }
        public string FareId { get; set; }
        public object Variants { get; set; }
        public string SpecialFareCode { get; set; }
        public FaresAirline Airline { get; set; }
        public List<Direction> Directions { get; set; }
        public ReservationTimeLimit ReservationTimeLimit { get; set; }
        public bool CanMakeReservation { get; set; }
        public bool ManualMode { get; set; }
        public string ManualModeCode { get; set; }
        public int CodeShare { get; set; }
        public string MinAvailSeats { get; set; }
    }
}