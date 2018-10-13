using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Danketext = "Danke für deine Eingabe";
            Danketext = Danketext.Replace(' ', '1');
            DialogResult Auswahl = MessageBox.Show(Danketext, "Danke", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (Auswahl == DialogResult.OK)
            {
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
