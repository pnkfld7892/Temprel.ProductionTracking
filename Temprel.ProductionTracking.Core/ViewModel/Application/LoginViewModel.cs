using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class LoginViewModel : BaseViewModel
    {
        #region public properties
        /// <summary>
        /// The user's user ID
        /// </summary>
        public string UserId { get; set; }

        public string TestText { get; set; }

        public int Count { get; set; }
        
        /// <summary>
        /// Flag indicating if login proceudre is currently running
        /// </summary>
        public bool LoginIsRunning { get; set; }
        #endregion

        #region Commmands
        /// <summary>
        /// Command for xaml to interface with for login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
        }

        private async Task LoginAsync(object parameter)
        {
            Count++;
            TestText = Count.ToString();
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                //TODO: Login Logic once a scheme is decided on

                IoC.Application.GoToPage(ApplicationPage.SalesOrder, new SalesOrderViewModel());
            });
        }
        #endregion

    }
}
