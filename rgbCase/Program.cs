using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rgbCase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();

            if (args.Contains("m") || args.Contains("-m") || args.Contains("/m") || args.Contains("\\m"))
                form.HideOnLaunch = true;

            Application.Run(form);
        }
    }
}
