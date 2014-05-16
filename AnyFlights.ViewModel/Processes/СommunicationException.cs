using System;

namespace AnyFlights.ViewModel.Processes
{
    public class СommunicationException: Exception
    {
        public СommunicationException(string errorMessage) 
            : base(errorMessage)
        { }
    }
}