using System;
using System.ComponentModel;
using System.Windows.Input;
using AnyFlights.ViewModel.Utils;

namespace AnyFlights.ViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _executeAction;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action executeAction)
        {
            if (executeAction == null) throw new ArgumentNullException("executeAction");
            _executeAction = executeAction;
        }

        public RelayCommand(Action executeAction, Func<bool> canExecute)
            : this(executeAction)
        {
            if (canExecute == null) throw new ArgumentNullException("canExecute");
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute();
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}