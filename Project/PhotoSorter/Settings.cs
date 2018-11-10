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
        private Form Sender;

        public Settings(Form sender)
        {
            InitializeComponent();
            btn_SortmodeHelp.TabStop = false;
            btn_SortmodeHelp.FlatStyle = FlatStyle.Flat;
            btn_SortmodeHelp.FlatAppearance.BorderSize = 0;
            btn_SortdateHelp.TabStop = false;
            btn_SortdateHelp.FlatStyle = FlatStyle.Flat;
            btn_SortdateHelp.FlatAppearance.BorderSize = 0;
            Sender = sender;
        }

        private void btn_SortmodeHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kopieren: Die Dateien werden im Zielverzeichnis sortiert, allerdings bleiben die Dateien auch im Quellverzeichnis erhalten." + Environment.NewLine + "Ausschneiden:" +
                " Die Dateien werden im Zielverzeichnis sortiert und im Quellverzeichnis gelöscht.", "Sortiermodus Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_SortdateHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("", "Sortierdatum Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
