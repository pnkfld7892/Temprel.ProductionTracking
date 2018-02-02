using System.Windows;
using System.Windows.Input;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///ViewModel for the main window
    ///</summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 1;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 1;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        private Thickness innerContentPadding;

        #endregion

        #region Public Properties
        public double WindowMinHeight { get; set; } = 650;
        public double WindowMinWidth { get; set; } = 875;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 6;
        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);


        public Thickness GetInnerContentPadding()
        {
            return innerContentPadding;
        }

        public void SetInnerContentPadding(Thickness value)
        {
            innerContentPadding = value;
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            // If it is maximized or docked, no border
            get => Borderless ? 0 : mOuterMarginSize;
            set => mOuterMarginSize = value;
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            // If it is maximized or docked, no border
            get => Borderless ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);
        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// True if we should have a dimmed overlay on the window
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        ///<summary>
        ///Default Constructor
        ///</summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
            //listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
             {
                //fire off events for all properties that are affected by a resize
                WindowResized();
             };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow,GetMousePosition()));

            //fix window resize issue
            var resizer = new WindowResizer(mWindow);

            resizer.WindowDockChanged += (dock) =>
            {
                //store last dock posistion
                mDockPosition = dock;

                //fire off resize events
                WindowResized();
            };
        }

        #endregion

        #region Private helpers

        private Point GetMousePosition()
        {
            // poistion of the mouse
            var position = Mouse.GetPosition(mWindow);

            // return point relative mouse to window
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);

        }

        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));

        }

        #endregion
    }
}
