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
        private Form Parent;

        public UpdateWindow(XmlDocument Remote, Form Caller)
        {
            try
            {
                RemoteVersion = Remote;
                LocalInformation = new XmlDocument();
                LocalInformation.Load(Path.Combine(Application.StartupPath, "version.xml"));
                Parent = Caller;
                Parent.Enabled = false;
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
            txt_Information.Text = "Veröffentlichungsdatum: " + node.InnerText + " | " + Environment.NewLine;
            node = root.SelectSingleNode("description");
            txt_Information.Text += node.InnerText;
        }

        private void UpdateWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
    }
}
