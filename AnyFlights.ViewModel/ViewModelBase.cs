using System.ComponentModel;
using AnyFlights.ViewModel.Utils;

namespace AnyFlights.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                SmartDispatcher.BeginInvoke(() => handler(this, new PropertyChangedEventArgs(propertyName)));
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            protected set
            {
                if (value.Equals(_isBusy)) return;
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
    }
}