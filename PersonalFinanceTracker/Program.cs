namespace PersonalFinanceTracker
{
    internal static class Program
    {

        // ---------------------------------------------------------------------------------------

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        // ---------------------------------------------------------------------------------------

        /// <summary>
        /// This attribute is applied to the Main method, It indicates that 
        /// the application uses a Single-Threaded Application (STA) model for
        /// COM (Component Object Model) interop. STA is required for Windows
        /// Form Applications because many UI components (such as controls and 
        /// windows) need to interact with COM objects that operate in STA mode, 
        /// which is essential for proper handling of UI threads in Windows
        /// applications.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            // ---------------------------------------------------------------------------------------

            /// <summary>
            /// This is a new method introduced in .NET 6 (and later) that allows us to
            /// configure application-wide settings in a centralized way. It can
            /// be used to customize settings such as High DPI, default font, and
            /// other UI configurations.
            /// 
            ///     - For instance, if we wanted our application to support higher DPI
            ///         settings for better display on high-resolutions screens, or if 
            ///         we wanted to set a default font for the entire application,
            ///         this is where those settings would be applied,
            ///     - Previously, this kind of configuration was done in other places, 
            ///         but starting in .NET 6, this method helps simplify and centralize
            ///         such configurations.
            /// </summary>
            ApplicationConfiguration.Initialize();

            // ---------------------------------------------------------------------------------------

            /// <summary>
            /// This starts the message loop for the Windows Forms application and opens 
            /// the first form (Form1) as the main window.
            ///     - Application.Run() - starts the Windows Forms application, creating the 
            ///                             main event loop that listens for user inputs 
            ///                             (such as clicks, key presses) and processes events.
            ///     - The message loop is essential in Windows applications becauase it
            ///         continuously processes user input and redraws the UI.
            ///     - new Form1() creates an instance of the Form1 form, which will be displayed
            ///         as the application's main window when the program starts. This window
            ///         will remain open until the user closes it, at which point the application
            ///         exits.
            /// </summary>
            Application.Run(new Form1());

            // ---------------------------------------------------------------------------------------
        }
    }
}