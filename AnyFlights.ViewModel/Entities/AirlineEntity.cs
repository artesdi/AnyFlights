using System.Collections.ObjectModel;

namespace AnyFlights.ViewModel.Entities
{
    public class AirlineEntity
    {
        public string Name { get; private set; }
        public bool HasTrips { get; private set; }
        public ReadOnlyCollection<FaresFullEntity> Fares { get; private set; }

        public AirlineEntity(string name, ReadOnlyCollection<FaresFullEntity> faresFull, bool hasTrips)
        {
            Name = name;
            Fares = faresFull;
            HasTrips = hasTrips;
        }
    }
}