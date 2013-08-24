using System.Collections.ObjectModel;

namespace AnyFlights.ViewModel.Entities
{
    public class FaresFullEntity
    {
        public string TotalAmount { get; private set; }
        public int SegmentsCount { get; private set; }

        public FaresFullEntity(string totalAmount,
                               int segmentsCount)
        {
            SegmentsCount = segmentsCount;
            TotalAmount = totalAmount;
        }
    }
}