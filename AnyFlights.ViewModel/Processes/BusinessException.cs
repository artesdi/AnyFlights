using System;

namespace AnyFlights.ViewModel.Processes
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage) 
            : base(errorMessage)
        {
            
        }
    }
}