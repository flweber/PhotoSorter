using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PhotoSorter
{
    public partial class UpdateWindow : Form
    {
        private XmlDocument LocalInformation;
        private XmlDocument RemoteVersion;

        public UpdateWindow(XmlDocument Remote)
        {
            try
            {
                RemoteVersion = Remote;
                LocalInformation = new XmlDocument();
                LocalInformation.Load(Path.Combine(Application.StartupPath, "version.xml"));
            }
            catch
            {
                this.Close();
            }
            InitializeComponent();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Updater.exe", "\"https://s3.eu-central-1.amazonaws.com/flweber-github/PhotoSorter/update/\" \"Release.zip\" \"" + Application.StartupPath + "\" \"" + Application.ExecutablePath + "\" \"" + Process.GetCurrentProcess().Id + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Leider konnte der Update Prozess nicht gestartet werden." +
                    Environment.NewLine + ex.Message + Environment.NewLine + "Bitte gehen Sie über \"Hilfe --> Fehler melden\" um uns zu informieren.", "Updater Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Later_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            XmlNode root = LocalInformation.DocumentElement;
            XmlNode node = root.SelectSingleNode("version");
            txt_Current.Text = node.InnerText;
            root = RemoteVersion.DocumentElement;
            node = root.SelectSingleNode("version");
            txt_New.Text = node.InnerText;
            node = root.SelectSingleNode("updateDate");
            txt_Information.Text = (Program.ci.TwoLetterISOLanguageName.Equals("de")) ? "Veröffentlichungsdatum: " : "Published at: " + node.InnerText + " | " + Environment.NewLine;
            node = root.SelectSingleNode("description");
            txt_Information.Text += node.InnerText;
            SetLanguage();
        }

        private void SetLanguage()
        {
            switch (Program.ci.TwoLetterISOLanguageName)
            {
                case "de":
                    Text = "Update verfügbar";
                    label1.Text = "Es ist ein Update verfügbar";
                    label2.Text = "Installierte Version:";
                    label3.Text = "Aktuelle Version:";
                    label4.Text = "Versionsinformation:";
                    btn_Later.Text = "Später";
                    break;
                case "en":
                default:
                    Text = "Update available";
                    label1.Text = "Softwareupdate available";
                    label2.Text = "Installed Version:";
                    label3.Text = "Current Version:";
                    label4.Text = "Update information:";
                    btn_Later.Text = "Wait";
                    break;
            }
        }
    }
}
