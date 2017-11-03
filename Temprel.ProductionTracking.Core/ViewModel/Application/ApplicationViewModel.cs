using System;

namespace Temprel.ProductionTracking.Core
{
    ///<summary>
    ///
    ///</summary>
    public class ApplicationViewModel: BaseViewModel
    {
        /// <summary>
        /// The Current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; }

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
            CurrentPageViewModel = viewModel;

            CurrentPage = page;

            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
