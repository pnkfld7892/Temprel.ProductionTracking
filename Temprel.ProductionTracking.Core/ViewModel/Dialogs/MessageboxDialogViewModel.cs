namespace Temprel.ProductionTracking.Core
{
    ///<summary>
    ///Details for a message box dialog
    ///</summary>
    public class MessageBoxDialogViewModel
    {
        #region Public Properties
        /// <summary>
        /// Message inside box
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Text for Ok Button
        /// </summary>
        public string OkText { get; set; } = "OK";
        #endregion
    }
}
