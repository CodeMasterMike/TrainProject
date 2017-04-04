﻿namespace CTC
{
    partial class Office
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DispatcherTab = new System.Windows.Forms.TabPage();
            this.notifBox = new System.Windows.Forms.GroupBox();
            this.notifLabel = new System.Windows.Forms.Label();
            this.systemConBox = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.fbRadio = new System.Windows.Forms.RadioButton();
            this.mboButton = new System.Windows.Forms.RadioButton();
            this.autoButton = new System.Windows.Forms.Button();
            this.manButton = new System.Windows.Forms.Button();
            this.sysModeLabel = new System.Windows.Forms.Label();
            this.trackBox = new System.Windows.Forms.GroupBox();
            this.fixTrackButton = new System.Windows.Forms.Button();
            this.fixTrainButton = new System.Windows.Forms.Button();
            this.closeBlockButton = new System.Windows.Forms.Button();
            this.openBlockButton = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.selLineLabel = new System.Windows.Forms.Label();
            this.dispatchGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dispTrain = new System.Windows.Forms.Button();
            this.selAuthLabel = new System.Windows.Forms.Label();
            this.selSpeedLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.selDenLabel = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.throughLabel = new System.Windows.Forms.Label();
            this.lineLabel = new System.Windows.Forms.Label();
            this.numTrainsLabel = new System.Windows.Forms.Label();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.sugAuthLabel = new System.Windows.Forms.Label();
            this.blockStatusLabel = new System.Windows.Forms.Label();
            this.blockLabel = new System.Windows.Forms.Label();
            this.sugSpeedLabel = new System.Windows.Forms.Label();
            this.trainNumLabel = new System.Windows.Forms.Label();
            this.systemBox = new System.Windows.Forms.GroupBox();
            this.MurphyTab = new System.Windows.Forms.TabPage();
            this.updateTimeLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.DispatcherTab.SuspendLayout();
            this.notifBox.SuspendLayout();
            this.systemConBox.SuspendLayout();
            this.trackBox.SuspendLayout();
            this.dispatchGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DispatcherTab);
            this.tabControl1.Controls.Add(this.MurphyTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1331, 676);
            this.tabControl1.TabIndex = 0;
            // 
            // DispatcherTab
            // 
            this.DispatcherTab.Controls.Add(this.notifBox);
            this.DispatcherTab.Controls.Add(this.systemConBox);
            this.DispatcherTab.Controls.Add(this.trackBox);
            this.DispatcherTab.Controls.Add(this.dispatchGroup);
            this.DispatcherTab.Controls.Add(this.infoBox);
            this.DispatcherTab.Controls.Add(this.systemBox);
            this.DispatcherTab.Location = new System.Drawing.Point(4, 25);
            this.DispatcherTab.Name = "DispatcherTab";
            this.DispatcherTab.Padding = new System.Windows.Forms.Padding(3);
            this.DispatcherTab.Size = new System.Drawing.Size(1323, 647);
            this.DispatcherTab.TabIndex = 0;
            this.DispatcherTab.Text = "Dispatcher";
            this.DispatcherTab.UseVisualStyleBackColor = true;
            // 
            // notifBox
            // 
            this.notifBox.Controls.Add(this.notifLabel);
            this.notifBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifBox.Location = new System.Drawing.Point(947, 159);
            this.notifBox.Name = "notifBox";
            this.notifBox.Size = new System.Drawing.Size(381, 130);
            this.notifBox.TabIndex = 2;
            this.notifBox.TabStop = false;
            this.notifBox.Text = "Notification Center";
            // 
            // notifLabel
            // 
            this.notifLabel.AutoSize = true;
            this.notifLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.notifLabel.Location = new System.Drawing.Point(126, 47);
            this.notifLabel.Name = "notifLabel";
            this.notifLabel.Size = new System.Drawing.Size(108, 18);
            this.notifLabel.TabIndex = 0;
            this.notifLabel.Text = "A-Ok for now";
            this.notifLabel.Click += new System.EventHandler(this.notifLabel_Click);
            // 
            // systemConBox
            // 
            this.systemConBox.Controls.Add(this.updateTimeLabel);
            this.systemConBox.Controls.Add(this.timeLabel);
            this.systemConBox.Controls.Add(this.fbRadio);
            this.systemConBox.Controls.Add(this.mboButton);
            this.systemConBox.Controls.Add(this.autoButton);
            this.systemConBox.Controls.Add(this.manButton);
            this.systemConBox.Controls.Add(this.sysModeLabel);
            this.systemConBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemConBox.Location = new System.Drawing.Point(947, 6);
            this.systemConBox.Name = "systemConBox";
            this.systemConBox.Size = new System.Drawing.Size(381, 150);
            this.systemConBox.TabIndex = 2;
            this.systemConBox.TabStop = false;
            this.systemConBox.Text = "System Control";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(6, 104);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(75, 29);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time:";
            // 
            // fbRadio
            // 
            this.fbRadio.AutoSize = true;
            this.fbRadio.Location = new System.Drawing.Point(224, 50);
            this.fbRadio.Name = "fbRadio";
            this.fbRadio.Size = new System.Drawing.Size(117, 24);
            this.fbRadio.TabIndex = 3;
            this.fbRadio.TabStop = true;
            this.fbRadio.Text = "Fixed Block";
            this.fbRadio.UseVisualStyleBackColor = true;
            this.fbRadio.CheckedChanged += new System.EventHandler(this.fbRadio_CheckedChanged);
            // 
            // mboButton
            // 
            this.mboButton.AutoSize = true;
            this.mboButton.Location = new System.Drawing.Point(224, 71);
            this.mboButton.Name = "mboButton";
            this.mboButton.Size = new System.Drawing.Size(130, 24);
            this.mboButton.TabIndex = 3;
            this.mboButton.TabStop = true;
            this.mboButton.Text = "Moving Block";
            this.mboButton.UseVisualStyleBackColor = true;
            this.mboButton.CheckedChanged += new System.EventHandler(this.mboButton_CheckedChanged);
            // 
            // autoButton
            // 
            this.autoButton.Location = new System.Drawing.Point(115, 50);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(103, 45);
            this.autoButton.TabIndex = 2;
            this.autoButton.Text = "Automatic";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // manButton
            // 
            this.manButton.Location = new System.Drawing.Point(6, 50);
            this.manButton.Name = "manButton";
            this.manButton.Size = new System.Drawing.Size(103, 45);
            this.manButton.TabIndex = 2;
            this.manButton.Text = "Manual";
            this.manButton.UseVisualStyleBackColor = true;
            this.manButton.Click += new System.EventHandler(this.manButton_Click);
            // 
            // sysModeLabel
            // 
            this.sysModeLabel.AutoSize = true;
            this.sysModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysModeLabel.Location = new System.Drawing.Point(123, 23);
            this.sysModeLabel.Name = "sysModeLabel";
            this.sysModeLabel.Size = new System.Drawing.Size(111, 18);
            this.sysModeLabel.TabIndex = 0;
            this.sysModeLabel.Text = "System Mode";
            // 
            // trackBox
            // 
            this.trackBox.Controls.Add(this.fixTrackButton);
            this.trackBox.Controls.Add(this.fixTrainButton);
            this.trackBox.Controls.Add(this.closeBlockButton);
            this.trackBox.Controls.Add(this.openBlockButton);
            this.trackBox.Controls.Add(this.comboBox6);
            this.trackBox.Controls.Add(this.selLineLabel);
            this.trackBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBox.Location = new System.Drawing.Point(661, 6);
            this.trackBox.Name = "trackBox";
            this.trackBox.Size = new System.Drawing.Size(280, 283);
            this.trackBox.TabIndex = 2;
            this.trackBox.TabStop = false;
            this.trackBox.Text = "Track Control and Maintenance";
            this.trackBox.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // fixTrackButton
            // 
            this.fixTrackButton.Location = new System.Drawing.Point(6, 161);
            this.fixTrackButton.Name = "fixTrackButton";
            this.fixTrackButton.Size = new System.Drawing.Size(268, 45);
            this.fixTrackButton.TabIndex = 2;
            this.fixTrackButton.Text = "Fix Track";
            this.fixTrackButton.UseVisualStyleBackColor = true;
            this.fixTrackButton.Click += new System.EventHandler(this.fixTrackButton_Click);
            // 
            // fixTrainButton
            // 
            this.fixTrainButton.Location = new System.Drawing.Point(6, 212);
            this.fixTrainButton.Name = "fixTrainButton";
            this.fixTrainButton.Size = new System.Drawing.Size(268, 45);
            this.fixTrainButton.TabIndex = 2;
            this.fixTrainButton.Text = "Fix Train";
            this.fixTrainButton.UseVisualStyleBackColor = true;
            this.fixTrainButton.Click += new System.EventHandler(this.fixTrainButton_Click);
            // 
            // closeBlockButton
            // 
            this.closeBlockButton.Location = new System.Drawing.Point(142, 88);
            this.closeBlockButton.Name = "closeBlockButton";
            this.closeBlockButton.Size = new System.Drawing.Size(132, 45);
            this.closeBlockButton.TabIndex = 2;
            this.closeBlockButton.Text = "Close Block";
            this.closeBlockButton.UseVisualStyleBackColor = true;
            this.closeBlockButton.Click += new System.EventHandler(this.closeBlockButton_Click);
            // 
            // openBlockButton
            // 
            this.openBlockButton.Location = new System.Drawing.Point(6, 88);
            this.openBlockButton.Name = "openBlockButton";
            this.openBlockButton.Size = new System.Drawing.Size(130, 45);
            this.openBlockButton.TabIndex = 2;
            this.openBlockButton.Text = "Open Block";
            this.openBlockButton.UseVisualStyleBackColor = true;
            this.openBlockButton.Click += new System.EventHandler(this.openBlockButton_Click);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(6, 40);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(268, 28);
            this.comboBox6.TabIndex = 1;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // selLineLabel
            // 
            this.selLineLabel.AutoSize = true;
            this.selLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selLineLabel.Location = new System.Drawing.Point(96, 19);
            this.selLineLabel.Name = "selLineLabel";
            this.selLineLabel.Size = new System.Drawing.Size(91, 18);
            this.selLineLabel.TabIndex = 0;
            this.selLineLabel.Text = "Select Line";
            // 
            // dispatchGroup
            // 
            this.dispatchGroup.Controls.Add(this.label2);
            this.dispatchGroup.Controls.Add(this.label1);
            this.dispatchGroup.Controls.Add(this.hScrollBar2);
            this.dispatchGroup.Controls.Add(this.hScrollBar1);
            this.dispatchGroup.Controls.Add(this.dispTrain);
            this.dispatchGroup.Controls.Add(this.selAuthLabel);
            this.dispatchGroup.Controls.Add(this.selSpeedLabel);
            this.dispatchGroup.Controls.Add(this.comboBox1);
            this.dispatchGroup.Controls.Add(this.selDenLabel);
            this.dispatchGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispatchGroup.Location = new System.Drawing.Point(339, 6);
            this.dispatchGroup.Name = "dispatchGroup";
            this.dispatchGroup.Size = new System.Drawing.Size(316, 283);
            this.dispatchGroup.TabIndex = 2;
            this.dispatchGroup.TabStop = false;
            this.dispatchGroup.Text = "Dispatch Control";
            this.dispatchGroup.Enter += new System.EventHandler(this.dispatchGroup_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "blocks";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "mph";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(21, 101);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(186, 21);
            this.hScrollBar2.TabIndex = 0;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(21, 153);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(186, 21);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // dispTrain
            // 
            this.dispTrain.Location = new System.Drawing.Point(34, 200);
            this.dispTrain.Name = "dispTrain";
            this.dispTrain.Size = new System.Drawing.Size(254, 45);
            this.dispTrain.TabIndex = 2;
            this.dispTrain.Text = "Dispatch Train";
            this.dispTrain.UseVisualStyleBackColor = true;
            this.dispTrain.Click += new System.EventHandler(this.dispTrain_Click);
            // 
            // selAuthLabel
            // 
            this.selAuthLabel.AutoSize = true;
            this.selAuthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selAuthLabel.Location = new System.Drawing.Point(77, 132);
            this.selAuthLabel.Name = "selAuthLabel";
            this.selAuthLabel.Size = new System.Drawing.Size(140, 18);
            this.selAuthLabel.TabIndex = 0;
            this.selAuthLabel.Text = "Suggest Authority";
            // 
            // selSpeedLabel
            // 
            this.selSpeedLabel.AutoSize = true;
            this.selSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selSpeedLabel.Location = new System.Drawing.Point(77, 77);
            this.selSpeedLabel.Name = "selSpeedLabel";
            this.selSpeedLabel.Size = new System.Drawing.Size(121, 18);
            this.selSpeedLabel.TabIndex = 0;
            this.selSpeedLabel.Text = "Suggest Speed";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // selDenLabel
            // 
            this.selDenLabel.AutoSize = true;
            this.selDenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selDenLabel.Location = new System.Drawing.Point(77, 21);
            this.selDenLabel.Name = "selDenLabel";
            this.selDenLabel.Size = new System.Drawing.Size(145, 18);
            this.selDenLabel.TabIndex = 0;
            this.selDenLabel.Text = "Select Destination";
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.throughLabel);
            this.infoBox.Controls.Add(this.lineLabel);
            this.infoBox.Controls.Add(this.numTrainsLabel);
            this.infoBox.Controls.Add(this.sectionLabel);
            this.infoBox.Controls.Add(this.sugAuthLabel);
            this.infoBox.Controls.Add(this.blockStatusLabel);
            this.infoBox.Controls.Add(this.blockLabel);
            this.infoBox.Controls.Add(this.sugSpeedLabel);
            this.infoBox.Controls.Add(this.trainNumLabel);
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(7, 4);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(326, 285);
            this.infoBox.TabIndex = 1;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Train and Track Information";
            this.infoBox.Enter += new System.EventHandler(this.infoBox_Enter);
            // 
            // throughLabel
            // 
            this.throughLabel.AutoSize = true;
            this.throughLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throughLabel.Location = new System.Drawing.Point(62, 248);
            this.throughLabel.Name = "throughLabel";
            this.throughLabel.Size = new System.Drawing.Size(87, 18);
            this.throughLabel.TabIndex = 0;
            this.throughLabel.Text = "Throughput:";
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLabel.Location = new System.Drawing.Point(110, 191);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(39, 18);
            this.lineLabel.TabIndex = 0;
            this.lineLabel.Text = "Line:";
            // 
            // numTrainsLabel
            // 
            this.numTrainsLabel.AutoSize = true;
            this.numTrainsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTrainsLabel.Location = new System.Drawing.Point(16, 219);
            this.numTrainsLabel.Name = "numTrainsLabel";
            this.numTrainsLabel.Size = new System.Drawing.Size(133, 18);
            this.numTrainsLabel.TabIndex = 0;
            this.numTrainsLabel.Text = "# Trains in Service:";
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionLabel.Location = new System.Drawing.Point(87, 163);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(62, 18);
            this.sectionLabel.TabIndex = 0;
            this.sectionLabel.Text = "Section:";
            // 
            // sugAuthLabel
            // 
            this.sugAuthLabel.AutoSize = true;
            this.sugAuthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sugAuthLabel.Location = new System.Drawing.Point(6, 79);
            this.sugAuthLabel.Name = "sugAuthLabel";
            this.sugAuthLabel.Size = new System.Drawing.Size(143, 18);
            this.sugAuthLabel.TabIndex = 0;
            this.sugAuthLabel.Text = "Suggested Authority:";
            // 
            // blockStatusLabel
            // 
            this.blockStatusLabel.AutoSize = true;
            this.blockStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockStatusLabel.Location = new System.Drawing.Point(53, 134);
            this.blockStatusLabel.Name = "blockStatusLabel";
            this.blockStatusLabel.Size = new System.Drawing.Size(96, 18);
            this.blockStatusLabel.TabIndex = 0;
            this.blockStatusLabel.Text = "Block Status:";
            // 
            // blockLabel
            // 
            this.blockLabel.AutoSize = true;
            this.blockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockLabel.Location = new System.Drawing.Point(99, 106);
            this.blockLabel.Name = "blockLabel";
            this.blockLabel.Size = new System.Drawing.Size(50, 18);
            this.blockLabel.TabIndex = 0;
            this.blockLabel.Text = "Block:";
            // 
            // sugSpeedLabel
            // 
            this.sugSpeedLabel.AutoSize = true;
            this.sugSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sugSpeedLabel.Location = new System.Drawing.Point(21, 52);
            this.sugSpeedLabel.Name = "sugSpeedLabel";
            this.sugSpeedLabel.Size = new System.Drawing.Size(128, 18);
            this.sugSpeedLabel.TabIndex = 0;
            this.sugSpeedLabel.Text = "Suggested Speed:";
            // 
            // trainNumLabel
            // 
            this.trainNumLabel.AutoSize = true;
            this.trainNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainNumLabel.Location = new System.Drawing.Point(47, 23);
            this.trainNumLabel.Name = "trainNumLabel";
            this.trainNumLabel.Size = new System.Drawing.Size(102, 18);
            this.trainNumLabel.TabIndex = 0;
            this.trainNumLabel.Text = "Train Number:";
            // 
            // systemBox
            // 
            this.systemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemBox.Location = new System.Drawing.Point(3, 295);
            this.systemBox.Name = "systemBox";
            this.systemBox.Size = new System.Drawing.Size(1325, 354);
            this.systemBox.TabIndex = 0;
            this.systemBox.TabStop = false;
            this.systemBox.Text = "System Overview";
            this.systemBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // MurphyTab
            // 
            this.MurphyTab.Location = new System.Drawing.Point(4, 25);
            this.MurphyTab.Name = "MurphyTab";
            this.MurphyTab.Padding = new System.Windows.Forms.Padding(3);
            this.MurphyTab.Size = new System.Drawing.Size(1323, 647);
            this.MurphyTab.TabIndex = 1;
            this.MurphyTab.Text = "Murphy";
            this.MurphyTab.UseVisualStyleBackColor = true;
            // 
            // updateTimeLabel
            // 
            this.updateTimeLabel.AutoSize = true;
            this.updateTimeLabel.Location = new System.Drawing.Point(87, 111);
            this.updateTimeLabel.Name = "updateTimeLabel";
            this.updateTimeLabel.Size = new System.Drawing.Size(73, 20);
            this.updateTimeLabel.TabIndex = 5;
            this.updateTimeLabel.Text = "00:00:00";
            // 
            // Office
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 689);
            this.Controls.Add(this.tabControl1);
            this.Name = "Office";
            this.Text = "Office";
            this.tabControl1.ResumeLayout(false);
            this.DispatcherTab.ResumeLayout(false);
            this.notifBox.ResumeLayout(false);
            this.notifBox.PerformLayout();
            this.systemConBox.ResumeLayout(false);
            this.systemConBox.PerformLayout();
            this.trackBox.ResumeLayout(false);
            this.trackBox.PerformLayout();
            this.dispatchGroup.ResumeLayout(false);
            this.dispatchGroup.PerformLayout();
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DispatcherTab;
        private System.Windows.Forms.GroupBox systemBox;
        private System.Windows.Forms.TabPage MurphyTab;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.GroupBox dispatchGroup;
        private System.Windows.Forms.Label sugAuthLabel;
        private System.Windows.Forms.Label blockStatusLabel;
        private System.Windows.Forms.Label blockLabel;
        private System.Windows.Forms.Label sugSpeedLabel;
        private System.Windows.Forms.Label trainNumLabel;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label sectionLabel;
        private System.Windows.Forms.Label throughLabel;
        private System.Windows.Forms.Label numTrainsLabel;
        private System.Windows.Forms.Label selDenLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button dispTrain;
        private System.Windows.Forms.Label selAuthLabel;
        private System.Windows.Forms.Label selSpeedLabel;
        private System.Windows.Forms.GroupBox trackBox;
        private System.Windows.Forms.Button closeBlockButton;
        private System.Windows.Forms.Button openBlockButton;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label selLineLabel;
        private System.Windows.Forms.Button fixTrackButton;
        private System.Windows.Forms.Button fixTrainButton;
        private System.Windows.Forms.GroupBox systemConBox;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.Button manButton;
        private System.Windows.Forms.Label sysModeLabel;
        private System.Windows.Forms.RadioButton fbRadio;
        private System.Windows.Forms.RadioButton mboButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.GroupBox notifBox;
        private System.Windows.Forms.Label notifLabel;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label updateTimeLabel;
    }
}