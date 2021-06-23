using System;
using System.Windows.Input;

namespace FileExplorer.Core
{
    /// <summary>
    /// A basic command to run an Action.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to run.
        /// </summary>
        private readonly Action _action;

        /// <summary>
        /// The event thats fired when <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action) => _action = action;

        /// <summary>
        /// Always can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Execute the command action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => _action();
    }
}
