using System.Runtime.CompilerServices;

namespace ComicsLoader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Download());
        }

        public static void PrintError(string caption, string message)
            => MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void PrintError(Exception exception, [CallerMemberName] string? memberName = null)
            => PrintError((memberName ?? exception.GetType().Name) + " error", exception.Message);
    }
}