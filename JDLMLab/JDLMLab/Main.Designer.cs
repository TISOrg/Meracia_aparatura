namespace JDLMLab
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sidebarExportButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.startbutton = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.nastaveniaMeraniaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.nastaveniaMeraniaToolStripMenuItem.Text = "New measurement";
            this.nastaveniaMeraniaToolStripMenuItem.Click += new System.EventHandler(this.nastaveniaMeraniaToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.toolsToolStripMenuItem.Text = "Settings";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.loadToolStripMenuItem.Text = "Load measurement";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // oProgrameToolStripMenuItem
            // 
            this.oProgrameToolStripMenuItem.Name = "oProgrameToolStripMenuItem";
            this.oProgrameToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.oProgrameToolStripMenuItem.Text = "About";
            this.oProgrameToolStripMenuItem.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CEMBA";
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
            this.graf.Dock = System.Windows.Forms.DockStyle.Left;
            this.graf.Location = new System.Drawing.Point(0, 24);
            this.graf.Margin = new System.Windows.Forms.Padding(0);
            this.graf.Name = "graf";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.graf.Series.Add(series1);
            this.graf.Size = new System.Drawing.Size(961, 524);
            this.graf.TabIndex = 8;
            this.graf.Text = "chart1";
            this.graf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graf_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sidebarExportButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.startbutton);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(961, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 524);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(94, 229);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(99, 17);
            this.radioButton5.TabIndex = 22;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Aktuálny cyklus";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(94, 206);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 17);
            this.radioButton3.TabIndex = 21;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Suma";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(94, 183);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(60, 17);
            this.radioButton4.TabIndex = 20;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Priemer";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(58, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Režim zobrazenie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(58, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose display mode";
            // 
            // sidebarExportButton
            // 
            this.sidebarExportButton.Location = new System.Drawing.Point(40, 373);
            this.sidebarExportButton.Name = "sidebarExportButton";
            this.sidebarExportButton.Size = new System.Drawing.Size(145, 23);
            this.sidebarExportButton.TabIndex = 16;
            this.sidebarExportButton.Text = "Export ";
            this.sidebarExportButton.UseVisualStyleBackColor = true;
            this.sidebarExportButton.Click += new System.EventHandler(this.sidebarExportButton_Click_2);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(40, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 65);
            this.button2.TabIndex = 15;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // startbutton
            // 
            this.startbutton.BackColor = System.Drawing.Color.Green;
            this.startbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startbutton.Location = new System.Drawing.Point(40, 410);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(145, 83);
            this.startbutton.TabIndex = 17;
            this.startbutton.Text = "START";
            this.startbutton.UseVisualStyleBackColor = false;
            this.startbutton.Click += new System.EventHandler(this.startbutton_click);
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
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(136, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(523, 169);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 548);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.graf);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CEMBA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
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
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

