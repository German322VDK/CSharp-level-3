using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Project_send_Email.Infrastructure.Comands.Base
{
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        void ICommand.Execute(object parameter) => Execute(parameter);

        protected virtual bool CanExecute(object p) => true;

        protected abstract void Execute(object p);
    }
}
