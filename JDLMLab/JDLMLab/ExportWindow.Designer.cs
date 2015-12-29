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
            this.button1 = new System.Windows.Forms.Button();
            this.dataMeranie = new System.Windows.Forms.DataGridView();
            this.checkedListBoxInclude = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxCyklyInclude = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCyklyInclude = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeAll = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataMeranie)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 413);
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
            this.checkedListBoxInclude.Items.AddRange(new object[] {
            "x",
            "y",
            "signál",
            "prúd",
            "tlak kapilara",
            "tlak komora",
            "teplota",
            "cyklus"});
            this.checkedListBoxInclude.Location = new System.Drawing.Point(12, 312);
            this.checkedListBoxInclude.Name = "checkedListBoxInclude";
            this.checkedListBoxInclude.Size = new System.Drawing.Size(97, 124);
            this.checkedListBoxInclude.TabIndex = 2;
            this.checkedListBoxInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxInclude_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 296);
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
            this.checkedListBoxCyklyInclude.Location = new System.Drawing.Point(137, 313);
            this.checkedListBoxCyklyInclude.Name = "checkedListBoxCyklyInclude";
            this.checkedListBoxCyklyInclude.Size = new System.Drawing.Size(120, 124);
            this.checkedListBoxCyklyInclude.TabIndex = 4;
            this.checkedListBoxCyklyInclude.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCyklyInclude_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cykly";
            // 
            // checkBoxCyklyInclude
            // 
            this.checkBoxCyklyInclude.AutoSize = true;
            this.checkBoxCyklyInclude.Location = new System.Drawing.Point(137, 446);
            this.checkBoxCyklyInclude.Name = "checkBoxCyklyInclude";
            this.checkBoxCyklyInclude.Size = new System.Drawing.Size(94, 17);
            this.checkBoxCyklyInclude.TabIndex = 6;
            this.checkBoxCyklyInclude.Text = "Všetky/žiadne";
            this.checkBoxCyklyInclude.UseVisualStyleBackColor = true;
            this.checkBoxCyklyInclude.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxIncludeAll
            // 
            this.checkBoxIncludeAll.AutoSize = true;
            this.checkBoxIncludeAll.Location = new System.Drawing.Point(12, 446);
            this.checkBoxIncludeAll.Name = "checkBoxIncludeAll";
            this.checkBoxIncludeAll.Size = new System.Drawing.Size(94, 17);
            this.checkBoxIncludeAll.TabIndex = 7;
            this.checkBoxIncludeAll.Text = "Všetky/žiadne";
            this.checkBoxIncludeAll.UseVisualStyleBackColor = true;
            this.checkBoxIncludeAll.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "Comma separated values files|*.csv|All files|*.*";
            this.saveFileDialog1.Title = "Exportovať meranie";
            // 
            // ExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 494);
            this.Controls.Add(this.checkBoxIncludeAll);
            this.Controls.Add(this.checkBoxCyklyInclude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxCyklyInclude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxInclude);
            this.Controls.Add(this.dataMeranie);
            this.Controls.Add(this.button1);
            this.Name = "ExportWindow";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
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
    }
}