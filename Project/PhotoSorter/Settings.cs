using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoSorter
{
    public partial class Settings : Form
    {
        private MainTool Sender;
        private int Page;
        private int maxPages;

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
            Sender = sender;
            Page = 1;
            maxPages = 2;
        }

        private void btn_SortmodeHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kopieren: Die Dateien werden im Zielverzeichnis sortiert, allerdings bleiben die Dateien auch im Quellverzeichnis erhalten." + Environment.NewLine + "Ausschneiden:" +
                " Die Dateien werden im Zielverzeichnis sortiert und im Quellverzeichnis gelöscht.", "Sortiermodus Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_SortdateHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bei dem Erstelldatum handelt es sich um das Datum des Erstellens. Sollten Sie Bilder von Ihrem Smartphone kpoiert haben" +
                "so empfiehlt es sich das Änderungsdatum zu wählen, da hier das Erstelldatum dann gleich dem Kopierdatum ist.", "Sortierdatum Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
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
                    grp_FileSelection.Location = grp_Sortmode.Location;
                    grp_FileSelection.Visible = true;
                    grp_SelectLanguage.Location = grp_DateType.Location;
                    grp_SelectLanguage.Visible = true;
                    btn_Prev.Enabled = true;
                    break;
                case 1:
                default:
                    grp_Sortmode.Visible = true;
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
            }
            Sender.SetLanguage();
        }
    }
}
