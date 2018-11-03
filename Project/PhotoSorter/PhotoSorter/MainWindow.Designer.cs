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
            this.dtp_Vom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Bis = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_Quelle = new System.Windows.Forms.TextBox();
            this.txt_Ziel = new System.Windows.Forms.TextBox();
            this.btn_QuellWahl = new System.Windows.Forms.Button();
            this.btn_Zielwahl = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Urlaubsziel = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp_Vom
            // 
            this.dtp_Vom.Location = new System.Drawing.Point(51, 40);
            this.dtp_Vom.Name = "dtp_Vom";
            this.dtp_Vom.Size = new System.Drawing.Size(200, 20);
            this.dtp_Vom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "bis";
            // 
            // dtp_Bis
            // 
            this.dtp_Bis.Location = new System.Drawing.Point(283, 40);
            this.dtp_Bis.Name = "dtp_Bis";
            this.dtp_Bis.Size = new System.Drawing.Size(200, 20);
            this.dtp_Bis.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Urlaubsbilder Sortierer";
            // 
            // txt_Quelle
            // 
            this.txt_Quelle.Location = new System.Drawing.Point(77, 83);
            this.txt_Quelle.Name = "txt_Quelle";
            this.txt_Quelle.ReadOnly = true;
            this.txt_Quelle.Size = new System.Drawing.Size(174, 20);
            this.txt_Quelle.TabIndex = 5;
            // 
            // txt_Ziel
            // 
            this.txt_Ziel.Location = new System.Drawing.Point(77, 129);
            this.txt_Ziel.Name = "txt_Ziel";
            this.txt_Ziel.ReadOnly = true;
            this.txt_Ziel.Size = new System.Drawing.Size(174, 20);
            this.txt_Ziel.TabIndex = 6;
            // 
            // btn_QuellWahl
            // 
            this.btn_QuellWahl.Location = new System.Drawing.Point(260, 86);
            this.btn_QuellWahl.Name = "btn_QuellWahl";
            this.btn_QuellWahl.Size = new System.Drawing.Size(75, 20);
            this.btn_QuellWahl.TabIndex = 7;
            this.btn_QuellWahl.Text = "Auswählen";
            this.btn_QuellWahl.UseVisualStyleBackColor = true;
            // 
            // btn_Zielwahl
            // 
            this.btn_Zielwahl.Location = new System.Drawing.Point(260, 129);
            this.btn_Zielwahl.Name = "btn_Zielwahl";
            this.btn_Zielwahl.Size = new System.Drawing.Size(75, 20);
            this.btn_Zielwahl.TabIndex = 8;
            this.btn_Zielwahl.Text = "Auswählen";
            this.btn_Zielwahl.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quellordner:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zielordner:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Urlaubsziel:";
            // 
            // txt_Urlaubsziel
            // 
            this.txt_Urlaubsziel.Location = new System.Drawing.Point(77, 168);
            this.txt_Urlaubsziel.Name = "txt_Urlaubsziel";
            this.txt_Urlaubsziel.Size = new System.Drawing.Size(174, 20);
            this.txt_Urlaubsziel.TabIndex = 12;
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Location = new System.Drawing.Point(408, 227);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 13;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // MainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 262);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainTool";
            this.Text = "Photo Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Vom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_Bis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox txt_Quelle;
        private System.Windows.Forms.TextBox txt_Ziel;
        private System.Windows.Forms.Button btn_QuellWahl;
        private System.Windows.Forms.Button btn_Zielwahl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Urlaubsziel;
        private System.Windows.Forms.Button btn_Start;
    }
}

