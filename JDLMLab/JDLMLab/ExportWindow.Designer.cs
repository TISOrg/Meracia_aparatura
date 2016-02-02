﻿namespace JDLMLab
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
            this.checkBoxCyklyInclude = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeAll = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataMeranie)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
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
            this.dataMeranie.AllowUserToOrderColumns = true;
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
            this.checkedListBoxInclude.Location = new System.Drawing.Point(12, 325);
            this.checkedListBoxInclude.Name = "checkedListBoxInclude";
            this.checkedListBoxInclude.Size = new System.Drawing.Size(105, 124);
            this.checkedListBoxInclude.TabIndex = 2;
            this.checkedListBoxInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxInclude_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zahrnúť";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkedListBoxCyklyInclude
            // 
            this.checkedListBoxCyklyInclude.CheckOnClick = true;
            this.checkedListBoxCyklyInclude.FormattingEnabled = true;
            this.checkedListBoxCyklyInclude.Location = new System.Drawing.Point(137, 326);
            this.checkedListBoxCyklyInclude.Name = "checkedListBoxCyklyInclude";
            this.checkedListBoxCyklyInclude.Size = new System.Drawing.Size(120, 124);
            this.checkedListBoxCyklyInclude.TabIndex = 4;
            this.checkedListBoxCyklyInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCyklyInclude_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cykly";
            // 
            // checkBoxCyklyInclude
            // 
            this.checkBoxCyklyInclude.AutoSize = true;
            this.checkBoxCyklyInclude.Location = new System.Drawing.Point(137, 459);
            this.checkBoxCyklyInclude.Name = "checkBoxCyklyInclude";
            this.checkBoxCyklyInclude.Size = new System.Drawing.Size(68, 17);
            this.checkBoxCyklyInclude.TabIndex = 6;
            this.checkBoxCyklyInclude.Text = "All/None";
            this.checkBoxCyklyInclude.UseVisualStyleBackColor = true;
            this.checkBoxCyklyInclude.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxIncludeAll
            // 
            this.checkBoxIncludeAll.AutoSize = true;
            this.checkBoxIncludeAll.Location = new System.Drawing.Point(12, 459);
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
            this.label3.Location = new System.Drawing.Point(278, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Typ zobrazenia";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(281, 373);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "Sum of all cycles";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(281, 350);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.Text = "Avg of all cycles";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(281, 325);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(78, 17);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Each cycle";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // ExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 494);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxIncludeAll);
            this.Controls.Add(this.checkBoxCyklyInclude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxCyklyInclude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxInclude);
            this.Controls.Add(this.dataMeranie);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ExportWindow";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExportWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataMeranie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataMeranie;
        private System.Windows.Forms.CheckedListBox checkedListBoxInclude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxCyklyInclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCyklyInclude;
        private System.Windows.Forms.CheckBox checkBoxIncludeAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}