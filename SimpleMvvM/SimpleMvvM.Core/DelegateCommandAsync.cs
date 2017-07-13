using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMvvM.Core
{
    public class DelegateCommandAsync : ICommand
    {
        private readonly Func<Task<bool>> _canExecute;
        private readonly Func<Task> _execute;

        public DelegateCommandAsync(Func<Task> execute) : this(execute, null)
        {
        }

        public DelegateCommandAsync(Func<Task> execute, Func<Task<bool>> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute().Result;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var tmpHandle = CanExecuteChanged;
            tmpHandle?.Invoke(this, new EventArgs());
        }
    }

    public class DelegateCommandAsync<T> : ICommand
    {
        private readonly Func<T, Task<bool>> _canExecute;
        private readonly Func<T, Task> _execute;

        public DelegateCommandAsync(Func<T, Task> execute) : this(execute, null)
        {
        }

        public DelegateCommandAsync(Func<T, Task> execute, Func<T, Task<bool>> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter).Result;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var tmpHandle = CanExecuteChanged;
            tmpHandle?.Invoke(this, new EventArgs());
        }
    }
}