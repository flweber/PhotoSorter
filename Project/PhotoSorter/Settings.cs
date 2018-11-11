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
            Sender.Enabled = true;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Sender.Enabled = true;
        }

        private void ShowPage()
        {
            grp_DateType.Visible = false;
            grp_Sortmode.Visible = false;
            grp_FileSelection.Visible = false;
            btn_Next.Enabled = false;
            btn_Prev.Enabled = false;
            switch (Page)
            {
                case 2:
                    grp_FileSelection.Location = grp_Sortmode.Location;
                    grp_FileSelection.Visible = true;
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
    }
}
