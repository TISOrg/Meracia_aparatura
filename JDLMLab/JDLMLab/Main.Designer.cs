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
            this.noveMeranieMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sidebar = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentCycle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stopAfterCycle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataDisplayAvg = new System.Windows.Forms.RadioButton();
            this.dataDisplaySum = new System.Windows.Forms.RadioButton();
            this.dataDisplayCurrent = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.displayModeAuto = new System.Windows.Forms.RadioButton();
            this.displayModeLog = new System.Windows.Forms.RadioButton();
            this.displayModeLin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.sidebarExportButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.startbutton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.kontainerPreGraf = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graf)).BeginInit();
            this.sidebar.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.noveMeranieMainMenu,
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
            // noveMeranieMainMenu
            // 
            this.noveMeranieMainMenu.Name = "noveMeranieMainMenu";
            this.noveMeranieMainMenu.Size = new System.Drawing.Size(119, 20);
            this.noveMeranieMainMenu.Text = "New measurement";
            this.noveMeranieMainMenu.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
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
            // graf
            // 
            this.graf.BorderlineWidth = 0;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.graf.ChartAreas.Add(chartArea1);
            this.graf.Location = new System.Drawing.Point(28, 0);
            this.graf.Margin = new System.Windows.Forms.Padding(0);
            this.graf.Name = "graf";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.graf.Series.Add(series1);
            this.graf.Size = new System.Drawing.Size(70, 82);
            this.graf.TabIndex = 8;
            this.graf.Text = "chart1";
            this.graf.Visible = false;
            this.graf.Click += new System.EventHandler(this.graf_Click);
            this.graf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.graf_KeyDown);
            // 
            // sidebar
            // 
            this.sidebar.AutoScroll = true;
            this.sidebar.Controls.Add(this.button3);
            this.sidebar.Controls.Add(this.groupBox4);
            this.sidebar.Controls.Add(this.groupBox3);
            this.sidebar.Controls.Add(this.stopAfterCycle);
            this.sidebar.Controls.Add(this.groupBox2);
            this.sidebar.Controls.Add(this.groupBox1);
            this.sidebar.Controls.Add(this.button1);
            this.sidebar.Controls.Add(this.sidebarExportButton);
            this.sidebar.Controls.Add(this.button2);
            this.sidebar.Controls.Add(this.startbutton);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidebar.Location = new System.Drawing.Point(1040, 24);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(148, 681);
            this.sidebar.TabIndex = 9;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Show current";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dateLabel);
            this.groupBox4.Controls.Add(this.timeLabel);
            this.groupBox4.Location = new System.Drawing.Point(3, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(139, 93);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "hh:mm:ss";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Estimated end";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(46, 16);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 13);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "Date";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(46, 39);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(30, 13);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.resolutionLabel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.currentStep);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.currentCycle);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 121);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurement info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "3.4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Step time";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(76, 94);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(19, 13);
            this.resolutionLabel.TabIndex = 5;
            this.resolutionLabel.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resolution";
            // 
            // currentStep
            // 
            this.currentStep.Enabled = false;
            this.currentStep.Location = new System.Drawing.Point(77, 46);
            this.currentStep.Name = "currentStep";
            this.currentStep.Size = new System.Drawing.Size(54, 20);
            this.currentStep.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current step";
            // 
            // currentCycle
            // 
            this.currentCycle.Enabled = false;
            this.currentCycle.Location = new System.Drawing.Point(77, 23);
            this.currentCycle.Name = "currentCycle";
            this.currentCycle.Size = new System.Drawing.Size(54, 20);
            this.currentCycle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current cycle";
            // 
            // stopAfterCycle
            // 
            this.stopAfterCycle.AutoSize = true;
            this.stopAfterCycle.Location = new System.Drawing.Point(9, 645);
            this.stopAfterCycle.Name = "stopAfterCycle";
            this.stopAfterCycle.Size = new System.Drawing.Size(133, 17);
            this.stopAfterCycle.TabIndex = 26;
            this.stopAfterCycle.Text = "Stop after end of cycle";
            this.stopAfterCycle.UseVisualStyleBackColor = true;
            this.stopAfterCycle.CheckedChanged += new System.EventHandler(this.stopAfterCycle_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataDisplayAvg);
            this.groupBox2.Controls.Add(this.dataDisplaySum);
            this.groupBox2.Controls.Add(this.dataDisplayCurrent);
            this.groupBox2.Location = new System.Drawing.Point(3, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 100);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data display mode";
            // 
            // dataDisplayAvg
            // 
            this.dataDisplayAvg.AutoSize = true;
            this.dataDisplayAvg.Location = new System.Drawing.Point(16, 19);
            this.dataDisplayAvg.Name = "dataDisplayAvg";
            this.dataDisplayAvg.Size = new System.Drawing.Size(60, 17);
            this.dataDisplayAvg.TabIndex = 20;
            this.dataDisplayAvg.TabStop = true;
            this.dataDisplayAvg.Text = "Priemer";
            this.dataDisplayAvg.UseVisualStyleBackColor = true;
            // 
            // dataDisplaySum
            // 
            this.dataDisplaySum.AutoSize = true;
            this.dataDisplaySum.Location = new System.Drawing.Point(16, 42);
            this.dataDisplaySum.Name = "dataDisplaySum";
            this.dataDisplaySum.Size = new System.Drawing.Size(52, 17);
            this.dataDisplaySum.TabIndex = 21;
            this.dataDisplaySum.TabStop = true;
            this.dataDisplaySum.Text = "Suma";
            this.dataDisplaySum.UseVisualStyleBackColor = true;
            // 
            // dataDisplayCurrent
            // 
            this.dataDisplayCurrent.AutoSize = true;
            this.dataDisplayCurrent.Location = new System.Drawing.Point(16, 65);
            this.dataDisplayCurrent.Name = "dataDisplayCurrent";
            this.dataDisplayCurrent.Size = new System.Drawing.Size(99, 17);
            this.dataDisplayCurrent.TabIndex = 22;
            this.dataDisplayCurrent.TabStop = true;
            this.dataDisplayCurrent.Text = "Aktuálny cyklus";
            this.dataDisplayCurrent.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.graf);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.displayModeAuto);
            this.groupBox1.Controls.Add(this.displayModeLog);
            this.groupBox1.Controls.Add(this.displayModeLin);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 98);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphical display mode";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(100, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(15, 20);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // displayModeAuto
            // 
            this.displayModeAuto.AutoSize = true;
            this.displayModeAuto.Location = new System.Drawing.Point(19, 65);
            this.displayModeAuto.Name = "displayModeAuto";
            this.displayModeAuto.Size = new System.Drawing.Size(46, 17);
            this.displayModeAuto.TabIndex = 12;
            this.displayModeAuto.TabStop = true;
            this.displayModeAuto.Text = "auto";
            this.displayModeAuto.UseVisualStyleBackColor = true;
            // 
            // displayModeLog
            // 
            this.displayModeLog.AutoSize = true;
            this.displayModeLog.Location = new System.Drawing.Point(19, 42);
            this.displayModeLog.Name = "displayModeLog";
            this.displayModeLog.Size = new System.Drawing.Size(39, 17);
            this.displayModeLog.TabIndex = 11;
            this.displayModeLog.TabStop = true;
            this.displayModeLog.Text = "log";
            this.displayModeLog.UseVisualStyleBackColor = true;
            // 
            // displayModeLin
            // 
            this.displayModeLin.AutoSize = true;
            this.displayModeLin.Location = new System.Drawing.Point(19, 19);
            this.displayModeLin.Name = "displayModeLin";
            this.displayModeLin.Size = new System.Drawing.Size(35, 17);
            this.displayModeLin.TabIndex = 10;
            this.displayModeLin.TabStop = true;
            this.displayModeLin.Text = "lin";
            this.displayModeLin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "AD DIG W";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sidebarExportButton
            // 
            this.sidebarExportButton.Location = new System.Drawing.Point(3, 554);
            this.sidebarExportButton.Name = "sidebarExportButton";
            this.sidebarExportButton.Size = new System.Drawing.Size(139, 23);
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
            this.button2.Location = new System.Drawing.Point(3, 616);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "STOP";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // startbutton
            // 
            this.startbutton.BackColor = System.Drawing.Color.Green;
            this.startbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startbutton.Location = new System.Drawing.Point(3, 583);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(139, 27);
            this.startbutton.TabIndex = 17;
            this.startbutton.Text = "START";
            this.startbutton.UseVisualStyleBackColor = false;
            this.startbutton.Click += new System.EventHandler(this.startbutton_click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // kontainerPreGraf
            // 
            this.kontainerPreGraf.BackColor = System.Drawing.Color.Black;
            this.kontainerPreGraf.Dock = System.Windows.Forms.DockStyle.Left;
            this.kontainerPreGraf.Location = new System.Drawing.Point(0, 24);
            this.kontainerPreGraf.Name = "kontainerPreGraf";
            this.kontainerPreGraf.Size = new System.Drawing.Size(1037, 681);
            this.kontainerPreGraf.TabIndex = 10;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 705);
            this.Controls.Add(this.kontainerPreGraf);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CEMBA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graf)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem noveMeranieMainMenu;
        private System.Windows.Forms.ToolStripMenuItem oProgrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart graf;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Button sidebarExportButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.RadioButton displayModeLog;
        private System.Windows.Forms.RadioButton displayModeLin;
        private System.Windows.Forms.RadioButton dataDisplayCurrent;
        private System.Windows.Forms.RadioButton dataDisplaySum;
        private System.Windows.Forms.RadioButton dataDisplayAvg;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton displayModeAuto;
        private System.Windows.Forms.CheckBox stopAfterCycle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox currentCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel kontainerPreGraf;
    }
}

