using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGame002
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var model = new GameModel.Model.GameModel();
            var mainForm = new MainForm(model)
            {
                ClientSize = new Size(800, 600),
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.Fixed3D,
            };
            Application.Run(mainForm);
        }
    }
}