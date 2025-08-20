using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> onExecute, Func<object, bool> canExecute)
        {
            _canExecute = canExecute;
            _onExecute = onExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {

                CommandManager.RequerySuggested += value;

            }
            remove
            {

                CommandManager.RequerySuggested -= value;

            }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
                _onExecute(parameter);
        }
        private readonly Action<object> _onExecute;
        private readonly Func<object, bool> _canExecute;
    }
}
