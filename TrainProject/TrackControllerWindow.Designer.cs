//Created by Gabriel Wells
// Date created 1/27/17
// This is the UI Code for the Track Controller 
using TrainProject;

namespace TrainProject
{
    partial class TrackControllerWindow
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
            this.Engineer = new System.Windows.Forms.TabControl();
            this.summaryTab = new System.Windows.Forms.TabPage();
            this.trainsSummaryBox = new System.Windows.Forms.GroupBox();
            this.trainsSummaryList = new System.Windows.Forms.ListView();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uploadPlcFile = new System.Windows.Forms.Button();
            this.activeControllersGroupBox = new System.Windows.Forms.GroupBox();
            this.activeControllersListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.systemInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.systemInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.greenCtrl1 = new System.Windows.Forms.TabPage();
            this.green1CrossingGroupBox = new System.Windows.Forms.GroupBox();
            this.green1CrossingListView = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.green1TestGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.green1SwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.green1SwitchListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.green1TrainsGroupBox = new System.Windows.Forms.GroupBox();
            this.green1TrainsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.greenCtrl2 = new System.Windows.Forms.TabPage();
            this.green2TestGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.green2CrossingGroupBox = new System.Windows.Forms.GroupBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.green2SwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.green2SwitchListView = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.redCtrl1 = new System.Windows.Forms.TabPage();
            this.redCtrl2 = new System.Windows.Forms.TabPage();
            this.murphyTab = new System.Windows.Forms.TabPage();
            this.restoreCtcComm = new System.Windows.Forms.Button();
            this.severTMComm = new System.Windows.Forms.Button();
            this.restoreTMComm = new System.Windows.Forms.Button();
            this.severCtcComm = new System.Windows.Forms.Button();
            this.openPLCFile = new System.Windows.Forms.OpenFileDialog();
            this.Engineer.SuspendLayout();
            this.summaryTab.SuspendLayout();
            this.trainsSummaryBox.SuspendLayout();
            this.activeControllersGroupBox.SuspendLayout();
            this.systemInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoPictureBox)).BeginInit();
            this.greenCtrl1.SuspendLayout();
            this.green1CrossingGroupBox.SuspendLayout();
            this.green1TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.green1SwitchGroupBox.SuspendLayout();
            this.green1TrainsGroupBox.SuspendLayout();
            this.greenCtrl2.SuspendLayout();
            this.green2TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.green2CrossingGroupBox.SuspendLayout();
            this.green2SwitchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.murphyTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Engineer
            // 
            this.Engineer.Controls.Add(this.summaryTab);
            this.Engineer.Controls.Add(this.greenCtrl1);
            this.Engineer.Controls.Add(this.greenCtrl2);
            this.Engineer.Controls.Add(this.redCtrl1);
            this.Engineer.Controls.Add(this.redCtrl2);
            this.Engineer.Controls.Add(this.murphyTab);
            this.Engineer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Engineer.Location = new System.Drawing.Point(12, 12);
            this.Engineer.Name = "Engineer";
            this.Engineer.SelectedIndex = 0;
            this.Engineer.Size = new System.Drawing.Size(1395, 982);
            this.Engineer.TabIndex = 15;
            // 
            // summaryTab
            // 
            this.summaryTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.summaryTab.Controls.Add(this.trainsSummaryBox);
            this.summaryTab.Controls.Add(this.textBox1);
            this.summaryTab.Controls.Add(this.uploadPlcFile);
            this.summaryTab.Controls.Add(this.activeControllersGroupBox);
            this.summaryTab.Controls.Add(this.systemInfoGroupBox);
            this.summaryTab.Location = new System.Drawing.Point(4, 38);
            this.summaryTab.Name = "summaryTab";
            this.summaryTab.Size = new System.Drawing.Size(1387, 940);
            this.summaryTab.TabIndex = 2;
            this.summaryTab.Text = "Summary";
            // 
            // trainsSummaryBox
            // 
            this.trainsSummaryBox.Controls.Add(this.trainsSummaryList);
            this.trainsSummaryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainsSummaryBox.Location = new System.Drawing.Point(9, 400);
            this.trainsSummaryBox.Name = "trainsSummaryBox";
            this.trainsSummaryBox.Size = new System.Drawing.Size(634, 208);
            this.trainsSummaryBox.TabIndex = 21;
            this.trainsSummaryBox.TabStop = false;
            this.trainsSummaryBox.Text = "Trains";
            // 
            // trainsSummaryList
            // 
            this.trainsSummaryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.trainsSummaryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainsSummaryList.Location = new System.Drawing.Point(12, 38);
            this.trainsSummaryList.Name = "trainsSummaryList";
            this.trainsSummaryList.Scrollable = false;
            this.trainsSummaryList.Size = new System.Drawing.Size(616, 164);
            this.trainsSummaryList.TabIndex = 5;
            this.trainsSummaryList.UseCompatibleStateImageBehavior = false;
            this.trainsSummaryList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Train ID";
            this.columnHeader19.Width = 75;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Current Block";
            this.columnHeader20.Width = 120;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Speed (km/h)";
            this.columnHeader21.Width = 120;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Authority (km)";
            this.columnHeader22.Width = 200;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 867);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(445, 35);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "plcFile.plc";
            // 
            // uploadPlcFile
            // 
            this.uploadPlcFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadPlcFile.Location = new System.Drawing.Point(3, 773);
            this.uploadPlcFile.Name = "uploadPlcFile";
            this.uploadPlcFile.Size = new System.Drawing.Size(215, 63);
            this.uploadPlcFile.TabIndex = 19;
            this.uploadPlcFile.Text = "Upload PLC";
            this.uploadPlcFile.UseVisualStyleBackColor = true;
            this.uploadPlcFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // activeControllersGroupBox
            // 
            this.activeControllersGroupBox.Controls.Add(this.activeControllersListView);
            this.activeControllersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeControllersGroupBox.Location = new System.Drawing.Point(3, 35);
            this.activeControllersGroupBox.Name = "activeControllersGroupBox";
            this.activeControllersGroupBox.Size = new System.Drawing.Size(640, 341);
            this.activeControllersGroupBox.TabIndex = 18;
            this.activeControllersGroupBox.TabStop = false;
            this.activeControllersGroupBox.Text = "Active Controllers";
            // 
            // activeControllersListView
            // 
            this.activeControllersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader14});
            this.activeControllersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeControllersListView.Location = new System.Drawing.Point(6, 38);
            this.activeControllersListView.Name = "activeControllersListView";
            this.activeControllersListView.Size = new System.Drawing.Size(628, 288);
            this.activeControllersListView.TabIndex = 0;
            this.activeControllersListView.UseCompatibleStateImageBehavior = false;
            this.activeControllersListView.View = System.Windows.Forms.View.Details;
            this.activeControllersListView.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Controller Id";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Switches";
            this.columnHeader13.Width = 154;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Crossings";
            this.columnHeader14.Width = 179;
            // 
            // systemInfoGroupBox
            // 
            this.systemInfoGroupBox.Controls.Add(this.systemInfoPictureBox);
            this.systemInfoGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemInfoGroupBox.Location = new System.Drawing.Point(649, 35);
            this.systemInfoGroupBox.Name = "systemInfoGroupBox";
            this.systemInfoGroupBox.Size = new System.Drawing.Size(696, 873);
            this.systemInfoGroupBox.TabIndex = 17;
            this.systemInfoGroupBox.TabStop = false;
            this.systemInfoGroupBox.Text = "System Information";
            this.systemInfoGroupBox.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // systemInfoPictureBox
            // 
            this.systemInfoPictureBox.Image = global::TrainProject.Properties.Resources.Track_Layout;
            this.systemInfoPictureBox.Location = new System.Drawing.Point(6, 38);
            this.systemInfoPictureBox.Name = "systemInfoPictureBox";
            this.systemInfoPictureBox.Size = new System.Drawing.Size(672, 829);
            this.systemInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.systemInfoPictureBox.TabIndex = 0;
            this.systemInfoPictureBox.TabStop = false;
            this.systemInfoPictureBox.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // greenCtrl1
            // 
            this.greenCtrl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.greenCtrl1.Controls.Add(this.green1CrossingGroupBox);
            this.greenCtrl1.Controls.Add(this.green1TestGroupBox);
            this.greenCtrl1.Controls.Add(this.green1SwitchGroupBox);
            this.greenCtrl1.Controls.Add(this.green1TrainsGroupBox);
            this.greenCtrl1.Location = new System.Drawing.Point(4, 38);
            this.greenCtrl1.Name = "greenCtrl1";
            this.greenCtrl1.Padding = new System.Windows.Forms.Padding(3);
            this.greenCtrl1.Size = new System.Drawing.Size(1387, 940);
            this.greenCtrl1.TabIndex = 0;
            this.greenCtrl1.Text = "Green Line, CTRL 1";
            // 
            // green1CrossingGroupBox
            // 
            this.green1CrossingGroupBox.Controls.Add(this.green1CrossingListView);
            this.green1CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1CrossingGroupBox.Location = new System.Drawing.Point(13, 532);
            this.green1CrossingGroupBox.Name = "green1CrossingGroupBox";
            this.green1CrossingGroupBox.Size = new System.Drawing.Size(672, 214);
            this.green1CrossingGroupBox.TabIndex = 18;
            this.green1CrossingGroupBox.TabStop = false;
            this.green1CrossingGroupBox.Text = "Crossing Information";
            // 
            // green1CrossingListView
            // 
            this.green1CrossingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.green1CrossingListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1CrossingListView.Location = new System.Drawing.Point(12, 38);
            this.green1CrossingListView.Name = "green1CrossingListView";
            this.green1CrossingListView.Size = new System.Drawing.Size(654, 170);
            this.green1CrossingListView.TabIndex = 0;
            this.green1CrossingListView.UseCompatibleStateImageBehavior = false;
            this.green1CrossingListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Block ID";
            this.columnHeader10.Width = 130;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Activated";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "";
            // 
            // green1TestGroupBox
            // 
            this.green1TestGroupBox.Controls.Add(this.label2);
            this.green1TestGroupBox.Controls.Add(this.richTextBox1);
            this.green1TestGroupBox.Controls.Add(this.button2);
            this.green1TestGroupBox.Controls.Add(this.label1);
            this.green1TestGroupBox.Controls.Add(this.textBox2);
            this.green1TestGroupBox.Controls.Add(this.pictureBox1);
            this.green1TestGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1TestGroupBox.Location = new System.Drawing.Point(685, 27);
            this.green1TestGroupBox.Name = "green1TestGroupBox";
            this.green1TestGroupBox.Size = new System.Drawing.Size(696, 873);
            this.green1TestGroupBox.TabIndex = 16;
            this.green1TestGroupBox.TabStop = false;
            this.green1TestGroupBox.Text = "Test Panel";
            this.green1TestGroupBox.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test Output";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(26, 313);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(649, 540);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(511, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Test Controller";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Occupancy:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(372, 39);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(684, 829);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // green1SwitchGroupBox
            // 
            this.green1SwitchGroupBox.Controls.Add(this.green1SwitchListView);
            this.green1SwitchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1SwitchGroupBox.Location = new System.Drawing.Point(13, 241);
            this.green1SwitchGroupBox.Name = "green1SwitchGroupBox";
            this.green1SwitchGroupBox.Size = new System.Drawing.Size(672, 285);
            this.green1SwitchGroupBox.TabIndex = 14;
            this.green1SwitchGroupBox.TabStop = false;
            this.green1SwitchGroupBox.Text = "Switch Information";
            this.green1SwitchGroupBox.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // green1SwitchListView
            // 
            this.green1SwitchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.green1SwitchListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1SwitchListView.Location = new System.Drawing.Point(6, 38);
            this.green1SwitchListView.Name = "green1SwitchListView";
            this.green1SwitchListView.Scrollable = false;
            this.green1SwitchListView.Size = new System.Drawing.Size(660, 233);
            this.green1SwitchListView.TabIndex = 14;
            this.green1SwitchListView.UseCompatibleStateImageBehavior = false;
            this.green1SwitchListView.View = System.Windows.Forms.View.Details;
            this.green1SwitchListView.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged_2);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Switch Id";
            this.columnHeader5.Width = 92;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Source Block";
            this.columnHeader6.Width = 108;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Target Block";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Actions";
            this.columnHeader8.Width = 100;
            // 
            // green1TrainsGroupBox
            // 
            this.green1TrainsGroupBox.Controls.Add(this.green1TrainsListView);
            this.green1TrainsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1TrainsGroupBox.Location = new System.Drawing.Point(7, 27);
            this.green1TrainsGroupBox.Name = "green1TrainsGroupBox";
            this.green1TrainsGroupBox.Size = new System.Drawing.Size(672, 208);
            this.green1TrainsGroupBox.TabIndex = 12;
            this.green1TrainsGroupBox.TabStop = false;
            this.green1TrainsGroupBox.Text = "Trains";
            // 
            // green1TrainsListView
            // 
            this.green1TrainsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.green1TrainsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1TrainsListView.Location = new System.Drawing.Point(12, 38);
            this.green1TrainsListView.Name = "green1TrainsListView";
            this.green1TrainsListView.Scrollable = false;
            this.green1TrainsListView.Size = new System.Drawing.Size(654, 164);
            this.green1TrainsListView.TabIndex = 5;
            this.green1TrainsListView.UseCompatibleStateImageBehavior = false;
            this.green1TrainsListView.View = System.Windows.Forms.View.Details;
            this.green1TrainsListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Train ID";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Current Block";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Speed (km/h)";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Authority (km)";
            this.columnHeader4.Width = 200;
            // 
            // greenCtrl2
            // 
            this.greenCtrl2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.greenCtrl2.Controls.Add(this.green2TestGroupBox);
            this.greenCtrl2.Controls.Add(this.green2CrossingGroupBox);
            this.greenCtrl2.Controls.Add(this.green2SwitchGroupBox);
            this.greenCtrl2.Controls.Add(this.groupBox1);
            this.greenCtrl2.Location = new System.Drawing.Point(4, 38);
            this.greenCtrl2.Name = "greenCtrl2";
            this.greenCtrl2.Padding = new System.Windows.Forms.Padding(3);
            this.greenCtrl2.Size = new System.Drawing.Size(1387, 940);
            this.greenCtrl2.TabIndex = 3;
            this.greenCtrl2.Text = "Green Line, CTRL 2";
            // 
            // green2TestGroupBox
            // 
            this.green2TestGroupBox.Controls.Add(this.label3);
            this.green2TestGroupBox.Controls.Add(this.richTextBox2);
            this.green2TestGroupBox.Controls.Add(this.button1);
            this.green2TestGroupBox.Controls.Add(this.label4);
            this.green2TestGroupBox.Controls.Add(this.textBox3);
            this.green2TestGroupBox.Controls.Add(this.pictureBox2);
            this.green2TestGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2TestGroupBox.Location = new System.Drawing.Point(684, 21);
            this.green2TestGroupBox.Name = "green2TestGroupBox";
            this.green2TestGroupBox.Size = new System.Drawing.Size(696, 873);
            this.green2TestGroupBox.TabIndex = 20;
            this.green2TestGroupBox.TabStop = false;
            this.green2TestGroupBox.Text = "Test Panel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Test Output";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(26, 313);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(649, 540);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(511, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test Controller";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Occupancy:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(165, 61);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(372, 39);
            this.textBox3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(684, 829);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // green2CrossingGroupBox
            // 
            this.green2CrossingGroupBox.Controls.Add(this.listView3);
            this.green2CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2CrossingGroupBox.Location = new System.Drawing.Point(6, 613);
            this.green2CrossingGroupBox.Name = "green2CrossingGroupBox";
            this.green2CrossingGroupBox.Size = new System.Drawing.Size(672, 214);
            this.green2CrossingGroupBox.TabIndex = 19;
            this.green2CrossingGroupBox.TabStop = false;
            this.green2CrossingGroupBox.Text = "Crossing Information";
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29});
            this.listView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView3.Location = new System.Drawing.Point(12, 38);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(654, 170);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Block ID";
            this.columnHeader27.Width = 130;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Activated";
            this.columnHeader28.Width = 150;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "";
            // 
            // green2SwitchGroupBox
            // 
            this.green2SwitchGroupBox.Controls.Add(this.green2SwitchListView);
            this.green2SwitchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2SwitchGroupBox.Location = new System.Drawing.Point(6, 272);
            this.green2SwitchGroupBox.Name = "green2SwitchGroupBox";
            this.green2SwitchGroupBox.Size = new System.Drawing.Size(672, 285);
            this.green2SwitchGroupBox.TabIndex = 15;
            this.green2SwitchGroupBox.TabStop = false;
            this.green2SwitchGroupBox.Text = "Switch Information";
            // 
            // green2SwitchListView
            // 
            this.green2SwitchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.green2SwitchListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2SwitchListView.Location = new System.Drawing.Point(6, 38);
            this.green2SwitchListView.Name = "green2SwitchListView";
            this.green2SwitchListView.Scrollable = false;
            this.green2SwitchListView.Size = new System.Drawing.Size(660, 233);
            this.green2SwitchListView.TabIndex = 14;
            this.green2SwitchListView.UseCompatibleStateImageBehavior = false;
            this.green2SwitchListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Switch Id";
            this.columnHeader23.Width = 92;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Source Block";
            this.columnHeader24.Width = 108;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Target Block";
            this.columnHeader25.Width = 78;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Actions";
            this.columnHeader26.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 208);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trains";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(12, 38);
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(654, 164);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Train ID";
            this.columnHeader15.Width = 75;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Current Block";
            this.columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Speed (km/h)";
            this.columnHeader17.Width = 120;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Authority (km)";
            this.columnHeader18.Width = 200;
            // 
            // redCtrl1
            // 
            this.redCtrl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.redCtrl1.Location = new System.Drawing.Point(4, 38);
            this.redCtrl1.Name = "redCtrl1";
            this.redCtrl1.Padding = new System.Windows.Forms.Padding(3);
            this.redCtrl1.Size = new System.Drawing.Size(1387, 940);
            this.redCtrl1.TabIndex = 4;
            this.redCtrl1.Text = "Red Line, CTRL 1";
            // 
            // redCtrl2
            // 
            this.redCtrl2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.redCtrl2.Location = new System.Drawing.Point(4, 38);
            this.redCtrl2.Name = "redCtrl2";
            this.redCtrl2.Padding = new System.Windows.Forms.Padding(3);
            this.redCtrl2.Size = new System.Drawing.Size(1387, 940);
            this.redCtrl2.TabIndex = 5;
            this.redCtrl2.Text = "Red Line, CTRL 2";
            // 
            // murphyTab
            // 
            this.murphyTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.murphyTab.Controls.Add(this.restoreCtcComm);
            this.murphyTab.Controls.Add(this.severTMComm);
            this.murphyTab.Controls.Add(this.restoreTMComm);
            this.murphyTab.Controls.Add(this.severCtcComm);
            this.murphyTab.Location = new System.Drawing.Point(4, 38);
            this.murphyTab.Name = "murphyTab";
            this.murphyTab.Padding = new System.Windows.Forms.Padding(3);
            this.murphyTab.Size = new System.Drawing.Size(1387, 940);
            this.murphyTab.TabIndex = 1;
            this.murphyTab.Text = "Murphy";
            // 
            // restoreCtcComm
            // 
            this.restoreCtcComm.Location = new System.Drawing.Point(380, 349);
            this.restoreCtcComm.Name = "restoreCtcComm";
            this.restoreCtcComm.Size = new System.Drawing.Size(266, 123);
            this.restoreCtcComm.TabIndex = 3;
            this.restoreCtcComm.Text = "Restore Communication with CTC";
            this.restoreCtcComm.UseVisualStyleBackColor = true;
            // 
            // severTMComm
            // 
            this.severTMComm.Location = new System.Drawing.Point(652, 220);
            this.severTMComm.Name = "severTMComm";
            this.severTMComm.Size = new System.Drawing.Size(253, 123);
            this.severTMComm.TabIndex = 2;
            this.severTMComm.Text = "Sever Communication with Track Model\r\n";
            this.severTMComm.UseVisualStyleBackColor = true;
            // 
            // restoreTMComm
            // 
            this.restoreTMComm.Location = new System.Drawing.Point(652, 349);
            this.restoreTMComm.Name = "restoreTMComm";
            this.restoreTMComm.Size = new System.Drawing.Size(253, 123);
            this.restoreTMComm.TabIndex = 1;
            this.restoreTMComm.Text = "Restore Communication with Track Model";
            this.restoreTMComm.UseVisualStyleBackColor = true;
            // 
            // severCtcComm
            // 
            this.severCtcComm.Location = new System.Drawing.Point(380, 220);
            this.severCtcComm.Name = "severCtcComm";
            this.severCtcComm.Size = new System.Drawing.Size(266, 123);
            this.severCtcComm.TabIndex = 0;
            this.severCtcComm.Text = "Sever Communication with CTC";
            this.severCtcComm.UseVisualStyleBackColor = true;
            // 
            // openPLCFile
            // 
            this.openPLCFile.FileName = "openFileDialog1";
            this.openPLCFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // TrackControllerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 1006);
            this.Controls.Add(this.Engineer);
            this.Name = "TrackControllerWindow";
            this.Text = "Track Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Engineer.ResumeLayout(false);
            this.summaryTab.ResumeLayout(false);
            this.summaryTab.PerformLayout();
            this.trainsSummaryBox.ResumeLayout(false);
            this.activeControllersGroupBox.ResumeLayout(false);
            this.systemInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoPictureBox)).EndInit();
            this.greenCtrl1.ResumeLayout(false);
            this.green1CrossingGroupBox.ResumeLayout(false);
            this.green1TestGroupBox.ResumeLayout(false);
            this.green1TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.green1SwitchGroupBox.ResumeLayout(false);
            this.green1TrainsGroupBox.ResumeLayout(false);
            this.greenCtrl2.ResumeLayout(false);
            this.green2TestGroupBox.ResumeLayout(false);
            this.green2TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.green2CrossingGroupBox.ResumeLayout(false);
            this.green2SwitchGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.murphyTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TabControl Engineer;
        private System.Windows.Forms.TabPage greenCtrl1;
        private System.Windows.Forms.GroupBox green1TestGroupBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox green1SwitchGroupBox;
        private System.Windows.Forms.ListView green1SwitchListView;
        private System.Windows.Forms.GroupBox green1TrainsGroupBox;
        private System.Windows.Forms.ListView green1TrainsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage murphyTab;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button restoreCtcComm;
        private System.Windows.Forms.Button severTMComm;
        private System.Windows.Forms.Button restoreTMComm;
        private System.Windows.Forms.Button severCtcComm;
        private System.Windows.Forms.GroupBox green1CrossingGroupBox;
        private System.Windows.Forms.ListView green1CrossingListView;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.TabPage summaryTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox systemInfoGroupBox;
        private System.Windows.Forms.PictureBox systemInfoPictureBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button uploadPlcFile;
        private System.Windows.Forms.GroupBox activeControllersGroupBox;
        private System.Windows.Forms.ListView activeControllersListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TabPage greenCtrl2;
        private System.Windows.Forms.TabPage redCtrl1;
        private System.Windows.Forms.TabPage redCtrl2;
        private System.Windows.Forms.GroupBox trainsSummaryBox;
        private System.Windows.Forms.ListView trainsSummaryList;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.GroupBox green2TestGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox green2CrossingGroupBox;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.GroupBox green2SwitchGroupBox;
        private System.Windows.Forms.ListView green2SwitchListView;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.OpenFileDialog openPLCFile;
    }
}

