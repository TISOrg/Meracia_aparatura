﻿namespace JDLMLab
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaMeraniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.graf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sidebarExportButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graf)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.oProgrameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveniaMeraniaToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.menuToolStripMenuItem.Text = "File";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // nastaveniaMeraniaToolStripMenuItem
            // 
            this.nastaveniaMeraniaToolStripMenuItem.Name = "nastaveniaMeraniaToolStripMenuItem";
            this.nastaveniaMeraniaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nastaveniaMeraniaToolStripMenuItem.Text = "Nové meranie";
            this.nastaveniaMeraniaToolStripMenuItem.Click += new System.EventHandler(this.nastaveniaMeraniaToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.toolsToolStripMenuItem.Text = "Nastavenia";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.loadToolStripMenuItem.Text = "Načítať meranie";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // oProgrameToolStripMenuItem
            // 
            this.oProgrameToolStripMenuItem.Name = "oProgrameToolStripMenuItem";
            this.oProgrameToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.oProgrameToolStripMenuItem.Text = "O programe";
            this.oProgrameToolStripMenuItem.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meracia aparatúra";
            // 
            // graf
            // 
            this.graf.BorderlineWidth = 0;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.graf.ChartAreas.Add(chartArea1);
            this.graf.Location = new System.Drawing.Point(-37, 24);
            this.graf.Margin = new System.Windows.Forms.Padding(0);
            this.graf.Name = "graf";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.graf.Series.Add(series1);
            this.graf.Size = new System.Drawing.Size(1010, 515);
            this.graf.TabIndex = 8;
            this.graf.Text = "chart1";
            this.graf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graf_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sidebarExportButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(976, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 524);
            this.panel1.TabIndex = 9;
            // 
            // sidebarExportButton
            // 
            this.sidebarExportButton.Location = new System.Drawing.Point(41, 260);
            this.sidebarExportButton.Name = "sidebarExportButton";
            this.sidebarExportButton.Size = new System.Drawing.Size(145, 23);
            this.sidebarExportButton.TabIndex = 9;
            this.sidebarExportButton.Text = "Export merania";
            this.sidebarExportButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(41, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 65);
            this.button2.TabIndex = 8;
            this.button2.Text = "Zastav meranie";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(41, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 83);
            this.button4.TabIndex = 13;
            this.button4.Text = "Štart";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(90, 104);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "log";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Prepni zobrazenie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(90, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "lin";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.graf);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Meracia aparatúra";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graf)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniaMeraniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgrameToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart graf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button sidebarExportButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

