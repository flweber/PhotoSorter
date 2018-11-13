namespace PhotoSorter
{
    partial class UpdateWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Current = new System.Windows.Forms.TextBox();
            this.txt_New = new System.Windows.Forms.TextBox();
            this.txt_Information = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Later = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Es ist ein Update verfügbar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Installierte Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aktuelle Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Versionsinformationen:";
            // 
            // txt_Current
            // 
            this.txt_Current.Location = new System.Drawing.Point(119, 56);
            this.txt_Current.Name = "txt_Current";
            this.txt_Current.ReadOnly = true;
            this.txt_Current.Size = new System.Drawing.Size(100, 20);
            this.txt_Current.TabIndex = 4;
            // 
            // txt_New
            // 
            this.txt_New.Location = new System.Drawing.Point(119, 91);
            this.txt_New.Name = "txt_New";
            this.txt_New.ReadOnly = true;
            this.txt_New.Size = new System.Drawing.Size(100, 20);
            this.txt_New.TabIndex = 5;
            // 
            // txt_Information
            // 
            this.txt_Information.Location = new System.Drawing.Point(18, 156);
            this.txt_Information.Multiline = true;
            this.txt_Information.Name = "txt_Information";
            this.txt_Information.ReadOnly = true;
            this.txt_Information.Size = new System.Drawing.Size(362, 237);
            this.txt_Information.TabIndex = 6;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(305, 415);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Later
            // 
            this.btn_Later.Location = new System.Drawing.Point(214, 415);
            this.btn_Later.Name = "btn_Later";
            this.btn_Later.Size = new System.Drawing.Size(75, 23);
            this.btn_Later.TabIndex = 8;
            this.btn_Later.Text = "Später";
            this.btn_Later.UseVisualStyleBackColor = true;
            this.btn_Later.Click += new System.EventHandler(this.btn_Later_Click);
            // 
            // UpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 450);
            this.Controls.Add(this.btn_Later);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.txt_Information);
            this.Controls.Add(this.txt_New);
            this.Controls.Add(this.txt_Current);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update verfügbar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateWindow_FormClosing);
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Current;
        private System.Windows.Forms.TextBox txt_New;
        private System.Windows.Forms.TextBox txt_Information;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Later;
    }
}