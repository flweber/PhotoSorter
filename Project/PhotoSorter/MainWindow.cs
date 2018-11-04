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

namespace PhotoSorter
{
    public partial class MainTool : Form
    {
        public MainTool()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Text += " - " + version;
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
            dtp_Vom.Enabled = !backgroundWorker1.IsBusy;
            dtp_Bis.Enabled = !backgroundWorker1.IsBusy;
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
                    if(file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".jpeg"))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if(fileInfo.CreationTime.Date >= dtp_Vom.Value.Date && fileInfo.CreationTime.Date <= dtp_Bis.Value.Date)
                        {
                            if (!Directory.Exists(Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy")))
                                Directory.CreateDirectory(Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy"));

                            n = 1;
                            string fullfilepath = Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy") + "\\" + fileInfo.Name;
                            while (File.Exists(fullfilepath))
                            {
                                string Filename = fileInfo.Name.Split('.')[0] + "-" + n + "." + fileInfo.Extension;
                                fullfilepath = Zielpfad + "\\" + fileInfo.CreationTime.ToString("dd-MM-yyyy") + "\\" + Filename;
                                n++;
                            }

                            File.Copy(file, fullfilepath);
                        }
                    }
                    double percent = ((double)counter / (double)files.Count) * (double)100;
                    backgroundWorker1.ReportProgress((int)percent);
                    counter++;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Leider konnte der Prozess nicht ausgeführt werden." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl_prozentanzeige.Text = e.ProgressPercentage + "%";
            Kontrolle();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => Kontrolle();

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
                DialogResult dialog = MessageBox.Show("Der Prozess wird noch ausgeführt." + Environment.NewLine + "Wollen Sie den Prozess wirklich abbrechen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}