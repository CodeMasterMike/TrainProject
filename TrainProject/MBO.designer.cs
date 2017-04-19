namespace MBO_UI
{
    partial class MBO
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(600, 13);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;

            this.tabControl1.Size = new System.Drawing.Size(779, 428);
            this.tabControl1.Size = new System.Drawing.Size(1168, 518);

            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";

            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(771, 402);

            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1160, 485);

            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Train Schedule";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Station Square",
            "Penn Station",
            "Steel Plaza",
            "PITT",
            "Dormont",
            "First Ave",
            "Shadyside",
            "Edgebrook",
            "Pioneer",
            "South Hills",
            "Swissville",
            "Herron Ave",
            "Pioneer",
            "South Bank",
            "Whited",
            "Inglewood",
            "Overbrook",
            "Mt. Lebanon",
            "Castle Shannon",
            "Glenbury",
            "Poplar"});
            this.listBox1.Location = new System.Drawing.Point(8, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(122, 444);
            this.listBox1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(160, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";

            this.panel1.Size = new System.Drawing.Size(661, 388);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(498, 253);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(139, 39);
            this.button10.TabIndex = 16;
            this.button10.Text = "Passenger Movement";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.passengerMovement_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(332, 253);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 39);
            this.button7.TabIndex = 15;
            this.button7.Text = "View Driver Schedule";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.viewDriverSchedule_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(498, 124);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 39);
            this.button9.TabIndex = 14;
            this.button9.Text = "Send Authority";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.setAuthority_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "Create Driver Schedule\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createDriverScheduleButton_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(498, 319);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(139, 38);
=======
            this.panel1.Size = new System.Drawing.Size(981, 467);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(765, 390);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(192, 43);

            this.button8.TabIndex = 12;
            this.button8.Text = "Fix Antenna";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.fixAntenna_Click);
            // 
            // button6
            // 

            this.button6.Location = new System.Drawing.Point(332, 124);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 39);

            this.button6.Location = new System.Drawing.Point(515, 164);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(193, 43);

            this.button6.TabIndex = 11;
            this.button6.Text = "View Train Schedule";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.viewTrainSchedule_Click);
            // 
            // button5
            // 

            this.button5.Location = new System.Drawing.Point(498, 186);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 40);

            this.button5.Location = new System.Drawing.Point(765, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(192, 43);

            this.button5.TabIndex = 10;
            this.button5.Text = "Calculate Variance";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.calculateVariance_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TrainProject.Properties.Resources.Track_Layout;

            this.pictureBox1.Location = new System.Drawing.Point(6, -10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 417);

            this.pictureBox1.Location = new System.Drawing.Point(48, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 429);

            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 

            this.button4.Location = new System.Drawing.Point(332, 319);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 38);

            this.button4.Location = new System.Drawing.Point(515, 388);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(193, 45);

            this.button4.TabIndex = 8;
            this.button4.Text = "Break Antenna";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.breakAntenna_Click);
            // 
            // button3
            // 

            this.button3.Location = new System.Drawing.Point(498, 57);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 40);

            this.button3.Location = new System.Drawing.Point(765, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 43);

            this.button3.TabIndex = 7;
            this.button3.Text = "Get Position/Speed";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.getPos_Click);
            // 
            // button2
            // 

            this.button2.Location = new System.Drawing.Point(332, 57);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 40);

            this.button2.Location = new System.Drawing.Point(515, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 43);

            this.button2.TabIndex = 6;
            this.button2.Text = "Create Train Schedule";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.createTrainScheduleButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, -2);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1168, 45);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "North Shore Extension Control System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label1.Location = new System.Drawing.Point(6, 478);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label1.Location = new System.Drawing.Point(8, 609);

            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "GPS Antenna Signal:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Lime;

            this.label15.Location = new System.Drawing.Point(170, 479);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label15.Location = new System.Drawing.Point(254, 609);

            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 29);
            this.label15.TabIndex = 3;
            this.label15.Text = "Connected";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label17.Location = new System.Drawing.Point(287, 479);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label17.Location = new System.Drawing.Point(444, 609);

            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 29);
            this.label17.TabIndex = 4;
            this.label17.Text = "Automatic Mode:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Lime;

            this.label18.Location = new System.Drawing.Point(420, 478);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label18.Location = new System.Drawing.Point(642, 609);

            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 29);
            this.label18.TabIndex = 5;
            this.label18.Text = "Active";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label3.Location = new System.Drawing.Point(508, 478);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label3.Location = new System.Drawing.Point(761, 609);

            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Variance:";
            this.label3.Click += new System.EventHandler(this.label3_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;

            this.label4.Location = new System.Drawing.Point(588, 478);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);

            this.label4.Location = new System.Drawing.Point(893, 609);

            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 43);
            this.button1.TabIndex = 13;
            this.button1.Text = "Create Driver Schedule\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createDriverScheduleButton_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(765, 164);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(192, 43);
            this.button9.TabIndex = 14;
            this.button9.Text = "Send Authority";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.setAuthority_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(515, 313);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(193, 45);
            this.button7.TabIndex = 15;
            this.button7.Text = "View Driver Schedule";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(764, 313);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(193, 45);
            this.button10.TabIndex = 16;
            this.button10.Text = "Passenger Movement";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.passengerMovement_Click);
            // 
            // MBO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(802, 508);

            this.ClientSize = new System.Drawing.Size(1180, 669);

            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MBO";
            this.Text = "MBO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
    }
}

