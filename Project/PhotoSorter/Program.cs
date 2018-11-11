using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PhotoSorter
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CheckforUpdates();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainTool());
        }

        private static void CheckforUpdates()
        {
            XmlDocument Local = new XmlDocument();
            XmlDocument Web = new XmlDocument();
            XmlNode lroot, wroot, lnode, wnode;
            Local.Load(Path.Combine(Application.StartupPath, "version.xml"));
            Web.Load("https://s3.eu-central-1.amazonaws.com/flweber-github/PhotoSorter/update/version.xml");
            lroot = Local.DocumentElement;
            wroot = Web.DocumentElement;
            lnode = lroot.SelectSingleNode("version");
            wnode = wroot.SelectSingleNode("version");
            string localVersion = lnode.InnerText;
            string remoteVersion = wnode.InnerText;
            if (!localVersion.Equals(remoteVersion))
                Process.Start("Updater.exe", "\"https://s3.eu-central-1.amazonaws.com/flweber-github/PhotoSorter/update/\" \"Release.zip\" \""+Application.StartupPath+"\" \""+Application.ExecutablePath+"\" \""+Process.GetCurrentProcess().Id+"\"");
        }
    }
}
