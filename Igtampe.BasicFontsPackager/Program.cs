using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Igtampe.BasicFontsPackager {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(Environment.GetCommandLineArgs().Length > 1) {Application.Run(new MainForm(Environment.GetCommandLineArgs()[1]));} else { Application.Run(new MainForm()); }
        }
    }
}
