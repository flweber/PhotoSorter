namespace PhotoSorter
{
    partial class MainTool
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTool));
            this.dtp_Vom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Bis = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_Quelle = new System.Windows.Forms.TextBox();
            this.txt_Ziel = new System.Windows.Forms.TextBox();
            this.btn_Zielwahl = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Urlaubsziel = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_prozentanzeige = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenAltF4ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fehlerMeldenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_QuellWahl = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.vorschlagBereitstellenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_Vom
            // 
            this.dtp_Vom.Location = new System.Drawing.Point(51, 55);
            this.dtp_Vom.Name = "dtp_Vom";
            this.dtp_Vom.Size = new System.Drawing.Size(200, 20);
            this.dtp_Vom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "bis";
            // 
            // dtp_Bis
            // 
            this.dtp_Bis.Location = new System.Drawing.Point(283, 55);
            this.dtp_Bis.Name = "dtp_Bis";
            this.dtp_Bis.Size = new System.Drawing.Size(200, 20);
            this.dtp_Bis.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Urlaubsbilder Sortierer";
            // 
            // txt_Quelle
            // 
            this.txt_Quelle.Location = new System.Drawing.Point(77, 98);
            this.txt_Quelle.Name = "txt_Quelle";
            this.txt_Quelle.ReadOnly = true;
            this.txt_Quelle.Size = new System.Drawing.Size(174, 20);
            this.txt_Quelle.TabIndex = 5;
            // 
            // txt_Ziel
            // 
            this.txt_Ziel.Location = new System.Drawing.Point(77, 144);
            this.txt_Ziel.Name = "txt_Ziel";
            this.txt_Ziel.ReadOnly = true;
            this.txt_Ziel.Size = new System.Drawing.Size(174, 20);
            this.txt_Ziel.TabIndex = 6;
            // 
            // btn_Zielwahl
            // 
            this.btn_Zielwahl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Zielwahl.Location = new System.Drawing.Point(260, 139);
            this.btn_Zielwahl.Name = "btn_Zielwahl";
            this.btn_Zielwahl.Size = new System.Drawing.Size(102, 29);
            this.btn_Zielwahl.TabIndex = 8;
            this.btn_Zielwahl.Text = "Auswählen";
            this.btn_Zielwahl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Zielwahl.UseVisualStyleBackColor = true;
            this.btn_Zielwahl.Click += new System.EventHandler(this.btn_Zielwahl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quellordner:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zielordner:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Urlaubsziel:";
            // 
            // txt_Urlaubsziel
            // 
            this.txt_Urlaubsziel.Location = new System.Drawing.Point(77, 180);
            this.txt_Urlaubsziel.Name = "txt_Urlaubsziel";
            this.txt_Urlaubsziel.Size = new System.Drawing.Size(174, 20);
            this.txt_Urlaubsziel.TabIndex = 12;
            this.txt_Urlaubsziel.TextChanged += new System.EventHandler(this.txt_Urlaubsziel_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 213);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(471, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // lbl_prozentanzeige
            // 
            this.lbl_prozentanzeige.AutoSize = true;
            this.lbl_prozentanzeige.Location = new System.Drawing.Point(432, 194);
            this.lbl_prozentanzeige.Name = "lbl_prozentanzeige";
            this.lbl_prozentanzeige.Size = new System.Drawing.Size(35, 13);
            this.lbl_prozentanzeige.TabIndex = 15;
            this.lbl_prozentanzeige.Text = "label7";
            this.lbl_prozentanzeige.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(489, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.beendenAltF4ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenAltF4ToolStripMenuItem1});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Image = global::PhotoSorter.Properties.Resources.if_Settings_black_192450;
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // beendenAltF4ToolStripMenuItem
            // 
            this.beendenAltF4ToolStripMenuItem.Image = global::PhotoSorter.Properties.Resources.iconfinder_Update_984748;
            this.beendenAltF4ToolStripMenuItem.Name = "beendenAltF4ToolStripMenuItem";
            this.beendenAltF4ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.beendenAltF4ToolStripMenuItem.Text = "Updates suchen";
            this.beendenAltF4ToolStripMenuItem.Click += new System.EventHandler(this.beendenAltF4ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // beendenAltF4ToolStripMenuItem1
            // 
            this.beendenAltF4ToolStripMenuItem1.Image = global::PhotoSorter.Properties.Resources.iconfinder_Gnome_Application_Exit_64_55530;
            this.beendenAltF4ToolStripMenuItem1.Name = "beendenAltF4ToolStripMenuItem1";
            this.beendenAltF4ToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.beendenAltF4ToolStripMenuItem1.Text = "Beenden";
            this.beendenAltF4ToolStripMenuItem1.Click += new System.EventHandler(this.beendenAltF4ToolStripMenuItem1_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fehlerMeldenToolStripMenuItem,
            this.vorschlagBereitstellenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // fehlerMeldenToolStripMenuItem
            // 
            this.fehlerMeldenToolStripMenuItem.Image = global::PhotoSorter.Properties.Resources.iconfinder_ic_report_48px_3669260;
            this.fehlerMeldenToolStripMenuItem.Name = "fehlerMeldenToolStripMenuItem";
            this.fehlerMeldenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.fehlerMeldenToolStripMenuItem.Text = "Fehler melden";
            this.fehlerMeldenToolStripMenuItem.Click += new System.EventHandler(this.fehlerMeldenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(489, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(356, 17);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "Version: ";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_QuellWahl
            // 
            this.btn_QuellWahl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_QuellWahl.Location = new System.Drawing.Point(260, 93);
            this.btn_QuellWahl.Name = "btn_QuellWahl";
            this.btn_QuellWahl.Size = new System.Drawing.Size(102, 29);
            this.btn_QuellWahl.TabIndex = 7;
            this.btn_QuellWahl.Text = "Auswählen";
            this.btn_QuellWahl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_QuellWahl.UseVisualStyleBackColor = true;
            this.btn_QuellWahl.Click += new System.EventHandler(this.btn_QuellWahl_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackgroundImage = global::PhotoSorter.Properties.Resources.if_Settings_black_192450;
            this.btn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Settings.Location = new System.Drawing.Point(12, 242);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(33, 33);
            this.btn_Settings.TabIndex = 16;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Start.Location = new System.Drawing.Point(408, 252);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 13;
            this.btn_Start.Text = "Start";
            this.btn_Start.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // vorschlagBereitstellenToolStripMenuItem
            // 
            this.vorschlagBereitstellenToolStripMenuItem.Image = global::PhotoSorter.Properties.Resources.iconfinder_theme_options_tools_feature_3256561;
            this.vorschlagBereitstellenToolStripMenuItem.Name = "vorschlagBereitstellenToolStripMenuItem";
            this.vorschlagBereitstellenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.vorschlagBereitstellenToolStripMenuItem.Text = "Vorschlag bereitstellen";
            this.vorschlagBereitstellenToolStripMenuItem.Click += new System.EventHandler(this.vorschlagBereitstellenToolStripMenuItem_Click);
            // 
            // MainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 300);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.lbl_prozentanzeige);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_Urlaubsziel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Zielwahl);
            this.Controls.Add(this.btn_QuellWahl);
            this.Controls.Add(this.txt_Ziel);
            this.Controls.Add(this.txt_Quelle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_Bis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Vom);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainTool";
            this.ShowIcon = false;
            this.Text = "Photo Sorter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainTool_FormClosing);
            this.Load += new System.EventHandler(this.MainTool_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainTool_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txt_Quelle;
        private System.Windows.Forms.TextBox txt_Ziel;
        private System.Windows.Forms.Button btn_QuellWahl;
        private System.Windows.Forms.Button btn_Zielwahl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Urlaubsziel;
        private System.Windows.Forms.Button btn_Start;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_prozentanzeige;
        private System.Windows.Forms.Button btn_Settings;
        internal System.Windows.Forms.DateTimePicker dtp_Vom;
        internal System.Windows.Forms.DateTimePicker dtp_Bis;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenAltF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenAltF4ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fehlerMeldenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vorschlagBereitstellenToolStripMenuItem;
    }
}

