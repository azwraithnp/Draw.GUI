using Draw.GUIMVP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StreamReader strm = new StreamReader("userinfo.txt");
            string jsonString = strm.ReadToEnd();

            dynamic jsonParsed = System.Web.Helpers.Json.Decode(jsonString);
            string theme = jsonParsed.Theme;
            string root = jsonParsed.Root;
            string recentFile = jsonParsed.Recentfile;

            UserInfo user = new UserInfo();
            user.Theme = theme;
            user.Root = root;
            user.Recentfile = recentFile;

            strm.Close();
            strm.Dispose();

            Application.Run(new WelcomeForm());
        }
    }
}
