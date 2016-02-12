using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidebar = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.intensityValue = new System.Windows.Forms.Label();
            this.cursorPositionValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cursorPositionLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Capillarpressureradio = new System.Windows.Forms.RadioButton();
            this.Chamberpressureradio = new System.Windows.Forms.RadioButton();
            this.Temperatureradio = new System.Windows.Forms.RadioButton();
            this.Electroncurrentradio = new System.Windows.Forms.RadioButton();
            this.Measureddataradio = new System.Windows.Forms.RadioButton();
            this.showCurrentLoadButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TimeValueLabel = new System.Windows.Forms.Label();
            this.DateValueLabel = new System.Windows.Forms.Label();
            this.estTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonnext = new System.Windows.Forms.Button();
            this.buttonprevious = new System.Windows.Forms.Button();
            this.energyScanStepTimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentEnergyStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentCycle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stopAfterCycle = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataDisplayAvg = new System.Windows.Forms.RadioButton();
            this.dataDisplaySum = new System.Windows.Forms.RadioButton();
            this.dataDisplayCurrent = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayModeLog = new System.Windows.Forms.RadioButton();
            this.displayModeLin = new System.Windows.Forms.RadioButton();
            this.sidebarExportButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.kontainerPreGraf = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.menuToolStripMenuItem.Text = "New Measurement";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.toolsToolStripMenuItem.Text = "Settings";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.loadToolStripMenuItem.Text = "Load measurement";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // oProgrameToolStripMenuItem
            // 
            this.oProgrameToolStripMenuItem.Name = "oProgrameToolStripMenuItem";
            this.oProgrameToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.oProgrameToolStripMenuItem.Text = "About";
            this.oProgrameToolStripMenuItem.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // sidebar
            // 
            this.sidebar.AutoScroll = true;
            this.sidebar.Controls.Add(this.groupBox6);
            this.sidebar.Controls.Add(this.groupBox5);
            this.sidebar.Controls.Add(this.groupBox4);
            this.sidebar.Controls.Add(this.groupBox3);
            this.sidebar.Controls.Add(this.stopAfterCycle);
            this.sidebar.Controls.Add(this.groupBox2);
            this.sidebar.Controls.Add(this.groupBox1);
            this.sidebar.Controls.Add(this.sidebarExportButton);
            this.sidebar.Controls.Add(this.stopButton);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidebar.Enabled = false;
            this.sidebar.Location = new System.Drawing.Point(1030, 24);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(158, 746);
            this.sidebar.TabIndex = 9;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.sidebar.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.sidebar_PreviewKeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.intensityValue);
            this.groupBox6.Controls.Add(this.cursorPositionValue);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.cursorPositionLabel);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(3, 500);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(152, 66);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cursor info";
            // 
            // intensityValue
            // 
            this.intensityValue.AutoSize = true;
            this.intensityValue.Location = new System.Drawing.Point(100, 38);
            this.intensityValue.Name = "intensityValue";
            this.intensityValue.Size = new System.Drawing.Size(0, 13);
            this.intensityValue.TabIndex = 10;
            // 
            // cursorPositionValue
            // 
            this.cursorPositionValue.AutoSize = true;
            this.cursorPositionValue.Location = new System.Drawing.Point(100, 18);
            this.cursorPositionValue.Name = "cursorPositionValue";
            this.cursorPositionValue.Size = new System.Drawing.Size(0, 13);
            this.cursorPositionValue.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 8;
            // 
            // cursorPositionLabel
            // 
            this.cursorPositionLabel.AutoSize = true;
            this.cursorPositionLabel.Location = new System.Drawing.Point(3, 18);
            this.cursorPositionLabel.Name = "cursorPositionLabel";
            this.cursorPositionLabel.Size = new System.Drawing.Size(97, 13);
            this.cursorPositionLabel.TabIndex = 6;
            this.cursorPositionLabel.Text = "Current position [x]:";
            this.cursorPositionLabel.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Current intensity :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Capillarpressureradio);
            this.groupBox5.Controls.Add(this.Chamberpressureradio);
            this.groupBox5.Controls.Add(this.Temperatureradio);
            this.groupBox5.Controls.Add(this.Electroncurrentradio);
            this.groupBox5.Controls.Add(this.Measureddataradio);
            this.groupBox5.Controls.Add(this.showCurrentLoadButton);
            this.groupBox5.Location = new System.Drawing.Point(4, 166);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(151, 170);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Presented valuee";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // Capillarpressureradio
            // 
            this.Capillarpressureradio.AutoSize = true;
            this.Capillarpressureradio.Location = new System.Drawing.Point(16, 111);
            this.Capillarpressureradio.Name = "Capillarpressureradio";
            this.Capillarpressureradio.Size = new System.Drawing.Size(102, 17);
            this.Capillarpressureradio.TabIndex = 34;
            this.Capillarpressureradio.Text = "Capillar pressure";
            this.Capillarpressureradio.UseVisualStyleBackColor = true;
            // 
            // Chamberpressureradio
            // 
            this.Chamberpressureradio.AutoSize = true;
            this.Chamberpressureradio.Location = new System.Drawing.Point(16, 88);
            this.Chamberpressureradio.Name = "Chamberpressureradio";
            this.Chamberpressureradio.Size = new System.Drawing.Size(110, 17);
            this.Chamberpressureradio.TabIndex = 33;
            this.Chamberpressureradio.Text = "Chamber pressure";
            this.Chamberpressureradio.UseVisualStyleBackColor = true;
            // 
            // Temperatureradio
            // 
            this.Temperatureradio.AutoSize = true;
            this.Temperatureradio.Location = new System.Drawing.Point(16, 65);
            this.Temperatureradio.Name = "Temperatureradio";
            this.Temperatureradio.Size = new System.Drawing.Size(85, 17);
            this.Temperatureradio.TabIndex = 32;
            this.Temperatureradio.Text = "Temperature";
            this.Temperatureradio.UseVisualStyleBackColor = true;
            // 
            // Electroncurrentradio
            // 
            this.Electroncurrentradio.AutoSize = true;
            this.Electroncurrentradio.Location = new System.Drawing.Point(16, 42);
            this.Electroncurrentradio.Name = "Electroncurrentradio";
            this.Electroncurrentradio.Size = new System.Drawing.Size(100, 17);
            this.Electroncurrentradio.TabIndex = 31;
            this.Electroncurrentradio.Text = "Electron current";
            this.Electroncurrentradio.UseVisualStyleBackColor = true;
            // 
            // Measureddataradio
            // 
            this.Measureddataradio.AutoSize = true;
            this.Measureddataradio.Checked = true;
            this.Measureddataradio.Location = new System.Drawing.Point(16, 19);
            this.Measureddataradio.Name = "Measureddataradio";
            this.Measureddataradio.Size = new System.Drawing.Size(96, 17);
            this.Measureddataradio.TabIndex = 30;
            this.Measureddataradio.TabStop = true;
            this.Measureddataradio.Text = "Measured data";
            this.Measureddataradio.UseVisualStyleBackColor = true;
            // 
            // showCurrentLoadButton
            // 
            this.showCurrentLoadButton.Location = new System.Drawing.Point(5, 134);
            this.showCurrentLoadButton.Name = "showCurrentLoadButton";
            this.showCurrentLoadButton.Size = new System.Drawing.Size(139, 26);
            this.showCurrentLoadButton.TabIndex = 29;
            this.showCurrentLoadButton.Text = "Loaded measurement";
            this.showCurrentLoadButton.UseVisualStyleBackColor = true;
            this.showCurrentLoadButton.Click += new System.EventHandler(this.switchCurrentLoad_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TimeValueLabel);
            this.groupBox4.Controls.Add(this.DateValueLabel);
            this.groupBox4.Controls.Add(this.estTimeLabel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dateLabel);
            this.groupBox4.Controls.Add(this.timeLabel);
            this.groupBox4.Location = new System.Drawing.Point(3, 572);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 86);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // TimeValueLabel
            // 
            this.TimeValueLabel.AutoSize = true;
            this.TimeValueLabel.Location = new System.Drawing.Point(60, 38);
            this.TimeValueLabel.Name = "TimeValueLabel";
            this.TimeValueLabel.Size = new System.Drawing.Size(0, 13);
            this.TimeValueLabel.TabIndex = 10;
            // 
            // DateValueLabel
            // 
            this.DateValueLabel.AutoSize = true;
            this.DateValueLabel.Location = new System.Drawing.Point(60, 18);
            this.DateValueLabel.Name = "DateValueLabel";
            this.DateValueLabel.Size = new System.Drawing.Size(0, 13);
            this.DateValueLabel.TabIndex = 9;
            // 
            // estTimeLabel
            // 
            this.estTimeLabel.AutoSize = true;
            this.estTimeLabel.Location = new System.Drawing.Point(60, 60);
            this.estTimeLabel.Name = "estTimeLabel";
            this.estTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.estTimeLabel.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Est. end:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(22, 18);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 13);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "Date:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(22, 38);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time:";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonnext);
            this.groupBox3.Controls.Add(this.buttonprevious);
            this.groupBox3.Controls.Add(this.energyScanStepTimeLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.resolutionLabel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.currentEnergyStep);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.currentCycle);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 152);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurement info";
            // 
            // buttonnext
            // 
            this.buttonnext.Location = new System.Drawing.Point(84, 115);
            this.buttonnext.Name = "buttonnext";
            this.buttonnext.Size = new System.Drawing.Size(61, 23);
            this.buttonnext.TabIndex = 9;
            this.buttonnext.Text = ">";
            this.buttonnext.UseVisualStyleBackColor = true;
            this.buttonnext.Click += new System.EventHandler(this.buttonnext_Click);
            // 
            // buttonprevious
            // 
            this.buttonprevious.Location = new System.Drawing.Point(6, 115);
            this.buttonprevious.Name = "buttonprevious";
            this.buttonprevious.Size = new System.Drawing.Size(61, 23);
            this.buttonprevious.TabIndex = 8;
            this.buttonprevious.Text = "<";
            this.buttonprevious.UseVisualStyleBackColor = true;
            this.buttonprevious.Click += new System.EventHandler(this.buttonprevious_Click);
            // 
            // energyScanStepTimeLabel
            // 
            this.energyScanStepTimeLabel.AutoSize = true;
            this.energyScanStepTimeLabel.Location = new System.Drawing.Point(76, 72);
            this.energyScanStepTimeLabel.Name = "energyScanStepTimeLabel";
            this.energyScanStepTimeLabel.Size = new System.Drawing.Size(13, 13);
            this.energyScanStepTimeLabel.TabIndex = 7;
            this.energyScanStepTimeLabel.Text = "0";
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
            this.resolutionLabel.Size = new System.Drawing.Size(13, 13);
            this.resolutionLabel.TabIndex = 5;
            this.resolutionLabel.Text = "0";
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
            // currentEnergyStep
            // 
            this.currentEnergyStep.Enabled = false;
            this.currentEnergyStep.Location = new System.Drawing.Point(74, 46);
            this.currentEnergyStep.Name = "currentEnergyStep";
            this.currentEnergyStep.Size = new System.Drawing.Size(72, 20);
            this.currentEnergyStep.TabIndex = 3;
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
            this.currentCycle.Location = new System.Drawing.Point(74, 23);
            this.currentCycle.Name = "currentCycle";
            this.currentCycle.Size = new System.Drawing.Size(72, 20);
            this.currentCycle.TabIndex = 1;
            this.currentCycle.TextChanged += new System.EventHandler(this.currentCycle_TextChanged_1);
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
            this.stopAfterCycle.Location = new System.Drawing.Point(13, 693);
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
            this.groupBox2.Location = new System.Drawing.Point(4, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 91);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data display mode";
            // 
            // dataDisplayAvg
            // 
            this.dataDisplayAvg.AutoSize = true;
            this.dataDisplayAvg.Location = new System.Drawing.Point(16, 19);
            this.dataDisplayAvg.Name = "dataDisplayAvg";
            this.dataDisplayAvg.Size = new System.Drawing.Size(44, 17);
            this.dataDisplayAvg.TabIndex = 20;
            this.dataDisplayAvg.Text = "Avg";
            this.dataDisplayAvg.UseVisualStyleBackColor = true;
            this.dataDisplayAvg.CheckedChanged += new System.EventHandler(this.dataDisplayAvg_CheckedChanged_1);
            this.dataDisplayAvg.Click += new System.EventHandler(this.dataDisplayAvg_Click);
            // 
            // dataDisplaySum
            // 
            this.dataDisplaySum.AutoSize = true;
            this.dataDisplaySum.Location = new System.Drawing.Point(16, 42);
            this.dataDisplaySum.Name = "dataDisplaySum";
            this.dataDisplaySum.Size = new System.Drawing.Size(46, 17);
            this.dataDisplaySum.TabIndex = 21;
            this.dataDisplaySum.Text = "Sum";
            this.dataDisplaySum.UseVisualStyleBackColor = true;
            this.dataDisplaySum.CheckedChanged += new System.EventHandler(this.dataDisplaySum_CheckedChanged_1);
            this.dataDisplaySum.Click += new System.EventHandler(this.dataDisplaySum_Click);
            // 
            // dataDisplayCurrent
            // 
            this.dataDisplayCurrent.AutoSize = true;
            this.dataDisplayCurrent.Checked = true;
            this.dataDisplayCurrent.Location = new System.Drawing.Point(16, 65);
            this.dataDisplayCurrent.Name = "dataDisplayCurrent";
            this.dataDisplayCurrent.Size = new System.Drawing.Size(87, 17);
            this.dataDisplayCurrent.TabIndex = 22;
            this.dataDisplayCurrent.TabStop = true;
            this.dataDisplayCurrent.Text = "Current cycle";
            this.dataDisplayCurrent.UseVisualStyleBackColor = true;
            this.dataDisplayCurrent.CheckedChanged += new System.EventHandler(this.dataDisplayCurrent_CheckedChanged);
            this.dataDisplayCurrent.Click += new System.EventHandler(this.dataDisplayCurrent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayModeLog);
            this.groupBox1.Controls.Add(this.displayModeLin);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 60);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphical display mode";
            // 
            // displayModeLog
            // 
            this.displayModeLog.AutoSize = true;
            this.displayModeLog.Location = new System.Drawing.Point(17, 37);
            this.displayModeLog.Name = "displayModeLog";
            this.displayModeLog.Size = new System.Drawing.Size(39, 17);
            this.displayModeLog.TabIndex = 11;
            this.displayModeLog.Text = "log";
            this.displayModeLog.UseVisualStyleBackColor = true;
            this.displayModeLog.CheckedChanged += new System.EventHandler(this.displayModeLog_CheckedChanged);
            // 
            // displayModeLin
            // 
            this.displayModeLin.AutoSize = true;
            this.displayModeLin.Checked = true;
            this.displayModeLin.Location = new System.Drawing.Point(17, 19);
            this.displayModeLin.Name = "displayModeLin";
            this.displayModeLin.Size = new System.Drawing.Size(35, 17);
            this.displayModeLin.TabIndex = 10;
            this.displayModeLin.TabStop = true;
            this.displayModeLin.Text = "lin";
            this.displayModeLin.UseVisualStyleBackColor = true;
            this.displayModeLin.CheckedChanged += new System.EventHandler(this.displayModeLin_CheckedChanged);
            // 
            // sidebarExportButton
            // 
            this.sidebarExportButton.Location = new System.Drawing.Point(9, 664);
            this.sidebarExportButton.Name = "sidebarExportButton";
            this.sidebarExportButton.Size = new System.Drawing.Size(140, 23);
            this.sidebarExportButton.TabIndex = 16;
            this.sidebarExportButton.Text = "Export ";
            this.sidebarExportButton.UseVisualStyleBackColor = true;
            this.sidebarExportButton.Click += new System.EventHandler(this.sidebarExportButton_Click_2);
            this.sidebarExportButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sidebarExportButton_KeyDown);
            this.sidebarExportButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.sidebarExportButton_PreviewKeyDown);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopButton.ForeColor = System.Drawing.Color.Snow;
            this.stopButton.Location = new System.Drawing.Point(9, 716);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(140, 23);
            this.stopButton.TabIndex = 15;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // kontainerPreGraf
            // 
            this.kontainerPreGraf.BackColor = System.Drawing.Color.Black;
            this.kontainerPreGraf.Dock = System.Windows.Forms.DockStyle.Left;
            this.kontainerPreGraf.Location = new System.Drawing.Point(0, 24);
            this.kontainerPreGraf.Name = "kontainerPreGraf";
            this.kontainerPreGraf.Size = new System.Drawing.Size(1024, 746);
            this.kontainerPreGraf.TabIndex = 10;
            this.kontainerPreGraf.Paint += new System.Windows.Forms.PaintEventHandler(this.kontainerPreGraf_Paint);
            this.kontainerPreGraf.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.kontainerPreGraf_PreviewKeyDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 770);
            this.Controls.Add(this.kontainerPreGraf);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CEMBA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Button sidebarExportButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RadioButton displayModeLog;
        private System.Windows.Forms.RadioButton displayModeLin;
        private System.Windows.Forms.RadioButton dataDisplayCurrent;
        private System.Windows.Forms.RadioButton dataDisplaySum;
        private System.Windows.Forms.RadioButton dataDisplayAvg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox stopAfterCycle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox currentCycle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentEnergyStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label energyScanStepTimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label estTimeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button showCurrentLoadButton;
        private System.Windows.Forms.Panel kontainerPreGraf;
        private System.Windows.Forms.Label TimeValueLabel;
        private System.Windows.Forms.Label DateValueLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton Capillarpressureradio;
        private System.Windows.Forms.RadioButton Chamberpressureradio;
        private System.Windows.Forms.RadioButton Temperatureradio;
        private System.Windows.Forms.RadioButton Electroncurrentradio;
        private System.Windows.Forms.RadioButton Measureddataradio;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label intensityValue;
        private System.Windows.Forms.Label cursorPositionValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label cursorPositionLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonnext;
        private System.Windows.Forms.Button buttonprevious;
    }
}

