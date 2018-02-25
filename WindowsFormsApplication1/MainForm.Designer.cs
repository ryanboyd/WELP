namespace WELP
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.StartButton = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EncodingDropdown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadCSVPreview_BGWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HeaderRowDropdown = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EnclosedInQuotesDropdown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DelimiterTextBox = new System.Windows.Forms.TextBox();
            this.ReloadCSVButton = new System.Windows.Forms.Button();
            this.LoadCSVButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FilenameDisplayBox = new System.Windows.Forms.TextBox();
            this.FirstColumnComboBox = new System.Windows.Forms.ComboBox();
            this.LastColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TokenTextbox_Rich = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.TokenColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OmissionValueComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BgWorker
            // 
            this.BgWorker.WorkerSupportsCancellation = true;
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            this.BgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(347, 527);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(175, 34);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.BackColor = System.Drawing.Color.Goldenrod;
            this.FilenameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilenameLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilenameLabel.Location = new System.Drawing.Point(12, 587);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(756, 23);
            this.FilenameLabel.TabIndex = 6;
            this.FilenameLabel.Text = "Waiting to parse model data...";
            this.FilenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(470, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Model File Preview (Up to the First 1000 Rows)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EncodingDropdown
            // 
            this.EncodingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropdown.FormattingEnabled = true;
            this.EncodingDropdown.Location = new System.Drawing.Point(124, 149);
            this.EncodingDropdown.Name = "EncodingDropdown";
            this.EncodingDropdown.Size = new System.Drawing.Size(171, 24);
            this.EncodingDropdown.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "File Encoding:";
            // 
            // LoadCSVPreview_BGWorker
            // 
            this.LoadCSVPreview_BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadCSVPreview_BGWorker_DoWork);
            this.LoadCSVPreview_BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadCSVPreview_BGWorker_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HeaderRowDropdown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.EnclosedInQuotesDropdown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EncodingDropdown);
            this.groupBox1.Controls.Add(this.DelimiterTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 193);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options for Reading Data File";
            // 
            // HeaderRowDropdown
            // 
            this.HeaderRowDropdown.AutoCompleteCustomSource.AddRange(new string[] {
            "True",
            "False"});
            this.HeaderRowDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeaderRowDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderRowDropdown.FormattingEnabled = true;
            this.HeaderRowDropdown.Items.AddRange(new object[] {
            "True",
            "False"});
            this.HeaderRowDropdown.Location = new System.Drawing.Point(208, 108);
            this.HeaderRowDropdown.MaxDropDownItems = 2;
            this.HeaderRowDropdown.Name = "HeaderRowDropdown";
            this.HeaderRowDropdown.Size = new System.Drawing.Size(87, 24);
            this.HeaderRowDropdown.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Data has a header row?";
            // 
            // EnclosedInQuotesDropdown
            // 
            this.EnclosedInQuotesDropdown.AutoCompleteCustomSource.AddRange(new string[] {
            "True",
            "False"});
            this.EnclosedInQuotesDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnclosedInQuotesDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnclosedInQuotesDropdown.FormattingEnabled = true;
            this.EnclosedInQuotesDropdown.Items.AddRange(new object[] {
            "True",
            "False"});
            this.EnclosedInQuotesDropdown.Location = new System.Drawing.Point(208, 67);
            this.EnclosedInQuotesDropdown.MaxDropDownItems = 2;
            this.EnclosedInQuotesDropdown.Name = "EnclosedInQuotesDropdown";
            this.EnclosedInQuotesDropdown.Size = new System.Drawing.Size(87, 24);
            this.EnclosedInQuotesDropdown.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fields enclosed in quotes?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data column delimiter(s):";
            // 
            // DelimiterTextBox
            // 
            this.DelimiterTextBox.AcceptsTab = true;
            this.DelimiterTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelimiterTextBox.Location = new System.Drawing.Point(195, 28);
            this.DelimiterTextBox.Name = "DelimiterTextBox";
            this.DelimiterTextBox.Size = new System.Drawing.Size(100, 23);
            this.DelimiterTextBox.TabIndex = 14;
            this.DelimiterTextBox.TabStop = false;
            this.DelimiterTextBox.Text = "\t";
            this.DelimiterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReloadCSVButton
            // 
            this.ReloadCSVButton.Enabled = false;
            this.ReloadCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadCSVButton.Location = new System.Drawing.Point(347, 463);
            this.ReloadCSVButton.Name = "ReloadCSVButton";
            this.ReloadCSVButton.Size = new System.Drawing.Size(175, 34);
            this.ReloadCSVButton.TabIndex = 16;
            this.ReloadCSVButton.Text = "Reload Preview";
            this.ReloadCSVButton.UseVisualStyleBackColor = true;
            this.ReloadCSVButton.Click += new System.EventHandler(this.ReloadCSVButton_Click);
            // 
            // LoadCSVButton
            // 
            this.LoadCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadCSVButton.Location = new System.Drawing.Point(347, 399);
            this.LoadCSVButton.Name = "LoadCSVButton";
            this.LoadCSVButton.Size = new System.Drawing.Size(175, 34);
            this.LoadCSVButton.TabIndex = 12;
            this.LoadCSVButton.Text = "Select Model File";
            this.LoadCSVButton.UseVisualStyleBackColor = true;
            this.LoadCSVButton.Click += new System.EventHandler(this.GeneratePreviewButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text-based Spreadsheet Files (*.csv; *.tsv; *.txt) | *.csv; *.tsv; *.txt";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(509, 203);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnAdded);
            // 
            // FilenameDisplayBox
            // 
            this.FilenameDisplayBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FilenameDisplayBox.BackColor = System.Drawing.Color.LightGray;
            this.FilenameDisplayBox.Enabled = false;
            this.FilenameDisplayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilenameDisplayBox.ForeColor = System.Drawing.Color.Black;
            this.FilenameDisplayBox.Location = new System.Drawing.Point(12, 262);
            this.FilenameDisplayBox.MaxLength = 9999999;
            this.FilenameDisplayBox.Name = "FilenameDisplayBox";
            this.FilenameDisplayBox.ReadOnly = true;
            this.FilenameDisplayBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FilenameDisplayBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.FilenameDisplayBox.Size = new System.Drawing.Size(509, 26);
            this.FilenameDisplayBox.TabIndex = 14;
            this.FilenameDisplayBox.TabStop = false;
            this.FilenameDisplayBox.Text = "No file selected...";
            this.FilenameDisplayBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FirstColumnComboBox
            // 
            this.FirstColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirstColumnComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstColumnComboBox.FormattingEnabled = true;
            this.FirstColumnComboBox.Location = new System.Drawing.Point(545, 470);
            this.FirstColumnComboBox.Name = "FirstColumnComboBox";
            this.FirstColumnComboBox.Size = new System.Drawing.Size(223, 24);
            this.FirstColumnComboBox.TabIndex = 17;
            // 
            // LastColumnComboBox
            // 
            this.LastColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LastColumnComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastColumnComboBox.FormattingEnabled = true;
            this.LastColumnComboBox.Location = new System.Drawing.Point(545, 534);
            this.LastColumnComboBox.Name = "LastColumnComboBox";
            this.LastColumnComboBox.Size = new System.Drawing.Size(223, 24);
            this.LastColumnComboBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(541, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Vector Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 509);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Vector End";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TokenTextbox_Rich
            // 
            this.TokenTextbox_Rich.AcceptsTab = true;
            this.TokenTextbox_Rich.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TokenTextbox_Rich.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokenTextbox_Rich.ForeColor = System.Drawing.Color.Black;
            this.TokenTextbox_Rich.Location = new System.Drawing.Point(545, 42);
            this.TokenTextbox_Rich.Name = "TokenTextbox_Rich";
            this.TokenTextbox_Rich.Size = new System.Drawing.Size(223, 246);
            this.TokenTextbox_Rich.TabIndex = 21;
            this.TokenTextbox_Rich.Text = "";
            this.TokenTextbox_Rich.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(582, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 22);
            this.label8.TabIndex = 22;
            this.label8.Text = "Seed Word List";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "WISE.txt";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(541, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 22);
            this.label9.TabIndex = 24;
            this.label9.Text = "Token Column";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TokenColumnComboBox
            // 
            this.TokenColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TokenColumnComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokenColumnComboBox.FormattingEnabled = true;
            this.TokenColumnComboBox.Location = new System.Drawing.Point(545, 406);
            this.TokenColumnComboBox.Name = "TokenColumnComboBox";
            this.TokenColumnComboBox.Size = new System.Drawing.Size(223, 24);
            this.TokenColumnComboBox.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(148, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(380, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "Omit Tokens where |Cosine Similarity| <";
            // 
            // OmissionValueComboBox
            // 
            this.OmissionValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OmissionValueComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OmissionValueComboBox.FormattingEnabled = true;
            this.OmissionValueComboBox.Items.AddRange(new object[] {
            ".90",
            ".80",
            ".70",
            ".60",
            ".50",
            ".40",
            ".30",
            ".20",
            ".10",
            ".00"});
            this.OmissionValueComboBox.Location = new System.Drawing.Point(536, 7);
            this.OmissionValueComboBox.Name = "OmissionValueComboBox";
            this.OmissionValueComboBox.Size = new System.Drawing.Size(63, 32);
            this.OmissionValueComboBox.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.OmissionValueComboBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(12, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 49);
            this.panel1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(784, 621);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TokenColumnComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TokenTextbox_Rich);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastColumnComboBox);
            this.Controls.Add(this.FirstColumnComboBox);
            this.Controls.Add(this.FilenameDisplayBox);
            this.Controls.Add(this.ReloadCSVButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadCSVButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 660);
            this.MinimumSize = new System.Drawing.Size(800, 660);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WELP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EncodingDropdown;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker LoadCSVPreview_BGWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadCSVButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DelimiterTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox EnclosedInQuotesDropdown;
        private System.Windows.Forms.Button ReloadCSVButton;
        private System.Windows.Forms.ComboBox HeaderRowDropdown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FilenameDisplayBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox FirstColumnComboBox;
        private System.Windows.Forms.ComboBox LastColumnComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox TokenTextbox_Rich;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox TokenColumnComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox OmissionValueComboBox;
        private System.Windows.Forms.Panel panel1;
    }
}

