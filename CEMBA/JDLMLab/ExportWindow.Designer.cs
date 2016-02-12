namespace JDLMLab
{
    partial class ExportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.dataMeranie = new System.Windows.Forms.DataGridView();
            this.checkedListBoxInclude = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxCyklyInclude = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCyklyAllInclude = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeAll = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.SumRadioButton = new System.Windows.Forms.RadioButton();
            this.AvgRadioButton = new System.Windows.Forms.RadioButton();
            this.eachCycleRadioButton = new System.Windows.Forms.RadioButton();
            this.includeHeader = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataMeranie)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataMeranie
            // 
            this.dataMeranie.AllowDrop = true;
            this.dataMeranie.AllowUserToAddRows = false;
            this.dataMeranie.AllowUserToDeleteRows = false;
            this.dataMeranie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMeranie.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataMeranie.Location = new System.Drawing.Point(0, 0);
            this.dataMeranie.Name = "dataMeranie";
            this.dataMeranie.Size = new System.Drawing.Size(787, 293);
            this.dataMeranie.TabIndex = 1;
            this.dataMeranie.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataMeranie_CellValueChanged);
            // 
            // checkedListBoxInclude
            // 
            this.checkedListBoxInclude.CheckOnClick = true;
            this.checkedListBoxInclude.FormattingEnabled = true;
            this.checkedListBoxInclude.Location = new System.Drawing.Point(12, 27);
            this.checkedListBoxInclude.Name = "checkedListBoxInclude";
            this.checkedListBoxInclude.Size = new System.Drawing.Size(105, 124);
            this.checkedListBoxInclude.TabIndex = 2;
            this.checkedListBoxInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxInclude_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Include";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkedListBoxCyklyInclude
            // 
            this.checkedListBoxCyklyInclude.CheckOnClick = true;
            this.checkedListBoxCyklyInclude.FormattingEnabled = true;
            this.checkedListBoxCyklyInclude.Location = new System.Drawing.Point(137, 28);
            this.checkedListBoxCyklyInclude.Name = "checkedListBoxCyklyInclude";
            this.checkedListBoxCyklyInclude.Size = new System.Drawing.Size(120, 124);
            this.checkedListBoxCyklyInclude.TabIndex = 4;
            this.checkedListBoxCyklyInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCyklyInclude_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cycles";
            // 
            // checkBoxCyklyAllInclude
            // 
            this.checkBoxCyklyAllInclude.AutoSize = true;
            this.checkBoxCyklyAllInclude.Location = new System.Drawing.Point(137, 161);
            this.checkBoxCyklyAllInclude.Name = "checkBoxCyklyAllInclude";
            this.checkBoxCyklyAllInclude.Size = new System.Drawing.Size(68, 17);
            this.checkBoxCyklyAllInclude.TabIndex = 6;
            this.checkBoxCyklyAllInclude.Text = "All/None";
            this.checkBoxCyklyAllInclude.UseVisualStyleBackColor = true;
            this.checkBoxCyklyAllInclude.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBoxCyklyAllInclude.CheckStateChanged += new System.EventHandler(this.checkBoxCyklyInclude_CheckStateChanged);
            // 
            // checkBoxIncludeAll
            // 
            this.checkBoxIncludeAll.AutoSize = true;
            this.checkBoxIncludeAll.Location = new System.Drawing.Point(12, 161);
            this.checkBoxIncludeAll.Name = "checkBoxIncludeAll";
            this.checkBoxIncludeAll.Size = new System.Drawing.Size(68, 17);
            this.checkBoxIncludeAll.TabIndex = 7;
            this.checkBoxIncludeAll.Text = "All/None";
            this.checkBoxIncludeAll.UseVisualStyleBackColor = true;
            this.checkBoxIncludeAll.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.DefaultExt = "dat";
            this.saveFileDialog1.Filter = "DAT file|*.dat|All files|*.*";
            this.saveFileDialog1.Title = "Exportovať meranie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data mode";
            // 
            // SumRadioButton
            // 
            this.SumRadioButton.AutoSize = true;
            this.SumRadioButton.Location = new System.Drawing.Point(281, 75);
            this.SumRadioButton.Name = "SumRadioButton";
            this.SumRadioButton.Size = new System.Drawing.Size(104, 17);
            this.SumRadioButton.TabIndex = 10;
            this.SumRadioButton.Text = "Sum of all cycles";
            this.SumRadioButton.UseVisualStyleBackColor = true;
            this.SumRadioButton.CheckedChanged += new System.EventHandler(this.sumModeCheckboxChanged);
            // 
            // AvgRadioButton
            // 
            this.AvgRadioButton.AutoSize = true;
            this.AvgRadioButton.Location = new System.Drawing.Point(281, 52);
            this.AvgRadioButton.Name = "AvgRadioButton";
            this.AvgRadioButton.Size = new System.Drawing.Size(102, 17);
            this.AvgRadioButton.TabIndex = 11;
            this.AvgRadioButton.Text = "Avg of all cycles";
            this.AvgRadioButton.UseVisualStyleBackColor = true;
            this.AvgRadioButton.CheckedChanged += new System.EventHandler(this.avgModeCheckboxChanged);
            // 
            // eachCycleRadioButton
            // 
            this.eachCycleRadioButton.AutoSize = true;
            this.eachCycleRadioButton.Checked = true;
            this.eachCycleRadioButton.Location = new System.Drawing.Point(281, 27);
            this.eachCycleRadioButton.Name = "eachCycleRadioButton";
            this.eachCycleRadioButton.Size = new System.Drawing.Size(78, 17);
            this.eachCycleRadioButton.TabIndex = 12;
            this.eachCycleRadioButton.TabStop = true;
            this.eachCycleRadioButton.Text = "Each cycle";
            this.eachCycleRadioButton.UseVisualStyleBackColor = true;
            this.eachCycleRadioButton.CheckedChanged += new System.EventHandler(this.normalModeCheckboxChanged);
            // 
            // includeHeader
            // 
            this.includeHeader.AutoSize = true;
            this.includeHeader.Checked = true;
            this.includeHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeHeader.Location = new System.Drawing.Point(281, 161);
            this.includeHeader.Name = "includeHeader";
            this.includeHeader.Size = new System.Drawing.Size(97, 17);
            this.includeHeader.TabIndex = 13;
            this.includeHeader.Text = "Include header";
            this.includeHeader.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBoxCyklyInclude);
            this.panel1.Controls.Add(this.includeHeader);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.eachCycleRadioButton);
            this.panel1.Controls.Add(this.checkedListBoxInclude);
            this.panel1.Controls.Add(this.AvgRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SumRadioButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBoxCyklyAllInclude);
            this.panel1.Controls.Add(this.checkBoxIncludeAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 192);
            this.panel1.TabIndex = 14;
            // 
            // ExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 494);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataMeranie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ExportWindow";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExportWindow_KeyDown);
            this.Resize += new System.EventHandler(this.ExportWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataMeranie)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataMeranie;
        private System.Windows.Forms.CheckedListBox checkedListBoxInclude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxCyklyInclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCyklyAllInclude;
        private System.Windows.Forms.CheckBox checkBoxIncludeAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton SumRadioButton;
        private System.Windows.Forms.RadioButton AvgRadioButton;
        private System.Windows.Forms.RadioButton eachCycleRadioButton;
        private System.Windows.Forms.CheckBox includeHeader;
        private System.Windows.Forms.Panel panel1;
    }
}