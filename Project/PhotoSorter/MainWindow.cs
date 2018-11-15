﻿using System;
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
    public partial class MainTool : Form
    {
        private Settings frmSettings;
        private string updateError;
        private string runningProcessWarning;
        private string processError;

        public MainTool()
        {
            InitializeComponent();
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode root, node;
                doc.Load("version.xml");
                root = doc.DocumentElement;
                node = root.SelectSingleNode("version");
                Text += " - " + node.InnerText;
            }
            catch
            {
                // Wenn es einen Fehler gibt wird die Version eben nicht angezeigt
            }
            btn_Settings.TabStop = false;
            btn_Settings.FlatStyle = FlatStyle.Flat;
            btn_Settings.FlatAppearance.BorderSize = 0;
            frmSettings = new Settings(this);
        }

        /// <summary>
        /// Aktiviert bzw. deaktiviert den Startbutton
        /// </summary>
        private void Kontrolle()
        {
            if (String.IsNullOrWhiteSpace(txt_Quelle.Text) || String.IsNullOrWhiteSpace(txt_Ziel.Text) || String.IsNullOrWhiteSpace(txt_Urlaubsziel.Text) || backgroundWorker1.IsBusy)
            {
                btn_Start.Enabled = false;

            }
            else
            {
                btn_Start.Enabled = true;
            }

            btn_QuellWahl.Enabled = !backgroundWorker1.IsBusy;
            btn_Zielwahl.Enabled = !backgroundWorker1.IsBusy;
            txt_Urlaubsziel.Enabled = !backgroundWorker1.IsBusy;

            if(frmSettings.rb_DateRange.Checked)
            {
                dtp_Vom.Enabled = !backgroundWorker1.IsBusy;
                dtp_Bis.Enabled = !backgroundWorker1.IsBusy;
            }
        }

        private void btn_QuellWahl_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && !String.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                txt_Quelle.Text = folderBrowserDialog1.SelectedPath;
            }
            Kontrolle();
        }

        private void btn_Zielwahl_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && !String.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                txt_Ziel.Text = folderBrowserDialog1.SelectedPath;
            }
            Kontrolle();
        }

        private void txt_Urlaubsziel_TextChanged(object sender, EventArgs e) => Kontrolle();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int n = 1;
            string check_folder = txt_Urlaubsziel.Text;
           
            while (Directory.Exists(@txt_Ziel.Text + "\\" + check_folder))
                check_folder = txt_Urlaubsziel.Text + "-" + n++;

            string Zielpfad = @txt_Ziel.Text + "\\" + check_folder;

            try
            {
                Directory.CreateDirectory(Zielpfad);
                List<string> files = Directory.GetFiles(txt_Quelle.Text).ToList();
                int counter = 1;
                foreach(string file in files)
                {
                    if(file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg") 
                        || file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".tif") 
                        || file.ToLower().EndsWith(".bmp") || file.ToLower().EndsWith(".gif") 
                        || file.ToLower().EndsWith(".raw"))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if((frmSettings.rb_CreationDate.Checked && fileInfo.CreationTime.Date >= dtp_Vom.Value.Date && fileInfo.CreationTime.Date <= dtp_Bis.Value.Date)
                            || (frmSettings.rb_ModifiedatDate.Checked && fileInfo.LastWriteTime.Date >= dtp_Vom.Value.Date && fileInfo.LastWriteTime.Date <= dtp_Bis.Value.Date) 
                            || frmSettings.rb_AllImages.Checked)
                        {
                            if (frmSettings.rb_CreationDate.Checked && !Directory.Exists(Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy")))
                                Directory.CreateDirectory(Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy"));
                            else if(frmSettings.rb_ModifiedatDate.Checked && !Directory.Exists(Zielpfad + "\\" + fileInfo.LastWriteTime.ToString("dd-MM-yyyy")))
                                Directory.CreateDirectory(Zielpfad + "\\" + fileInfo.LastWriteTime.ToString("dd-MM-yyyy"));

                            n = 1;
                            string fullfilepath = Zielpfad + "\\";

                            if (frmSettings.rb_CreationDate.Checked)
                                fullfilepath += fileInfo.CreationTime.ToString("dd-MM-yyyy");
                            else if (frmSettings.rb_ModifiedatDate.Checked)
                                fullfilepath += fileInfo.LastWriteTime.ToString("dd-MM-yyyy");

                            fullfilepath += "\\" + fileInfo.Name;

                            while (File.Exists(fullfilepath))
                            {
                                string Filename = fileInfo.Name.Split('.')[0] + "-" + n + "." + fileInfo.Extension;
                                fullfilepath = Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy") + "\\" + Filename;
                                n++;
                            }

                            if (frmSettings.rb_Copy.Checked)
                                File.Copy(file, fullfilepath);
                            else if (frmSettings.rb_Cut.Checked)
                                File.Move(file, fullfilepath);
                        }
                    }
                    double percent = ((double)counter / (double)files.Count) * (double)100;
                    backgroundWorker1.ReportProgress((int)percent);
                    counter++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(processError + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl_prozentanzeige.Text = e.ProgressPercentage + "%";
            Kontrolle();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            Kontrolle();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            lbl_prozentanzeige.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            Kontrolle();
        }

        private void MainTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                DialogResult dialog = MessageBox.Show(runningProcessWarning, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            frmSettings.StartPosition = FormStartPosition.Manual;
            frmSettings.Location = this.Location;
            frmSettings.ShowDialog();
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/flweber/PhotoSorter/issues/new");
        }

        private void beendenAltF4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings.StartPosition = FormStartPosition.Manual;
            frmSettings.Location = this.Location;
            this.Enabled = false;
            frmSettings.Show();
        }

        private void beendenAltF4ToolStripMenuItem_Click(object sender, EventArgs e) => CheckForUpdate();

        private void CheckForUpdate()
        {
            try
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
                {
                    Program.UpdateViewer = new UpdateWindow(Web);
                    Program.UpdateViewer.StartPosition = FormStartPosition.Manual;
                    Program.UpdateViewer.Location = this.Location;
                    Program.UpdateViewer.ShowDialog();
                    Program.UpdateViewer.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(updateError + Environment.NewLine + ex.Message, "Updater Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainTool_Load(object sender, EventArgs e)
        {
            CheckForUpdate();
            SetLanguage();
        }

        internal void SetLanguage()
        {
            if ((Program.ci.TwoLetterISOLanguageName.Equals("de") || frmSettings.rb_German.Checked) && !frmSettings.rb_English.Checked)
            {
                label1.Text = "Vom";
                label2.Text = "bis";
                label3.Text = "Urlaubsbilder Sortierer";
                label4.Text = "Quellordner:";
                label5.Text = "Zielornder:";
                label6.Text = "Urlaubsziel:";
                btn_QuellWahl.Text = "Auswählen";
                btn_Zielwahl.Text = "Auswählen";
                dateiToolStripMenuItem.Text = "Datei";
                einstellungenToolStripMenuItem.Text = "Einstellungen";
                beendenAltF4ToolStripMenuItem.Text = "Updates suchen";
                beendenAltF4ToolStripMenuItem1.Text = "Beenden \t Alt+F4";
                hilfeToolStripMenuItem.Text = "Hilfe";
                fehlerMeldenToolStripMenuItem.Text = "Fehler melden";
                updateError = "Leider konnte nicht auf Updates geprüft werden." +
                    Environment.NewLine + "Bitte gehen Sie über \"Hilfe --> Fehler melden\" um uns zu informieren.";
                processError = "Leider konnte der Prozess nicht ausgeführt werden.";
                runningProcessWarning = "Der Prozess wird noch ausgeführt." + Environment.NewLine + "Wollen Sie den Prozess wirklich abbrechen?";
            }
            else
            {
                label1.Text = "From";
                label2.Text = "to";
                label3.Text = "Photo Sorter";
                label4.Text = "Source:";
                label5.Text = "Destination:";
                label6.Text = "Foldername:";
                btn_QuellWahl.Text = "Select";
                btn_Zielwahl.Text = "Select";
                dateiToolStripMenuItem.Text = "File";
                einstellungenToolStripMenuItem.Text = "Settings";
                beendenAltF4ToolStripMenuItem.Text = "Search for Updates";
                beendenAltF4ToolStripMenuItem1.Text = "Quit \t Alt+F4";
                hilfeToolStripMenuItem.Text = "Help";
                fehlerMeldenToolStripMenuItem.Text = "Report Issue";
                updateError = "Unfortunately we could not check for updates." +
                    Environment.NewLine + "Please click \"Help --> Report Issue\" to inform us.";
                processError = "Unfortunately the process could'nt run";
                runningProcessWarning = "The programme is working." + Environment.NewLine + "Do you really want to cancel the running process?";
            }
        }
    }
}
