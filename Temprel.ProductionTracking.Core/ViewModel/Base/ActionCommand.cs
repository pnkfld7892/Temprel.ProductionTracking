using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    /// <summary>
    /// An ActionCommand takes a predicate to see if it can execute or not
    /// Will notify the CommandManager if can execute is valid or not.
    /// </summary>
   public class ActionCommand : ICommand
    {
        #region Private Members
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;
        #endregion

        #region Ctor
        public ActionCommand(Action<Object> action) : this(action, null)
        {

        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), "You must specify and action<T>");
            this.action = action;
            this.predicate = predicate;
        }

        #endregion

        #region Methods/Events
        public bool CanExecute(object parameter)
        {
            return predicate == null ? true : predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

        public event EventHandler CanExecuteChanged
        {
            //Allowing the CommandManager to automatically enable and disable button on the UI
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        } 
        #endregion

    }
}
