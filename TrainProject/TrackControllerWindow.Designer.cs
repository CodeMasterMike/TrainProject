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
            this.green1SwitchLightGroupBox = new System.Windows.Forms.GroupBox();
            this.green1SwitchLightView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.greenCtrl2 = new System.Windows.Forms.TabPage();
            this.green2SwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.green2SwitchListView = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.green2SwitchLightView = new System.Windows.Forms.ListView();
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.redCtrl1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.red1SwitchLightView = new System.Windows.Forms.ListView();
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.red1SwitchListView = new System.Windows.Forms.ListView();
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.red1TestGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.red1CrossingGroupBox = new System.Windows.Forms.GroupBox();
            this.red1CrossingListView = new System.Windows.Forms.ListView();
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.redCtrl2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.red2SwitchLightView = new System.Windows.Forms.ListView();
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.red2SwitchListView = new System.Windows.Forms.ListView();
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.red2TestGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.red2CrossingGroupBox = new System.Windows.Forms.GroupBox();
            this.red2CrossingListView = new System.Windows.Forms.ListView();
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.murphyTab = new System.Windows.Forms.TabPage();
            this.restoreCtcComm = new System.Windows.Forms.Button();
            this.severTMComm = new System.Windows.Forms.Button();
            this.restoreTMComm = new System.Windows.Forms.Button();
            this.severCtcComm = new System.Windows.Forms.Button();
            this.random = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openPLCFile = new System.Windows.Forms.OpenFileDialog();
            this.Engineer.SuspendLayout();
            this.summaryTab.SuspendLayout();
            this.trainsSummaryBox.SuspendLayout();
            this.activeControllersGroupBox.SuspendLayout();
            this.systemInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoPictureBox)).BeginInit();
            this.greenCtrl1.SuspendLayout();
            this.green1SwitchLightGroupBox.SuspendLayout();
            this.green1CrossingGroupBox.SuspendLayout();
            this.green1TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.green1SwitchGroupBox.SuspendLayout();
            this.greenCtrl2.SuspendLayout();
            this.green2SwitchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.green2TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.green2CrossingGroupBox.SuspendLayout();
            this.redCtrl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.red1TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.red1CrossingGroupBox.SuspendLayout();
            this.redCtrl2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.red2TestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.red2CrossingGroupBox.SuspendLayout();
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
            this.Engineer.Location = new System.Drawing.Point(10, 10);
            this.Engineer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Engineer.Name = "Engineer";
            this.Engineer.SelectedIndex = 0;
            this.Engineer.Size = new System.Drawing.Size(1162, 818);
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
            this.summaryTab.Location = new System.Drawing.Point(4, 34);
            this.summaryTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.summaryTab.Name = "summaryTab";
            this.summaryTab.Size = new System.Drawing.Size(1154, 780);
            this.summaryTab.TabIndex = 2;
            this.summaryTab.Text = "Summary";
            // 
            // trainsSummaryBox
            // 
            this.trainsSummaryBox.Controls.Add(this.trainsSummaryList);
            this.trainsSummaryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainsSummaryBox.Location = new System.Drawing.Point(7, 333);
            this.trainsSummaryBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trainsSummaryBox.Name = "trainsSummaryBox";
            this.trainsSummaryBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trainsSummaryBox.Size = new System.Drawing.Size(528, 173);
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
            this.trainsSummaryList.Location = new System.Drawing.Point(10, 32);
            this.trainsSummaryList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trainsSummaryList.Name = "trainsSummaryList";
            this.trainsSummaryList.Scrollable = false;
            this.trainsSummaryList.Size = new System.Drawing.Size(514, 137);
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
            this.textBox1.Location = new System.Drawing.Point(2, 722);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(371, 30);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "plcFile.plc";
            // 
            // uploadPlcFile
            // 
            this.uploadPlcFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadPlcFile.Location = new System.Drawing.Point(2, 644);
            this.uploadPlcFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uploadPlcFile.Name = "uploadPlcFile";
            this.uploadPlcFile.Size = new System.Drawing.Size(179, 52);
            this.uploadPlcFile.TabIndex = 19;
            this.uploadPlcFile.Text = "Upload PLC";
            this.uploadPlcFile.UseVisualStyleBackColor = true;
            this.uploadPlcFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // activeControllersGroupBox
            // 
            this.activeControllersGroupBox.Controls.Add(this.activeControllersListView);
            this.activeControllersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeControllersGroupBox.Location = new System.Drawing.Point(2, 29);
            this.activeControllersGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.activeControllersGroupBox.Name = "activeControllersGroupBox";
            this.activeControllersGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.activeControllersGroupBox.Size = new System.Drawing.Size(533, 284);
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
            this.activeControllersListView.Location = new System.Drawing.Point(5, 32);
            this.activeControllersListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.activeControllersListView.Name = "activeControllersListView";
            this.activeControllersListView.Size = new System.Drawing.Size(524, 241);
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
            this.systemInfoGroupBox.Location = new System.Drawing.Point(541, 29);
            this.systemInfoGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.systemInfoGroupBox.Name = "systemInfoGroupBox";
            this.systemInfoGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.systemInfoGroupBox.Size = new System.Drawing.Size(580, 727);
            this.systemInfoGroupBox.TabIndex = 17;
            this.systemInfoGroupBox.TabStop = false;
            this.systemInfoGroupBox.Text = "System Information";
            this.systemInfoGroupBox.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // systemInfoPictureBox
            // 
            this.systemInfoPictureBox.Image = global::TrainProject.Properties.Resources.Track_Layout;
            this.systemInfoPictureBox.Location = new System.Drawing.Point(5, 32);
            this.systemInfoPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.systemInfoPictureBox.Name = "systemInfoPictureBox";
            this.systemInfoPictureBox.Size = new System.Drawing.Size(560, 691);
            this.systemInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.systemInfoPictureBox.TabIndex = 0;
            this.systemInfoPictureBox.TabStop = false;
            this.systemInfoPictureBox.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // greenCtrl1
            // 
            this.greenCtrl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.greenCtrl1.Controls.Add(this.green1SwitchLightGroupBox);
            this.greenCtrl1.Controls.Add(this.green1CrossingGroupBox);
            this.greenCtrl1.Controls.Add(this.green1TestGroupBox);
            this.greenCtrl1.Controls.Add(this.green1SwitchGroupBox);
            this.greenCtrl1.Location = new System.Drawing.Point(4, 34);
            this.greenCtrl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.greenCtrl1.Name = "greenCtrl1";
            this.greenCtrl1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.greenCtrl1.Size = new System.Drawing.Size(1154, 780);
            this.greenCtrl1.TabIndex = 0;
            this.greenCtrl1.Text = "Green Line, CTRL 1";
            // 
            // green1SwitchLightGroupBox
            // 
            this.green1SwitchLightGroupBox.Controls.Add(this.green1SwitchLightView);
            this.green1SwitchLightGroupBox.Location = new System.Drawing.Point(11, 276);
            this.green1SwitchLightGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchLightGroupBox.Name = "green1SwitchLightGroupBox";
            this.green1SwitchLightGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchLightGroupBox.Size = new System.Drawing.Size(555, 234);
            this.green1SwitchLightGroupBox.TabIndex = 19;
            this.green1SwitchLightGroupBox.TabStop = false;
            this.green1SwitchLightGroupBox.Text = "Switch Lights";
            // 
            // green1SwitchLightView
            // 
            this.green1SwitchLightView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.green1SwitchLightView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1SwitchLightView.Location = new System.Drawing.Point(10, 28);
            this.green1SwitchLightView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchLightView.Name = "green1SwitchLightView";
            this.green1SwitchLightView.Size = new System.Drawing.Size(541, 201);
            this.green1SwitchLightView.TabIndex = 0;
            this.green1SwitchLightView.UseCompatibleStateImageBehavior = false;
            this.green1SwitchLightView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Switch Id";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source Light";
            this.columnHeader2.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "T1 Light";
            this.columnHeader3.Width = 62;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "T2 Light";
            this.columnHeader4.Width = 136;
            // 
            // green1CrossingGroupBox
            // 
            this.green1CrossingGroupBox.Controls.Add(this.green1CrossingListView);
            this.green1CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1CrossingGroupBox.Location = new System.Drawing.Point(6, 515);
            this.green1CrossingGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1CrossingGroupBox.Name = "green1CrossingGroupBox";
            this.green1CrossingGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1CrossingGroupBox.Size = new System.Drawing.Size(560, 178);
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
            this.green1CrossingListView.Location = new System.Drawing.Point(10, 32);
            this.green1CrossingListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1CrossingListView.Name = "green1CrossingListView";
            this.green1CrossingListView.Size = new System.Drawing.Size(546, 142);
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
            this.green1TestGroupBox.Location = new System.Drawing.Point(571, 22);
            this.green1TestGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1TestGroupBox.Name = "green1TestGroupBox";
            this.green1TestGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1TestGroupBox.Size = new System.Drawing.Size(580, 727);
            this.green1TestGroupBox.TabIndex = 16;
            this.green1TestGroupBox.TabStop = false;
            this.green1TestGroupBox.Text = "Test Panel";
            this.green1TestGroupBox.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test Output";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 261);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(541, 451);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 102);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(426, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Test Controller";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Occupancy:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 51);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(311, 34);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 691);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // green1SwitchGroupBox
            // 
            this.green1SwitchGroupBox.Controls.Add(this.green1SwitchListView);
            this.green1SwitchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green1SwitchGroupBox.Location = new System.Drawing.Point(6, 22);
            this.green1SwitchGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchGroupBox.Name = "green1SwitchGroupBox";
            this.green1SwitchGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchGroupBox.Size = new System.Drawing.Size(560, 237);
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
            this.green1SwitchListView.Location = new System.Drawing.Point(5, 32);
            this.green1SwitchListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green1SwitchListView.Name = "green1SwitchListView";
            this.green1SwitchListView.Scrollable = false;
            this.green1SwitchListView.Size = new System.Drawing.Size(551, 195);
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
            // greenCtrl2
            // 
            this.greenCtrl2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.greenCtrl2.Controls.Add(this.green2SwitchGroupBox);
            this.greenCtrl2.Controls.Add(this.groupBox1);
            this.greenCtrl2.Controls.Add(this.green2TestGroupBox);
            this.greenCtrl2.Controls.Add(this.green2CrossingGroupBox);
            this.greenCtrl2.Location = new System.Drawing.Point(4, 34);
            this.greenCtrl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.greenCtrl2.Name = "greenCtrl2";
            this.greenCtrl2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.greenCtrl2.Size = new System.Drawing.Size(1154, 780);
            this.greenCtrl2.TabIndex = 3;
            this.greenCtrl2.Text = "Green Line, CTRL 2";
            // 
            // green2SwitchGroupBox
            // 
            this.green2SwitchGroupBox.Controls.Add(this.green2SwitchListView);
            this.green2SwitchGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2SwitchGroupBox.Location = new System.Drawing.Point(2, 17);
            this.green2SwitchGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2SwitchGroupBox.Name = "green2SwitchGroupBox";
            this.green2SwitchGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2SwitchGroupBox.Size = new System.Drawing.Size(560, 237);
            this.green2SwitchGroupBox.TabIndex = 21;
            this.green2SwitchGroupBox.TabStop = false;
            this.green2SwitchGroupBox.Text = "Switch Information";
            // 
            // green2SwitchListView
            // 
            this.green2SwitchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.green2SwitchListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2SwitchListView.Location = new System.Drawing.Point(5, 32);
            this.green2SwitchListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2SwitchListView.Name = "green2SwitchListView";
            this.green2SwitchListView.Scrollable = false;
            this.green2SwitchListView.Size = new System.Drawing.Size(551, 195);
            this.green2SwitchListView.TabIndex = 14;
            this.green2SwitchListView.UseCompatibleStateImageBehavior = false;
            this.green2SwitchListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Switch Id";
            this.columnHeader15.Width = 92;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Source Block";
            this.columnHeader16.Width = 108;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Target Block";
            this.columnHeader17.Width = 78;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Actions";
            this.columnHeader18.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.green2SwitchLightView);
            this.groupBox1.Location = new System.Drawing.Point(5, 260);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(555, 234);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Switch Lights";
            // 
            // green2SwitchLightView
            // 
            this.green2SwitchLightView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33});
            this.green2SwitchLightView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2SwitchLightView.Location = new System.Drawing.Point(10, 28);
            this.green2SwitchLightView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2SwitchLightView.Name = "green2SwitchLightView";
            this.green2SwitchLightView.Size = new System.Drawing.Size(541, 201);
            this.green2SwitchLightView.TabIndex = 0;
            this.green2SwitchLightView.UseCompatibleStateImageBehavior = false;
            this.green2SwitchLightView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Switch Id";
            this.columnHeader30.Width = 106;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Source Light";
            this.columnHeader31.Width = 87;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "T1 Light";
            this.columnHeader32.Width = 62;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "T2 Light";
            this.columnHeader33.Width = 136;
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
            this.green2TestGroupBox.Location = new System.Drawing.Point(570, 17);
            this.green2TestGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2TestGroupBox.Name = "green2TestGroupBox";
            this.green2TestGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2TestGroupBox.Size = new System.Drawing.Size(580, 727);
            this.green2TestGroupBox.TabIndex = 20;
            this.green2TestGroupBox.TabStop = false;
            this.green2TestGroupBox.Text = "Test Panel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Test Output";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(22, 261);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(541, 451);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test Controller";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Occupancy:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(137, 51);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(311, 34);
            this.textBox3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(5, 32);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(570, 691);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // green2CrossingGroupBox
            // 
            this.green2CrossingGroupBox.Controls.Add(this.listView3);
            this.green2CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.green2CrossingGroupBox.Location = new System.Drawing.Point(5, 511);
            this.green2CrossingGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2CrossingGroupBox.Name = "green2CrossingGroupBox";
            this.green2CrossingGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.green2CrossingGroupBox.Size = new System.Drawing.Size(560, 178);
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
            this.listView3.Location = new System.Drawing.Point(10, 32);
            this.listView3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(546, 142);
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
            // redCtrl1
            // 
            this.redCtrl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.redCtrl1.Controls.Add(this.groupBox3);
            this.redCtrl1.Controls.Add(this.groupBox2);
            this.redCtrl1.Controls.Add(this.red1TestGroupBox);
            this.redCtrl1.Controls.Add(this.red1CrossingGroupBox);
            this.redCtrl1.Location = new System.Drawing.Point(4, 34);
            this.redCtrl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.redCtrl1.Name = "redCtrl1";
            this.redCtrl1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.redCtrl1.Size = new System.Drawing.Size(1154, 780);
            this.redCtrl1.TabIndex = 4;
            this.redCtrl1.Text = "Red Line, CTRL 1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.red1SwitchLightView);
            this.groupBox3.Location = new System.Drawing.Point(7, 262);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(555, 234);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Switch Lights";
            // 
            // red1SwitchLightView
            // 
            this.red1SwitchLightView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51});
            this.red1SwitchLightView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red1SwitchLightView.Location = new System.Drawing.Point(10, 28);
            this.red1SwitchLightView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.red1SwitchLightView.Name = "red1SwitchLightView";
            this.red1SwitchLightView.Size = new System.Drawing.Size(541, 201);
            this.red1SwitchLightView.TabIndex = 0;
            this.red1SwitchLightView.UseCompatibleStateImageBehavior = false;
            this.red1SwitchLightView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Switch Id";
            this.columnHeader48.Width = 106;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "Source Light";
            this.columnHeader49.Width = 87;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "T1 Light";
            this.columnHeader50.Width = 62;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "T2 Light";
            this.columnHeader51.Width = 136;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.red1SwitchListView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(560, 237);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Switch Information";
            // 
            // red1SwitchListView
            // 
            this.red1SwitchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37});
            this.red1SwitchListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red1SwitchListView.Location = new System.Drawing.Point(5, 32);
            this.red1SwitchListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.red1SwitchListView.Name = "red1SwitchListView";
            this.red1SwitchListView.Scrollable = false;
            this.red1SwitchListView.Size = new System.Drawing.Size(551, 195);
            this.red1SwitchListView.TabIndex = 14;
            this.red1SwitchListView.UseCompatibleStateImageBehavior = false;
            this.red1SwitchListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Switch Id";
            this.columnHeader34.Width = 92;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Source Block";
            this.columnHeader35.Width = 108;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Target Block";
            this.columnHeader36.Width = 78;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Actions";
            this.columnHeader37.Width = 100;
            // 
            // red1TestGroupBox
            // 
            this.red1TestGroupBox.Controls.Add(this.label5);
            this.red1TestGroupBox.Controls.Add(this.richTextBox3);
            this.red1TestGroupBox.Controls.Add(this.button3);
            this.red1TestGroupBox.Controls.Add(this.label6);
            this.red1TestGroupBox.Controls.Add(this.textBox4);
            this.red1TestGroupBox.Controls.Add(this.pictureBox3);
            this.red1TestGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red1TestGroupBox.Location = new System.Drawing.Point(571, 10);
            this.red1TestGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.red1TestGroupBox.Name = "red1TestGroupBox";
            this.red1TestGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.red1TestGroupBox.Size = new System.Drawing.Size(581, 769);
            this.red1TestGroupBox.TabIndex = 21;
            this.red1TestGroupBox.TabStop = false;
            this.red1TestGroupBox.Text = "Test Panel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Test Output";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(17, 208);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(561, 546);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(142, 107);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(319, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "Test Controller";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Occupancy:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(176, 46);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(234, 34);
            this.textBox4.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(3, 25);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(574, 741);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // red1CrossingGroupBox
            // 
            this.red1CrossingGroupBox.Controls.Add(this.red1CrossingListView);
            this.red1CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red1CrossingGroupBox.Location = new System.Drawing.Point(7, 515);
            this.red1CrossingGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.red1CrossingGroupBox.Name = "red1CrossingGroupBox";
            this.red1CrossingGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.red1CrossingGroupBox.Size = new System.Drawing.Size(560, 175);
            this.red1CrossingGroupBox.TabIndex = 20;
            this.red1CrossingGroupBox.TabStop = false;
            this.red1CrossingGroupBox.Text = "Crossing Information";
            // 
            // red1CrossingListView
            // 
            this.red1CrossingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40});
            this.red1CrossingListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red1CrossingListView.Location = new System.Drawing.Point(7, 25);
            this.red1CrossingListView.Margin = new System.Windows.Forms.Padding(2);
            this.red1CrossingListView.Name = "red1CrossingListView";
            this.red1CrossingListView.Size = new System.Drawing.Size(536, 142);
            this.red1CrossingListView.TabIndex = 0;
            this.red1CrossingListView.UseCompatibleStateImageBehavior = false;
            this.red1CrossingListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Block ID";
            this.columnHeader38.Width = 130;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Activated";
            this.columnHeader39.Width = 150;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "";
            // 
            // redCtrl2
            // 
            this.redCtrl2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.redCtrl2.Controls.Add(this.groupBox5);
            this.redCtrl2.Controls.Add(this.groupBox4);
            this.redCtrl2.Controls.Add(this.red2TestGroupBox);
            this.redCtrl2.Controls.Add(this.red2CrossingGroupBox);
            this.redCtrl2.Location = new System.Drawing.Point(4, 34);
            this.redCtrl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.redCtrl2.Name = "redCtrl2";
            this.redCtrl2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.redCtrl2.Size = new System.Drawing.Size(1154, 780);
            this.redCtrl2.TabIndex = 5;
            this.redCtrl2.Text = "Red Line, CTRL 2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.red2SwitchLightView);
            this.groupBox5.Location = new System.Drawing.Point(6, 247);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(555, 234);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Switch Lights";
            // 
            // red2SwitchLightView
            // 
            this.red2SwitchLightView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55});
            this.red2SwitchLightView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red2SwitchLightView.Location = new System.Drawing.Point(10, 28);
            this.red2SwitchLightView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.red2SwitchLightView.Name = "red2SwitchLightView";
            this.red2SwitchLightView.Size = new System.Drawing.Size(541, 201);
            this.red2SwitchLightView.TabIndex = 0;
            this.red2SwitchLightView.UseCompatibleStateImageBehavior = false;
            this.red2SwitchLightView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "Switch Id";
            this.columnHeader52.Width = 106;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Source Light";
            this.columnHeader53.Width = 87;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "T1 Light";
            this.columnHeader54.Width = 62;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "T2 Light";
            this.columnHeader55.Width = 136;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.red2SwitchListView);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 5);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(560, 237);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Switch Information";
            // 
            // red2SwitchListView
            // 
            this.red2SwitchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47});
            this.red2SwitchListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red2SwitchListView.Location = new System.Drawing.Point(5, 32);
            this.red2SwitchListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.red2SwitchListView.Name = "red2SwitchListView";
            this.red2SwitchListView.Scrollable = false;
            this.red2SwitchListView.Size = new System.Drawing.Size(551, 195);
            this.red2SwitchListView.TabIndex = 14;
            this.red2SwitchListView.UseCompatibleStateImageBehavior = false;
            this.red2SwitchListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "Switch Id";
            this.columnHeader44.Width = 92;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Source Block";
            this.columnHeader45.Width = 108;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Target Block";
            this.columnHeader46.Width = 78;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Actions";
            this.columnHeader47.Width = 100;
            // 
            // red2TestGroupBox
            // 
            this.red2TestGroupBox.Controls.Add(this.label7);
            this.red2TestGroupBox.Controls.Add(this.richTextBox4);
            this.red2TestGroupBox.Controls.Add(this.button4);
            this.red2TestGroupBox.Controls.Add(this.label8);
            this.red2TestGroupBox.Controls.Add(this.textBox5);
            this.red2TestGroupBox.Controls.Add(this.pictureBox4);
            this.red2TestGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red2TestGroupBox.Location = new System.Drawing.Point(570, 20);
            this.red2TestGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.red2TestGroupBox.Name = "red2TestGroupBox";
            this.red2TestGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.red2TestGroupBox.Size = new System.Drawing.Size(582, 759);
            this.red2TestGroupBox.TabIndex = 25;
            this.red2TestGroupBox.TabStop = false;
            this.red2TestGroupBox.Text = "Test Panel";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "Test Output";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(17, 208);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(562, 539);
            this.richTextBox4.TabIndex = 4;
            this.richTextBox4.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(117, 87);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(319, 31);
            this.button4.TabIndex = 3;
            this.button4.Text = "Test Controller";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Occupancy:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(154, 41);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(234, 34);
            this.textBox5.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(3, 25);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(575, 734);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // red2CrossingGroupBox
            // 
            this.red2CrossingGroupBox.Controls.Add(this.red2CrossingListView);
            this.red2CrossingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red2CrossingGroupBox.Location = new System.Drawing.Point(6, 486);
            this.red2CrossingGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.red2CrossingGroupBox.Name = "red2CrossingGroupBox";
            this.red2CrossingGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.red2CrossingGroupBox.Size = new System.Drawing.Size(555, 179);
            this.red2CrossingGroupBox.TabIndex = 24;
            this.red2CrossingGroupBox.TabStop = false;
            this.red2CrossingGroupBox.Text = "Crossing Information";
            // 
            // red2CrossingListView
            // 
            this.red2CrossingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43});
            this.red2CrossingListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.red2CrossingListView.Location = new System.Drawing.Point(5, 30);
            this.red2CrossingListView.Margin = new System.Windows.Forms.Padding(2);
            this.red2CrossingListView.Name = "red2CrossingListView";
            this.red2CrossingListView.Size = new System.Drawing.Size(546, 146);
            this.red2CrossingListView.TabIndex = 0;
            this.red2CrossingListView.UseCompatibleStateImageBehavior = false;
            this.red2CrossingListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Block ID";
            this.columnHeader41.Width = 130;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Activated";
            this.columnHeader42.Width = 150;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "";
            // 
            // murphyTab
            // 
            this.murphyTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.murphyTab.Controls.Add(this.restoreCtcComm);
            this.murphyTab.Controls.Add(this.severTMComm);
            this.murphyTab.Controls.Add(this.restoreTMComm);
            this.murphyTab.Controls.Add(this.severCtcComm);
            this.murphyTab.Location = new System.Drawing.Point(4, 34);
            this.murphyTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.murphyTab.Name = "murphyTab";
            this.murphyTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.murphyTab.Size = new System.Drawing.Size(1154, 780);
            this.murphyTab.TabIndex = 1;
            this.murphyTab.Text = "Murphy";
            // 
            // restoreCtcComm
            // 
            this.restoreCtcComm.Location = new System.Drawing.Point(317, 291);
            this.restoreCtcComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.restoreCtcComm.Name = "restoreCtcComm";
            this.restoreCtcComm.Size = new System.Drawing.Size(222, 102);
            this.restoreCtcComm.TabIndex = 3;
            this.restoreCtcComm.Text = "Restore Communication with CTC";
            this.restoreCtcComm.UseVisualStyleBackColor = true;
            this.restoreCtcComm.Click += new System.EventHandler(this.restoreCtcComm_Click);
            // 
            // severTMComm
            // 
            this.severTMComm.Location = new System.Drawing.Point(543, 183);
            this.severTMComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.severTMComm.Name = "severTMComm";
            this.severTMComm.Size = new System.Drawing.Size(211, 102);
            this.severTMComm.TabIndex = 2;
            this.severTMComm.Text = "Sever Communication with Track Model\r\n";
            this.severTMComm.UseVisualStyleBackColor = true;
            this.severTMComm.Click += new System.EventHandler(this.severTMComm_Click);
            // 
            // restoreTMComm
            // 
            this.restoreTMComm.Location = new System.Drawing.Point(543, 291);
            this.restoreTMComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.restoreTMComm.Name = "restoreTMComm";
            this.restoreTMComm.Size = new System.Drawing.Size(211, 102);
            this.restoreTMComm.TabIndex = 1;
            this.restoreTMComm.Text = "Restore Communication with Track Model";
            this.restoreTMComm.UseVisualStyleBackColor = true;
            this.restoreTMComm.Click += new System.EventHandler(this.restoreTMComm_Click);
            // 
            // severCtcComm
            // 
            this.severCtcComm.Location = new System.Drawing.Point(317, 183);
            this.severCtcComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.severCtcComm.Name = "severCtcComm";
            this.severCtcComm.Size = new System.Drawing.Size(222, 102);
            this.severCtcComm.TabIndex = 0;
            this.severCtcComm.Text = "Sever Communication with CTC";
            this.severCtcComm.UseVisualStyleBackColor = true;
            this.severCtcComm.Click += new System.EventHandler(this.severCtcComm_Click);
            // 
            // random
            // 
            this.random.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26});
            this.random.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.random.Location = new System.Drawing.Point(6, 38);
            this.random.Name = "random";
            this.random.Scrollable = false;
            this.random.Size = new System.Drawing.Size(660, 233);
            this.random.TabIndex = 14;
            this.random.UseCompatibleStateImageBehavior = false;
            this.random.View = System.Windows.Forms.View.Details;
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
            // openPLCFile
            // 
            this.openPLCFile.FileName = "openFileDialog1";
            this.openPLCFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // TrackControllerWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 838);
            this.Controls.Add(this.Engineer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1200, 885);
            this.MinimumSize = new System.Drawing.Size(1200, 885);
            this.Name = "TrackControllerWindow";
            this.Text = "Wayside Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Engineer.ResumeLayout(false);
            this.summaryTab.ResumeLayout(false);
            this.summaryTab.PerformLayout();
            this.trainsSummaryBox.ResumeLayout(false);
            this.activeControllersGroupBox.ResumeLayout(false);
            this.systemInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoPictureBox)).EndInit();
            this.greenCtrl1.ResumeLayout(false);
            this.green1SwitchLightGroupBox.ResumeLayout(false);
            this.green1CrossingGroupBox.ResumeLayout(false);
            this.green1TestGroupBox.ResumeLayout(false);
            this.green1TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.green1SwitchGroupBox.ResumeLayout(false);
            this.greenCtrl2.ResumeLayout(false);
            this.green2SwitchGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.green2TestGroupBox.ResumeLayout(false);
            this.green2TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.green2CrossingGroupBox.ResumeLayout(false);
            this.redCtrl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.red1TestGroupBox.ResumeLayout(false);
            this.red1TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.red1CrossingGroupBox.ResumeLayout(false);
            this.redCtrl2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.red2TestGroupBox.ResumeLayout(false);
            this.red2TestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.red2CrossingGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.ListView random;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.OpenFileDialog openPLCFile;
        private System.Windows.Forms.GroupBox red1CrossingGroupBox;
        private System.Windows.Forms.ListView red1CrossingListView;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.GroupBox red1TestGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox red2TestGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox red2CrossingGroupBox;
        private System.Windows.Forms.ListView red2CrossingListView;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.GroupBox green1SwitchLightGroupBox;
        private System.Windows.Forms.ListView green1SwitchLightView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox green2SwitchGroupBox;
        private System.Windows.Forms.ListView green2SwitchListView;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView green2SwitchLightView;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView red1SwitchListView;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ColumnHeader columnHeader49;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ListView red1SwitchLightView;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView red2SwitchLightView;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView red2SwitchListView;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
    }
}

