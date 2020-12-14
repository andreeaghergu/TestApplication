using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestApplication.Viewmodels.Commands
{
    // this delegating command forwards commands to the view model
    class DelegatingCommand : ICommand
    {
        // backing fields to hold the delegates
        private readonly Action<object> action;
        private readonly Func<object, bool> canExecute;

        // forwarding constructors
        public DelegatingCommand(Action action)
            : this((o) => action())
        { }
        public DelegatingCommand(Action<object> action)
            : this(action, (o) => true)
        { }
        // save arguments to backing fields
        public DelegatingCommand(Action<object> actionArg, Func<object, bool> canExecuteArg)
        {
            action = actionArg;
            this.canExecute = canExecuteArg;
        }

        // invoked when CommandManager.RequerySuggested event is raised
        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }
        // invocation of delegated command
        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        // use with CommandManager.InvalidateRequerySuggested();
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
