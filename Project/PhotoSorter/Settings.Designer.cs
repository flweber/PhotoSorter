namespace PhotoSorter
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.grp_Sortmode = new System.Windows.Forms.GroupBox();
            this.btn_SortmodeHelp = new System.Windows.Forms.Button();
            this.rb_Cut = new System.Windows.Forms.RadioButton();
            this.rb_Copy = new System.Windows.Forms.RadioButton();
            this.grp_FileSelection = new System.Windows.Forms.GroupBox();
            this.btn_FileSelectionHelp = new System.Windows.Forms.Button();
            this.rb_AllImages = new System.Windows.Forms.RadioButton();
            this.rb_DateRange = new System.Windows.Forms.RadioButton();
            this.grp_DateType = new System.Windows.Forms.GroupBox();
            this.btn_SortdateHelp = new System.Windows.Forms.Button();
            this.rb_ModifiedatDate = new System.Windows.Forms.RadioButton();
            this.rb_CreationDate = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.grp_Sortmode.SuspendLayout();
            this.grp_FileSelection.SuspendLayout();
            this.grp_DateType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Sortmode
            // 
            this.grp_Sortmode.Controls.Add(this.btn_SortmodeHelp);
            this.grp_Sortmode.Controls.Add(this.rb_Cut);
            this.grp_Sortmode.Controls.Add(this.rb_Copy);
            this.grp_Sortmode.Location = new System.Drawing.Point(13, 13);
            this.grp_Sortmode.Name = "grp_Sortmode";
            this.grp_Sortmode.Size = new System.Drawing.Size(200, 85);
            this.grp_Sortmode.TabIndex = 0;
            this.grp_Sortmode.TabStop = false;
            this.grp_Sortmode.Text = "Sortiermodus";
            // 
            // btn_SortmodeHelp
            // 
            this.btn_SortmodeHelp.BackColor = System.Drawing.Color.Transparent;
            this.btn_SortmodeHelp.BackgroundImage = global::PhotoSorter.Properties.Resources.qOXqp;
            this.btn_SortmodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SortmodeHelp.Location = new System.Drawing.Point(165, 30);
            this.btn_SortmodeHelp.Name = "btn_SortmodeHelp";
            this.btn_SortmodeHelp.Size = new System.Drawing.Size(29, 29);
            this.btn_SortmodeHelp.TabIndex = 2;
            this.btn_SortmodeHelp.UseVisualStyleBackColor = false;
            this.btn_SortmodeHelp.Click += new System.EventHandler(this.btn_SortmodeHelp_Click);
            // 
            // rb_Cut
            // 
            this.rb_Cut.AutoSize = true;
            this.rb_Cut.Location = new System.Drawing.Point(7, 53);
            this.rb_Cut.Name = "rb_Cut";
            this.rb_Cut.Size = new System.Drawing.Size(92, 17);
            this.rb_Cut.TabIndex = 1;
            this.rb_Cut.Text = "Ausschneiden";
            this.rb_Cut.UseVisualStyleBackColor = true;
            // 
            // rb_Copy
            // 
            this.rb_Copy.AutoSize = true;
            this.rb_Copy.Checked = true;
            this.rb_Copy.Location = new System.Drawing.Point(6, 19);
            this.rb_Copy.Name = "rb_Copy";
            this.rb_Copy.Size = new System.Drawing.Size(67, 17);
            this.rb_Copy.TabIndex = 0;
            this.rb_Copy.TabStop = true;
            this.rb_Copy.Text = "Kopieren";
            this.rb_Copy.UseVisualStyleBackColor = true;
            // 
            // grp_FileSelection
            // 
            this.grp_FileSelection.Controls.Add(this.btn_FileSelectionHelp);
            this.grp_FileSelection.Controls.Add(this.rb_AllImages);
            this.grp_FileSelection.Controls.Add(this.rb_DateRange);
            this.grp_FileSelection.Location = new System.Drawing.Point(123, 113);
            this.grp_FileSelection.Name = "grp_FileSelection";
            this.grp_FileSelection.Size = new System.Drawing.Size(200, 85);
            this.grp_FileSelection.TabIndex = 3;
            this.grp_FileSelection.TabStop = false;
            this.grp_FileSelection.Text = "Bildauswahl";
            this.grp_FileSelection.Visible = false;
            // 
            // btn_FileSelectionHelp
            // 
            this.btn_FileSelectionHelp.BackColor = System.Drawing.Color.Transparent;
            this.btn_FileSelectionHelp.BackgroundImage = global::PhotoSorter.Properties.Resources.qOXqp;
            this.btn_FileSelectionHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FileSelectionHelp.Location = new System.Drawing.Point(165, 30);
            this.btn_FileSelectionHelp.Name = "btn_FileSelectionHelp";
            this.btn_FileSelectionHelp.Size = new System.Drawing.Size(29, 29);
            this.btn_FileSelectionHelp.TabIndex = 2;
            this.btn_FileSelectionHelp.UseVisualStyleBackColor = false;
            this.btn_FileSelectionHelp.Click += new System.EventHandler(this.btn_FileSelectionHelp_Click);
            // 
            // rb_AllImages
            // 
            this.rb_AllImages.AutoSize = true;
            this.rb_AllImages.Location = new System.Drawing.Point(7, 53);
            this.rb_AllImages.Name = "rb_AllImages";
            this.rb_AllImages.Size = new System.Drawing.Size(71, 17);
            this.rb_AllImages.TabIndex = 1;
            this.rb_AllImages.Text = "Alle Bilder";
            this.rb_AllImages.UseVisualStyleBackColor = true;
            // 
            // rb_DateRange
            // 
            this.rb_DateRange.AutoSize = true;
            this.rb_DateRange.Checked = true;
            this.rb_DateRange.Location = new System.Drawing.Point(6, 19);
            this.rb_DateRange.Name = "rb_DateRange";
            this.rb_DateRange.Size = new System.Drawing.Size(96, 17);
            this.rb_DateRange.TabIndex = 0;
            this.rb_DateRange.TabStop = true;
            this.rb_DateRange.Text = "Datumsbereich";
            this.rb_DateRange.UseVisualStyleBackColor = true;
            this.rb_DateRange.CheckedChanged += new System.EventHandler(this.rb_DateRange_CheckedChanged);
            // 
            // grp_DateType
            // 
            this.grp_DateType.Controls.Add(this.btn_SortdateHelp);
            this.grp_DateType.Controls.Add(this.rb_ModifiedatDate);
            this.grp_DateType.Controls.Add(this.rb_CreationDate);
            this.grp_DateType.Location = new System.Drawing.Point(219, 13);
            this.grp_DateType.Name = "grp_DateType";
            this.grp_DateType.Size = new System.Drawing.Size(200, 85);
            this.grp_DateType.TabIndex = 1;
            this.grp_DateType.TabStop = false;
            this.grp_DateType.Text = "Sortierdatum";
            // 
            // btn_SortdateHelp
            // 
            this.btn_SortdateHelp.BackColor = System.Drawing.Color.Transparent;
            this.btn_SortdateHelp.BackgroundImage = global::PhotoSorter.Properties.Resources.qOXqp;
            this.btn_SortdateHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SortdateHelp.Location = new System.Drawing.Point(165, 30);
            this.btn_SortdateHelp.Name = "btn_SortdateHelp";
            this.btn_SortdateHelp.Size = new System.Drawing.Size(29, 29);
            this.btn_SortdateHelp.TabIndex = 3;
            this.btn_SortdateHelp.UseVisualStyleBackColor = false;
            this.btn_SortdateHelp.Click += new System.EventHandler(this.btn_SortdateHelp_Click);
            // 
            // rb_ModifiedatDate
            // 
            this.rb_ModifiedatDate.AutoSize = true;
            this.rb_ModifiedatDate.Location = new System.Drawing.Point(6, 53);
            this.rb_ModifiedatDate.Name = "rb_ModifiedatDate";
            this.rb_ModifiedatDate.Size = new System.Drawing.Size(107, 17);
            this.rb_ModifiedatDate.TabIndex = 1;
            this.rb_ModifiedatDate.Text = "Bearbeitet Datum";
            this.rb_ModifiedatDate.UseVisualStyleBackColor = true;
            // 
            // rb_CreationDate
            // 
            this.rb_CreationDate.AutoSize = true;
            this.rb_CreationDate.Checked = true;
            this.rb_CreationDate.Location = new System.Drawing.Point(6, 19);
            this.rb_CreationDate.Name = "rb_CreationDate";
            this.rb_CreationDate.Size = new System.Drawing.Size(82, 17);
            this.rb_CreationDate.TabIndex = 0;
            this.rb_CreationDate.TabStop = true;
            this.rb_CreationDate.Text = "Erstelldatum";
            this.rb_CreationDate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Prev
            // 
            this.btn_Prev.BackgroundImage = global::PhotoSorter.Properties.Resources.if_back_left_arrow_botton_2203523;
            this.btn_Prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Prev.Enabled = false;
            this.btn_Prev.Location = new System.Drawing.Point(12, 98);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(23, 23);
            this.btn_Prev.TabIndex = 4;
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackgroundImage = global::PhotoSorter.Properties.Resources.if_next_right_arrow_botton_2203522;
            this.btn_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Next.Location = new System.Drawing.Point(396, 98);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(23, 23);
            this.btn_Next.TabIndex = 3;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 153);
            this.Controls.Add(this.grp_FileSelection);
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grp_DateType);
            this.Controls.Add(this.grp_Sortmode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.grp_Sortmode.ResumeLayout(false);
            this.grp_Sortmode.PerformLayout();
            this.grp_FileSelection.ResumeLayout(false);
            this.grp_FileSelection.PerformLayout();
            this.grp_DateType.ResumeLayout(false);
            this.grp_DateType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Sortmode;
        private System.Windows.Forms.Button btn_SortmodeHelp;
        private System.Windows.Forms.GroupBox grp_DateType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_SortdateHelp;
        internal System.Windows.Forms.RadioButton rb_Cut;
        internal System.Windows.Forms.RadioButton rb_Copy;
        internal System.Windows.Forms.RadioButton rb_CreationDate;
        internal System.Windows.Forms.RadioButton rb_ModifiedatDate;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.GroupBox grp_FileSelection;
        private System.Windows.Forms.Button btn_FileSelectionHelp;
        internal System.Windows.Forms.RadioButton rb_AllImages;
        internal System.Windows.Forms.RadioButton rb_DateRange;
    }
}