using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boekhouding.Utilities
{
    public class RelayCommand<T> : ICommand     /*ook vaak base command genoemd, gebruik om de communicatie van MVVM door te geven (hier voor commands van buttons), ofwel moet je framework gebruiken hiervoor*/
    {
        private readonly Action<T> _execute = null;
        private readonly Func<T, bool> _canExecute = null;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)     //kan en mag de command uitgevoerd worden? vb button niet enabled
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);
    }

    public class RelayCommand : RelayCommand<object>        // hier type met object (2e optie is generic)
    {
        public RelayCommand(Action execute)
            : base(_ => execute()) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute()) { }
    }
}
