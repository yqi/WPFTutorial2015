using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Common.ViewModels
{
    //// MvvmLight implementation (?)
    //public class RelayCommand<T> : ICommand
    //{
    //    private read only Action<T> _Action;
    //    private read only Predicate<T> _CanExecute;

    //    public RelayCommand(Action<T> action)
    //        : this(action, null)
    //    {
    //    }

    //    public RelayCommand(Action<T> action, Predicate<T> canExecute)
    //    {
    //        _Action = action;
    //        _CanExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        if (_CanExecute == null)
    //            return true;

    //        return _CanExecute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _Action((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public void RaiseCanExecuteChanged()
    //    {
    //        if (CanExecuteChanged != null)
    //            CanExecuteChanged(this, EventArgs.Empty);
    //    }
    //}

    // Josh Smith implementation
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion ICommand Members
    }

    // My change - based above two
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _Action;
        private readonly Predicate<T> _CanExecute;

        public RelayCommand(Action<T> action)
            : this(action, null)
        {
        }

        public RelayCommand(Action<T> action, Predicate<T> canExecute)
        {
            _Action = action;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute == null)
                return true;

            return _CanExecute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public void Execute(object parameter)
        {
            _Action((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}