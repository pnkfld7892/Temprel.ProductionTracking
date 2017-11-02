using System;

namespace Temprel.ProductionTracking.Core
{
    ///<summary>
    ///
    ///</summary>
    public class ApplicationViewModel: BaseViewModel
    {
        private ApplicationPage applicationPage;
        /// <summary>
        /// The Current page of the application
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => applicationPage;
             private set
            {
                applicationPage = value;
            }
        }

        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">the page to go to</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;
            //CurrentPageViewModel = viewModel;

            Console.WriteLine("Current Page inside Application View Model is {0}", CurrentPage);
            //CurrentPage = page;
            applicationPage = page;
            Console.WriteLine("Current Page inside Application View Model is now {0}", CurrentPage);
            Console.WriteLine("The nameof Current Page inside Application View Model is {0}", nameof(CurrentPage));
            Console.WriteLine("-----------------------------------------------------------------------------------");

            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
