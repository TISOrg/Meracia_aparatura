namespace JDLMLab
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaMeraniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.roky = new System.Windows.Forms.DataGridView();
            this.nazvy = new System.Windows.Forms.DataGridView();
            this.dates = new System.Windows.Forms.DataGridView();
            this.typy = new System.Windows.Forms.DataGridView();
            this.merania = new System.Windows.Forms.DataGridView();
            this.meranie = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nazvy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.merania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meranie)).BeginInit();
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
            this.oProgrameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveniaMeraniaToolStripMenuItem,
            this.nastaveniaToolStripMenuItem});
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
            // nastaveniaToolStripMenuItem
            // 
            this.nastaveniaToolStripMenuItem.Name = "nastaveniaToolStripMenuItem";
            this.nastaveniaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nastaveniaToolStripMenuItem.Text = "Nastavenia";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
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
            this.label1.Location = new System.Drawing.Point(1023, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meracia aparatúra";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(1095, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "lin";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1095, 117);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "log";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1029, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Prepni zobrazenie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(1018, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 341);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Export merania";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(11, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 65);
            this.button2.TabIndex = 0;
            this.button2.Text = "Zastav meranie";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(988, 499);
            this.dataGridView1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(1029, 444);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 83);
            this.button4.TabIndex = 7;
            this.button4.Text = "Štart";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // roky
            // 
            this.roky.AllowUserToAddRows = false;
            this.roky.AllowUserToDeleteRows = false;
            this.roky.AllowUserToResizeColumns = false;
            this.roky.AllowUserToResizeRows = false;
            this.roky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roky.Location = new System.Drawing.Point(22, 63);
            this.roky.MultiSelect = false;
            this.roky.Name = "roky";
            this.roky.ReadOnly = true;
            this.roky.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roky.RowHeadersVisible = false;
            this.roky.Size = new System.Drawing.Size(240, 150);
            this.roky.TabIndex = 8;
            this.roky.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roky_CellClick);
            // 
            // nazvy
            // 
            this.nazvy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nazvy.Location = new System.Drawing.Point(268, 63);
            this.nazvy.Name = "nazvy";
            this.nazvy.Size = new System.Drawing.Size(240, 150);
            this.nazvy.TabIndex = 9;
            this.nazvy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.nazvy_CellClick);
            // 
            // dates
            // 
            this.dates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dates.Location = new System.Drawing.Point(514, 63);
            this.dates.Name = "dates";
            this.dates.Size = new System.Drawing.Size(240, 150);
            this.dates.TabIndex = 10;
            this.dates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dates_CellClick);
            // 
            // typy
            // 
            this.typy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typy.Location = new System.Drawing.Point(760, 63);
            this.typy.Name = "typy";
            this.typy.Size = new System.Drawing.Size(240, 150);
            this.typy.TabIndex = 11;
            this.typy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.typy_CellClick);
            // 
            // merania
            // 
            this.merania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.merania.Location = new System.Drawing.Point(22, 219);
            this.merania.Name = "merania";
            this.merania.Size = new System.Drawing.Size(240, 150);
            this.merania.TabIndex = 12;
            this.merania.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.merania_CellClick);
            // 
            // meranie
            // 
            this.meranie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meranie.Location = new System.Drawing.Point(277, 227);
            this.meranie.Name = "meranie";
            this.meranie.Size = new System.Drawing.Size(679, 177);
            this.meranie.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 548);
            this.Controls.Add(this.meranie);
            this.Controls.Add(this.merania);
            this.Controls.Add(this.typy);
            this.Controls.Add(this.dates);
            this.Controls.Add(this.nazvy);
            this.Controls.Add(this.roky);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Meracia aparatúra";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nazvy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.merania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meranie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniaMeraniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgrameToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView roky;
        private System.Windows.Forms.DataGridView nazvy;
        private System.Windows.Forms.DataGridView dates;
        private System.Windows.Forms.DataGridView typy;
        private System.Windows.Forms.DataGridView merania;
        private System.Windows.Forms.DataGridView meranie;
    }
}

