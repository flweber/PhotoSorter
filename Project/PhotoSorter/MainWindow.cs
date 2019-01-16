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
    public partial class MainTool : Form
    {

        // Deklaration der Instanzvariablen
        
        /// <summary>
        /// Beinhaltet das Einstellungsfenster
        /// </summary>
        private Settings frmSettings;

        /// <summary>
        /// Wird angezeigt, wenn ein Error beim updaten der Software auftritt.
        /// Enthält immer die eingestellte Sprachversion
        /// </summary>
        private string updateError;

        /// <summary>
        /// Meldung beim Schließen der Anwendung, wenn der Sortierprozess noch nicht
        /// abgeschlossen ist.
        /// Enthält immer die eingestellte Sprachversion
        /// </summary>
        private string runningProcessWarning;

        /// <summary>
        /// Meldung wenn es einen Fehler beim Sortierprozess gab.
        /// Enthält immer die eingestellte Sprachversion
        /// </summary>
        private string processError;

        /// <summary>
        /// Meldung um den Benutzer zu informieren, dass der Sortiervorgang
        /// abgeschlossen wurde
        /// Enthält immer die eingestellte Sprachversion
        /// </summary>
        private string processfinished;

        public MainTool()
        {
            InitializeComponent();

            // Anzeigen der Versionsnummer im Status Label
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode root, node;
                doc.Load("version.xml");
                root = doc.DocumentElement;
                node = root.SelectSingleNode("version");
                toolStripStatusLabel3.Text += node.InnerText;
            }
            catch
            {
                // Wenn es einen Fehler gibt wird die Version eben nicht angezeigt
            }

            // Designanpassungen des Settings-Buttons um den Hintergrund zu entfernen
            btn_Settings.TabStop = false;
            btn_Settings.FlatStyle = FlatStyle.Flat;
            btn_Settings.FlatAppearance.BorderSize = 0;

            // Initialisierung des Settings Fensters
            frmSettings = new Settings(this);
        }

        /// <summary>
        /// Aktiviert bzw. deaktiviert den Startbutton
        /// und Prozesskritische Eingabeelemente.
        /// Passt außerdem die Anzeige an die vom User
        /// vorgenommenen Einstellungen an.
        /// </summary>
        private void Kontrolle()
        {
            // Deaktiviert bzw. aktiviert den Start-Button wenn alle benötigten Felder ausgefüllt wurden
            if (String.IsNullOrWhiteSpace(txt_Quelle.Text) || String.IsNullOrWhiteSpace(txt_Ziel.Text) || String.IsNullOrWhiteSpace(txt_Urlaubsziel.Text) || backgroundWorker1.IsBusy)
            {
                btn_Start.Enabled = false;
            }
            else
            {
                btn_Start.Enabled = true;
            }

            // Aktiviert bzw. deaktiviert Einstellungen, die den Sortierprozess beeinflussen, je nachdem
            // ob der Vorgang am laufen ist oder nicht.
            btn_QuellWahl.Enabled = !backgroundWorker1.IsBusy;
            btn_Zielwahl.Enabled = !backgroundWorker1.IsBusy;
            txt_Urlaubsziel.Enabled = !backgroundWorker1.IsBusy;

            // Aktiviert bzw. deaktiviert die Eingabe des Datumsbereiches, je nachdem
            // wie es in den Einstellungen vom Benutzer festgelegt wurde 
            if (frmSettings.rb_DateRange.Checked)
            {
                dtp_Vom.Enabled = !backgroundWorker1.IsBusy;
                dtp_Bis.Enabled = !backgroundWorker1.IsBusy;
            }
        }

        /// <summary>
        /// Öffnet einen Folderbrwose Dialog und lässt
        /// den User die Bilderquelle wählen
        /// </summary>
        private void btn_QuellWahl_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && !String.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                txt_Quelle.Text = folderBrowserDialog1.SelectedPath;
            }
            Kontrolle();
        }

        /// <summary>
        /// Öffnet einen Folderbrwose Dialog und lässt
        /// den User den Zielpfad wählen
        /// </summary>
        private void btn_Zielwahl_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && !String.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                txt_Ziel.Text = folderBrowserDialog1.SelectedPath;
            }
            Kontrolle();
        }

        /// <summary>
        /// Überprüfung der Prozesskritischen Elemente, wenn sich der Zielordner Text ändert
        /// </summary>
        private void txt_Urlaubsziel_TextChanged(object sender, EventArgs e) => Kontrolle();

        /// <summary>
        /// Hier befindet sich der Sortierprozess
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PhotoSorter Sorter = new PhotoSorter(this.txt_Ziel.Text, this.txt_Quelle.Text, this.txt_Urlaubsziel.Text);

            Sorter.CheckIfDirExists();

            try
            {
                // Ordner erstellen und alle Elemente aus dem Quellordner einlesen
                Sorter.CreateNewDirectory(Sorter.SortFolder);

                Sorter.ReadSourceDir();

                // Counter für die Prozentanzeige
                int counter = 1;

                for(int i = 0; i < Sorter.NumberOfSourceFiles; i++)
                {
                    Sorter.SortPicture(i, frmSettings.rb_CreationDate.Checked, frmSettings.rb_ModifiedatDate.Checked, frmSettings.rb_AllImages.Checked, frmSettings.rb_Copy.Checked, dtp_Vom.Value, dtp_Bis.Value);
                    try
                    {
                        // Fortschritt berechnen und in der Progressbar anzeigen
                        double percent = ((double)counter / (double)Sorter.NumberOfSourceFiles) * (double)100;
                        backgroundWorker1.ReportProgress((int)percent);
                        counter++;
                    }
                    catch { }
                }
                //Sorter.SortPictures(ref counter, frmSettings.rb_CreationDate.Checked, frmSettings.rb_ModifiedatDate.Checked, frmSettings.rb_AllImages.Checked, frmSettings.rb_Copy.Checked, dtp_Vom.Value, dtp_Bis.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(processError + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Progress Reporting for the User
        /// </summary>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl_prozentanzeige.Text = e.ProgressPercentage + "%";
            Kontrolle();
        }

        /// <summary>
        /// User über den Abschluss des Sortierprozesses informieren
        /// </summary>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(processfinished, "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Kontrolle();
        }

        /// <summary>
        /// Startet den Sortiervorgang auf Befehl des Users
        /// </summary>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            lbl_prozentanzeige.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            Kontrolle();
        }

        /// <summary>
        /// ggf. das Schließen verhindern, der Prozess gerade am laufen ist
        /// </summary>
        private void MainTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                DialogResult dialog = MessageBox.Show(runningProcessWarning, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Öffnet die Einstellungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            frmSettings.StartPosition = FormStartPosition.Manual;
            frmSettings.Location = this.Location;
            frmSettings.ShowDialog();
        }

        /// <summary>
        /// Öffnet einen neuen Bug auf GitHub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/flweber/PhotoSorter/issues/new?labels=bug");
        }

        /// <summary>
        /// Beendet die Anwendung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beendenAltF4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Öffnet die Einstellungen
        /// </summary>
        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings.StartPosition = FormStartPosition.Manual;
            frmSettings.Location = this.Location;
            this.Enabled = false;
            frmSettings.Show();
        }

        /// <summary>
        /// Startet die Überprüfung auf Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beendenAltF4ToolStripMenuItem_Click(object sender, EventArgs e) => CheckForUpdate(true);

        /// <summary>
        /// Überprüft, ob es ein Update für die Anwendung gibt
        /// </summary>
        /// <param name="manualExecution">Gibt an ob die Prüfung durch den User gestartet wurde</param>
        private void CheckForUpdate(bool manualExecution = false)
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
                if (!localVersion.Equals(remoteVersion) || manualExecution)
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

        /// <summary>
        /// Setzt beim Start die Bilder für die Buttons
        /// und startet die Überprüfung auf Updates
        /// </summary>
        private void MainTool_Load(object sender, EventArgs e)
        {
            CheckForUpdate();
            SetLanguage();
            btn_QuellWahl.Image = (Image)(new Bitmap(Properties.Resources.iconfinder_opened_folder_172515, new Size(32, 32)));
            btn_Zielwahl.Image = (Image)(new Bitmap(Properties.Resources.iconfinder_opened_folder_172515, new Size(32, 32)));
            btn_Start.Image = (Image)(new Bitmap(Properties.Resources.iconfinder_Go_132114, new Size(16, 16)));
        }

        /// <summary>
        /// Setzt die Sprache für alle Elemente der Eingabemaske und der Meldungen
        /// beim Start auf die Systemsprache oder nach den Einstellungen
        /// </summary>
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
                einstellungenToolStripMenuItem.Text = "Einstellungen          Strg+E";
                beendenAltF4ToolStripMenuItem.Text = "Updates suchen      F5";
                beendenAltF4ToolStripMenuItem1.Text = "Beenden                  Alt+F4";
                hilfeToolStripMenuItem.Text = "Hilfe";
                fehlerMeldenToolStripMenuItem.Text = "Fehler melden       Alt+E";
                updateError = "Leider konnte nicht auf Updates geprüft werden." +
                    Environment.NewLine + "Bitte gehen Sie über \"Hilfe --> Fehler melden\" um uns zu informieren.";
                processError = "Leider konnte der Prozess nicht ausgeführt werden.";
                runningProcessWarning = "Der Prozess wird noch ausgeführt." + Environment.NewLine + "Wollen Sie den Prozess wirklich abbrechen?";
                processfinished = "Der Prozess wurde ausgeführt";
                toolStripStatusLabel1.Text = "Hallo ";
                toolStripStatusLabel1.Text += (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("\\")) ? System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1] : System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                vorschlagBereitstellenToolStripMenuItem.Text = "Vorschlag bereitstellen";
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
                einstellungenToolStripMenuItem.Text = "Settings                         Strg+E";
                beendenAltF4ToolStripMenuItem.Text = "Search for Updates      F5";
                beendenAltF4ToolStripMenuItem1.Text = "Quit                                Alt+F4";
                hilfeToolStripMenuItem.Text = "Help";
                fehlerMeldenToolStripMenuItem.Text = "Report Issue       Alt+E";
                updateError = "Unfortunately we could not check for updates." +
                    Environment.NewLine + "Please click \"Help --> Report Issue\" to inform us.";
                processError = "Unfortunately the process couldn't run";
                runningProcessWarning = "The programme is working." + Environment.NewLine + "Do you really want to cancel the running process?";
                processfinished = "The process has finished";
                toolStripStatusLabel1.Text = "Hello ";
                toolStripStatusLabel1.Text += (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("\\")) ? System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1] : System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                vorschlagBereitstellenToolStripMenuItem.Text = "Request enhancement";
            }
        }

        /// <summary>
        /// Shortcuts
        /// </summary>
        private void MainTool_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    CheckForUpdate(true);
                    break;
                default:
                    if (e.Modifiers == Keys.Control)
                    {
                        if (e.KeyCode == Keys.Q)
                            btn_QuellWahl_Click(btn_QuellWahl, new EventArgs());
                        else if (e.KeyCode == Keys.Z)
                            btn_Zielwahl_Click(btn_Zielwahl, new EventArgs());
                        else if (e.KeyCode == Keys.S && btn_Start.Enabled)
                            btn_Start_Click(btn_Start, new EventArgs());
                        else if (e.KeyCode == Keys.E)
                            btn_Settings_Click(btn_Settings, new EventArgs());
                    }
                    else if (e.Modifiers == Keys.Alt)
                    {
                        if (e.KeyCode == Keys.E)
                            fehlerMeldenToolStripMenuItem_Click(fehlerMeldenToolStripMenuItem, new EventArgs());
                    }
                    break;
            }
        }

        /// <summary>
        /// Öffnet GitHub mit einem Vorschlag
        /// </summary>
        private void vorschlagBereitstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/flweber/PhotoSorter/issues/new?labels=enhancement");
        }

        private void txt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void txt_DragDrop(object sender, DragEventArgs e)
        {
            TextBox txt_Sender = (TextBox)sender;
            txt_Sender.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }
    }
}