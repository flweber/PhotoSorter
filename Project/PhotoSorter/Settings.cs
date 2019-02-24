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
    public partial class Settings : Form
    {
        private MainTool Sender;
        private int Page;
        private int maxPages;
        private string SortmodeHelp;
        private string SortdateHelp;
        private string FileSelectionHelp;

        public Settings(MainTool sender)
        {
            InitializeComponent();
            btn_SortmodeHelp.TabStop = false;
            btn_SortmodeHelp.FlatStyle = FlatStyle.Flat;
            btn_SortmodeHelp.FlatAppearance.BorderSize = 0;
            btn_SortdateHelp.TabStop = false;
            btn_SortdateHelp.FlatStyle = FlatStyle.Flat;
            btn_SortdateHelp.FlatAppearance.BorderSize = 0;
            btn_Next.TabStop = false;
            btn_Next.FlatStyle = FlatStyle.Flat;
            btn_Next.FlatAppearance.BorderSize = 0;
            btn_Prev.TabStop = false;
            btn_Prev.FlatStyle = FlatStyle.Flat;
            btn_Prev.FlatAppearance.BorderSize = 0;
            btn_FileSelectionHelp.TabStop = false;
            btn_FileSelectionHelp.FlatStyle = FlatStyle.Flat;
            btn_FileSelectionHelp.FlatAppearance.BorderSize = 0;
            Sender = sender;
            Page = 1;
            maxPages = 2;
            try
            {
                LoadSettings();
            }
            catch
            {
                try
                {
                    CreateSettingsFile(Path.Combine(Application.StartupPath, "settings.xml"), new XmlDocument());
                }
                catch
                {
                    // Wenn das auch nicht klappt, dann erstmal gar nichts
                }
            }
        }

        private void LoadSettings()
        {
            XmlDocument settings = new XmlDocument();
            string FilePath = Path.Combine(Application.StartupPath, "settings.xml");
            if (!File.Exists(FilePath))
            {
                CreateSettingsFile(FilePath, settings);
            }
            else
            {
                settings.Load(FilePath);
                SetSettingsAutomatic(settings.DocumentElement);
            }
        }

        private void SetSettingsAutomatic(XmlElement root)
        {
            if (root.GetAttribute("lang") == "de")
                rb_German.Checked = true;
            else
                rb_English.Checked = true;
            XmlNode child = root.SelectSingleNode("SortMode");
            if (child.Attributes["Selection"].Value == "Copy")
                rb_Copy.Checked = true;
            else
                rb_Cut.Checked = true;
            child = root.SelectSingleNode("SortDate");
            if (child.Attributes["Selection"].Value == "Creation")
                rb_CreationDate.Checked = true;
            else
                rb_ModifiedatDate.Checked = true;
            child = root.SelectSingleNode("ImageSelection");
            if (child.Attributes["Selection"].Value == "DateRange")
                rb_DateRange.Checked = true;
            else
                rb_AllImages.Checked = true;
        }

        private void CreateSettingsFile(string SavePath, XmlDocument settings)
        {
            XmlDeclaration xmlDeclaration = settings.CreateXmlDeclaration("1.0", "UTF-8", null);
            string lang = Program.ci.TwoLetterISOLanguageName.Equals("de") ? "de" : "en";
            XmlElement root = settings.CreateElement("PhotoSorterSettings");
            root.SetAttribute("lang", lang);
            XmlElement child = settings.CreateElement("SortMode");
            if (rb_Copy.Checked)
                child.SetAttribute("Selection", "Copy");
            else
                child.SetAttribute("Selection", "Cut");
            root.AppendChild(child);
            child = settings.CreateElement("SortDate");
            if (rb_CreationDate.Checked)
                child.SetAttribute("Selection", "Creation");
            else
                child.SetAttribute("Selection", "Modification");
            root.AppendChild(child);
            child = settings.CreateElement("ImageSelection");
            if (rb_DateRange.Checked)
                child.SetAttribute("Selection", "DateRange");
            else
                child.SetAttribute("Selection", "All");
            root.AppendChild(child);
            settings.AppendChild(root);
            settings.InsertBefore(xmlDeclaration, root);
            settings.Save(Path.Combine(Application.StartupPath, "settings.xml"));
        }

        private void btn_SortmodeHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SortmodeHelp, "Sortiermodus Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_SortdateHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SortdateHelp, "Sortierdatum Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            try
            {
                XmlDocument settings = new XmlDocument();
                settings.Load(Path.Combine(Application.StartupPath, "settings.xml"));
                XmlNode root = settings.DocumentElement;
                root.Attributes["lang"].Value = rb_German.Checked ? "de" : "en";
                XmlNode SortMode = root.SelectSingleNode("SortMode");
                SortMode.Attributes["Selection"].Value = rb_Copy.Checked ? "Copy" : "Cut";
                XmlNode SortDate = root.SelectSingleNode("SortDate");
                SortDate.Attributes["Selection"].Value = rb_CreationDate.Checked ? "Creation" : "Modification";
                XmlNode ImageSelection = root.SelectSingleNode("ImageSelection");
                ImageSelection.Attributes["Selection"].Value = rb_DateRange.Checked ? "DateRange" : "All";
                settings.Save(Path.Combine(Application.StartupPath, "settings.xml"));
            }
            catch
            {
                //Erstmal garnichts
            }
        }

        private void ShowPage()
        {
            grp_DateType.Visible = false;
            grp_Sortmode.Visible = false;
            grp_FileSelection.Visible = false;
            grp_SelectLanguage.Visible = false;
            btn_Next.Enabled = false;
            btn_Prev.Enabled = false;
            switch (Page)
            {
                case 2:
                    grp_FileSelection.Location = grp_DateType.Location;
                    grp_FileSelection.Visible = true;
                    grp_Sortmode.Visible = true;
                    btn_Prev.Enabled = true;
                    break;
                case 1:
                default:
                    grp_SelectLanguage.Location = grp_Sortmode.Location;
                    grp_SelectLanguage.Visible = true;
                    grp_DateType.Visible = true;
                    btn_Next.Enabled = true;
                    break;
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if ((Page + 1) <= maxPages)
                Page++;
            ShowPage();
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if ((Page - 1) > 0)
                Page--;
            ShowPage();
        }

        private void btn_FileSelectionHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FileSelectionHelp, "Dateiauswahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rb_DateRange_CheckedChanged(object sender, EventArgs e)
        {
            Sender.dtp_Bis.Enabled = rb_DateRange.Checked;
            Sender.dtp_Vom.Enabled = rb_DateRange.Checked;
        }

        private void rb_German_CheckedChanged(object sender, EventArgs e) => SetLanguage();

        private void rb_English_CheckedChanged(object sender, EventArgs e) => SetLanguage();

        private void Settings_Load(object sender, EventArgs e)
        {
            if ((rb_German.Checked || Program.ci.TwoLetterISOLanguageName.Equals("de")) && !rb_English.Checked)
            {
                rb_English.Checked = false;
                rb_German.Checked = true;
            }
            else
            {
                rb_German.Checked = false;
                rb_English.Checked = true;
            }
            ShowPage();
        }

        private void SetLanguage()
        {
            if ((rb_German.Checked || Program.ci.TwoLetterISOLanguageName.Equals("de")) && !rb_English.Checked)
            {
                grp_DateType.Text = "Sortierdatum";
                grp_FileSelection.Text = "Bildauswahl";
                grp_SelectLanguage.Text = "Sprache";
                grp_Sortmode.Text = "Sortiermodus";
                rb_AllImages.Text = "Alle Bilder";
                rb_Copy.Text = "Kopieren";
                rb_CreationDate.Text = "Erstelldatum";
                rb_Cut.Text = "Ausschneiden";
                rb_DateRange.Text = "Datumsbereich";
                rb_ModifiedatDate.Text = "Bearbeitungsdatum";
                Text = "Einstellungen";
                SortmodeHelp = "Kopieren: Die Dateien werden im Zielverzeichnis sortiert, allerdings bleiben die Dateien auch im Quellverzeichnis erhalten." + Environment.NewLine + "Ausschneiden:" +
                " Die Dateien werden im Zielverzeichnis sortiert und im Quellverzeichnis gelöscht.";
                SortdateHelp = "Bei dem Erstelldatum handelt es sich um das Datum des Erstellens. Sollten Sie Bilder von Ihrem Smartphone oder Ihrer Kamera kopiert haben" +
                " so empfiehlt es sich das Änderungsdatum zu wählen, da hier das Erstelldatum dann gleich dem Kopierdatum ist.";
                FileSelectionHelp = "Datumsbereich: Kopiert alle Bilder im gewählten Zeitraum." + Environment.NewLine + "Alle Bilder: Kopiert alle Bilder, welche sich im Quellverzeichnis befinden.";
            }
            else
            {
                grp_DateType.Text = "Sort Date";
                grp_FileSelection.Text = "Files to copy";
                grp_SelectLanguage.Text = "Language";
                grp_Sortmode.Text = "Sortmode";
                rb_AllImages.Text = "All Images";
                rb_Copy.Text = "Copy";
                rb_CreationDate.Text = "Creation Date";
                rb_Cut.Text = "Cut";
                rb_DateRange.Text = "Date Range";
                rb_ModifiedatDate.Text = "Modification Date";
                Text = "Settings";
                SortmodeHelp = "Copy: The files will be sorted in the destination directory and will be stay in the source directory." + Environment.NewLine +
                    "Cut: The files will be deleted from the source directory and can only be found in the destiantion directory.";
                SortdateHelp = "If you have copied pictures from your smartphone or camera you should use the modified date because the creation date will be the date of copy.";
                FileSelectionHelp = "Date Range: Will copy all images in the selected date range." + Environment.NewLine + "All Images: Will copy all images from the source diretory.";
            }
            try
            {
                Sender.SetLanguage();
            }
            catch
            {
                //Beim ersten Durchlauf immer
            }
        }
    }
}
