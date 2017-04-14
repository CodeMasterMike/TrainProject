namespace CTC
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
            this.updateTimeLabel = new System.Windows.Forms.Label();
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
            this.speedScrollBar = new System.Windows.Forms.HScrollBar();
            this.authScrollBar = new System.Windows.Forms.HScrollBar();
            this.authValueLabel = new System.Windows.Forms.Label();
            this.speedValueLabel = new System.Windows.Forms.Label();
            this.dispTrain = new System.Windows.Forms.Button();
            this.selAuthLabel = new System.Windows.Forms.Label();
            this.selSpeedLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.selDenLabel = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.updateThroughputLabel = new System.Windows.Forms.Label();
            this.updateNumTrainsLabel = new System.Windows.Forms.Label();
            this.updateLineLabel = new System.Windows.Forms.Label();
            this.updateSectionLabel = new System.Windows.Forms.Label();
            this.updateBlockStatLabel = new System.Windows.Forms.Label();
            this.updateBlockLabel = new System.Windows.Forms.Label();
            this.updateSugAuthLabel = new System.Windows.Forms.Label();
            this.updateSugSpeedLabel = new System.Windows.Forms.Label();
            this.updateTrainLabel = new System.Windows.Forms.Label();
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
            this.systemListView = new System.Windows.Forms.ListView();
            this.Block = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Trains = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Switches = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Crossings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yardTrain = new System.Windows.Forms.Button();
            this.MurphyTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.DispatcherTab.SuspendLayout();
            this.notifBox.SuspendLayout();
            this.systemConBox.SuspendLayout();
            this.trackBox.SuspendLayout();
            this.dispatchGroup.SuspendLayout();
            this.infoBox.SuspendLayout();
            this.systemBox.SuspendLayout();
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
            this.DispatcherTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
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
            // updateTimeLabel
            // 
            this.updateTimeLabel.AutoSize = true;
            this.updateTimeLabel.Location = new System.Drawing.Point(87, 111);
            this.updateTimeLabel.Name = "updateTimeLabel";
            this.updateTimeLabel.Size = new System.Drawing.Size(73, 20);
            this.updateTimeLabel.TabIndex = 5;
            this.updateTimeLabel.Text = "00:00:00";
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
            this.autoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.manButton.BackColor = System.Drawing.Color.Black;
            this.manButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manButton.ForeColor = System.Drawing.Color.White;
            this.manButton.Location = new System.Drawing.Point(6, 50);
            this.manButton.Name = "manButton";
            this.manButton.Size = new System.Drawing.Size(103, 45);
            this.manButton.TabIndex = 2;
            this.manButton.Text = "Manual";
            this.manButton.UseVisualStyleBackColor = false;
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
            this.fixTrackButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.fixTrackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixTrackButton.ForeColor = System.Drawing.Color.White;
            this.fixTrackButton.Location = new System.Drawing.Point(6, 161);
            this.fixTrackButton.Name = "fixTrackButton";
            this.fixTrackButton.Size = new System.Drawing.Size(268, 45);
            this.fixTrackButton.TabIndex = 2;
            this.fixTrackButton.Text = "Fix Track";
            this.fixTrackButton.UseVisualStyleBackColor = false;
            this.fixTrackButton.Click += new System.EventHandler(this.fixTrackButton_Click);
            // 
            // fixTrainButton
            // 
            this.fixTrainButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.fixTrainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixTrainButton.ForeColor = System.Drawing.Color.White;
            this.fixTrainButton.Location = new System.Drawing.Point(6, 212);
            this.fixTrainButton.Name = "fixTrainButton";
            this.fixTrainButton.Size = new System.Drawing.Size(268, 45);
            this.fixTrainButton.TabIndex = 2;
            this.fixTrainButton.Text = "Fix Train";
            this.fixTrainButton.UseVisualStyleBackColor = false;
            this.fixTrainButton.Click += new System.EventHandler(this.fixTrainButton_Click);
            // 
            // closeBlockButton
            // 
            this.closeBlockButton.BackColor = System.Drawing.Color.DarkRed;
            this.closeBlockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBlockButton.ForeColor = System.Drawing.Color.White;
            this.closeBlockButton.Location = new System.Drawing.Point(142, 88);
            this.closeBlockButton.Name = "closeBlockButton";
            this.closeBlockButton.Size = new System.Drawing.Size(132, 45);
            this.closeBlockButton.TabIndex = 2;
            this.closeBlockButton.Text = "Close Block";
            this.closeBlockButton.UseVisualStyleBackColor = false;
            this.closeBlockButton.Click += new System.EventHandler(this.closeBlockButton_Click);
            // 
            // openBlockButton
            // 
            this.openBlockButton.BackColor = System.Drawing.Color.SeaGreen;
            this.openBlockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openBlockButton.ForeColor = System.Drawing.Color.White;
            this.openBlockButton.Location = new System.Drawing.Point(6, 88);
            this.openBlockButton.Name = "openBlockButton";
            this.openBlockButton.Size = new System.Drawing.Size(130, 45);
            this.openBlockButton.TabIndex = 2;
            this.openBlockButton.Text = "Open Block";
            this.openBlockButton.UseVisualStyleBackColor = false;
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
            this.dispatchGroup.Controls.Add(this.speedScrollBar);
            this.dispatchGroup.Controls.Add(this.authScrollBar);
            this.dispatchGroup.Controls.Add(this.authValueLabel);
            this.dispatchGroup.Controls.Add(this.speedValueLabel);
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
            // speedScrollBar
            // 
            this.speedScrollBar.Location = new System.Drawing.Point(21, 104);
            this.speedScrollBar.Maximum = 110;
            this.speedScrollBar.Name = "speedScrollBar";
            this.speedScrollBar.Size = new System.Drawing.Size(186, 18);
            this.speedScrollBar.TabIndex = 4;
            this.speedScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.speedScrollBar_Scroll);
            // 
            // authScrollBar
            // 
            this.authScrollBar.Location = new System.Drawing.Point(21, 155);
            this.authScrollBar.Maximum = 30;
            this.authScrollBar.Name = "authScrollBar";
            this.authScrollBar.Size = new System.Drawing.Size(186, 18);
            this.authScrollBar.TabIndex = 4;
            this.authScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.authScrollBar_Scroll);
            // 
            // authValueLabel
            // 
            this.authValueLabel.AutoSize = true;
            this.authValueLabel.Location = new System.Drawing.Point(210, 153);
            this.authValueLabel.Name = "authValueLabel";
            this.authValueLabel.Size = new System.Drawing.Size(71, 20);
            this.authValueLabel.TabIndex = 3;
            this.authValueLabel.Text = "0 blocks";
            this.authValueLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // speedValueLabel
            // 
            this.speedValueLabel.AutoSize = true;
            this.speedValueLabel.Location = new System.Drawing.Point(210, 102);
            this.speedValueLabel.Name = "speedValueLabel";
            this.speedValueLabel.Size = new System.Drawing.Size(55, 20);
            this.speedValueLabel.TabIndex = 3;
            this.speedValueLabel.Text = "0 mph";
            this.speedValueLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dispTrain
            // 
            this.dispTrain.BackColor = System.Drawing.Color.DodgerBlue;
            this.dispTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispTrain.ForeColor = System.Drawing.Color.White;
            this.dispTrain.Location = new System.Drawing.Point(34, 200);
            this.dispTrain.Name = "dispTrain";
            this.dispTrain.Size = new System.Drawing.Size(254, 45);
            this.dispTrain.TabIndex = 2;
            this.dispTrain.Text = "Dispatch Train";
            this.dispTrain.UseVisualStyleBackColor = false;
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
            this.infoBox.Controls.Add(this.updateThroughputLabel);
            this.infoBox.Controls.Add(this.updateNumTrainsLabel);
            this.infoBox.Controls.Add(this.updateLineLabel);
            this.infoBox.Controls.Add(this.updateSectionLabel);
            this.infoBox.Controls.Add(this.updateBlockStatLabel);
            this.infoBox.Controls.Add(this.updateBlockLabel);
            this.infoBox.Controls.Add(this.updateSugAuthLabel);
            this.infoBox.Controls.Add(this.updateSugSpeedLabel);
            this.infoBox.Controls.Add(this.updateTrainLabel);
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
            // updateThroughputLabel
            // 
            this.updateThroughputLabel.AutoSize = true;
            this.updateThroughputLabel.Location = new System.Drawing.Point(146, 248);
            this.updateThroughputLabel.Name = "updateThroughputLabel";
            this.updateThroughputLabel.Size = new System.Drawing.Size(15, 20);
            this.updateThroughputLabel.TabIndex = 3;
            this.updateThroughputLabel.Text = "-";
            // 
            // updateNumTrainsLabel
            // 
            this.updateNumTrainsLabel.AutoSize = true;
            this.updateNumTrainsLabel.Location = new System.Drawing.Point(146, 219);
            this.updateNumTrainsLabel.Name = "updateNumTrainsLabel";
            this.updateNumTrainsLabel.Size = new System.Drawing.Size(15, 20);
            this.updateNumTrainsLabel.TabIndex = 3;
            this.updateNumTrainsLabel.Text = "-";
            // 
            // updateLineLabel
            // 
            this.updateLineLabel.AutoSize = true;
            this.updateLineLabel.Location = new System.Drawing.Point(146, 191);
            this.updateLineLabel.Name = "updateLineLabel";
            this.updateLineLabel.Size = new System.Drawing.Size(15, 20);
            this.updateLineLabel.TabIndex = 3;
            this.updateLineLabel.Text = "-";
            // 
            // updateSectionLabel
            // 
            this.updateSectionLabel.AutoSize = true;
            this.updateSectionLabel.Location = new System.Drawing.Point(146, 162);
            this.updateSectionLabel.Name = "updateSectionLabel";
            this.updateSectionLabel.Size = new System.Drawing.Size(15, 20);
            this.updateSectionLabel.TabIndex = 3;
            this.updateSectionLabel.Text = "-";
            // 
            // updateBlockStatLabel
            // 
            this.updateBlockStatLabel.AutoSize = true;
            this.updateBlockStatLabel.Location = new System.Drawing.Point(146, 133);
            this.updateBlockStatLabel.Name = "updateBlockStatLabel";
            this.updateBlockStatLabel.Size = new System.Drawing.Size(15, 20);
            this.updateBlockStatLabel.TabIndex = 3;
            this.updateBlockStatLabel.Text = "-";
            // 
            // updateBlockLabel
            // 
            this.updateBlockLabel.AutoSize = true;
            this.updateBlockLabel.Location = new System.Drawing.Point(146, 105);
            this.updateBlockLabel.Name = "updateBlockLabel";
            this.updateBlockLabel.Size = new System.Drawing.Size(15, 20);
            this.updateBlockLabel.TabIndex = 3;
            this.updateBlockLabel.Text = "-";
            // 
            // updateSugAuthLabel
            // 
            this.updateSugAuthLabel.AutoSize = true;
            this.updateSugAuthLabel.Location = new System.Drawing.Point(146, 78);
            this.updateSugAuthLabel.Name = "updateSugAuthLabel";
            this.updateSugAuthLabel.Size = new System.Drawing.Size(15, 20);
            this.updateSugAuthLabel.TabIndex = 3;
            this.updateSugAuthLabel.Text = "-";
            // 
            // updateSugSpeedLabel
            // 
            this.updateSugSpeedLabel.AutoSize = true;
            this.updateSugSpeedLabel.Location = new System.Drawing.Point(146, 50);
            this.updateSugSpeedLabel.Name = "updateSugSpeedLabel";
            this.updateSugSpeedLabel.Size = new System.Drawing.Size(15, 20);
            this.updateSugSpeedLabel.TabIndex = 3;
            this.updateSugSpeedLabel.Text = "-";
            // 
            // updateTrainLabel
            // 
            this.updateTrainLabel.AutoSize = true;
            this.updateTrainLabel.Location = new System.Drawing.Point(146, 23);
            this.updateTrainLabel.Name = "updateTrainLabel";
            this.updateTrainLabel.Size = new System.Drawing.Size(15, 20);
            this.updateTrainLabel.TabIndex = 3;
            this.updateTrainLabel.Text = "-";
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
            this.systemBox.Controls.Add(this.systemListView);
            this.systemBox.Controls.Add(this.yardTrain);
            this.systemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemBox.Location = new System.Drawing.Point(3, 295);
            this.systemBox.Name = "systemBox";
            this.systemBox.Size = new System.Drawing.Size(1325, 354);
            this.systemBox.TabIndex = 0;
            this.systemBox.TabStop = false;
            this.systemBox.Text = "System Overview";
            this.systemBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // systemListView
            // 
            this.systemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Block,
            this.Status,
            this.Trains,
            this.Switches,
            this.Crossings});
            this.systemListView.Location = new System.Drawing.Point(69, 26);
            this.systemListView.Name = "systemListView";
            this.systemListView.Size = new System.Drawing.Size(1229, 320);
            this.systemListView.TabIndex = 2;
            this.systemListView.UseCompatibleStateImageBehavior = false;
            // 
            // Block
            // 
            this.Block.Text = "Block Number";
            this.Block.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Block Status";
            this.Status.Width = 120;
            // 
            // Trains
            // 
            this.Trains.Text = "Occupancy";
            this.Trains.Width = 120;
            // 
            // Switches
            // 
            this.Switches.Text = "Switch State";
            this.Switches.Width = 120;
            // 
            // Crossings
            // 
            this.Crossings.Text = "Crossing State";
            this.Crossings.Width = 120;
            // 
            // yardTrain
            // 
            this.yardTrain.Location = new System.Drawing.Point(13, 99);
            this.yardTrain.Name = "yardTrain";
            this.yardTrain.Size = new System.Drawing.Size(54, 44);
            this.yardTrain.TabIndex = 0;
            this.yardTrain.Text = "yard";
            this.yardTrain.UseVisualStyleBackColor = true;
            this.yardTrain.Click += new System.EventHandler(this.yardTrain_Click);
            // 
            // MurphyTab
            // 
            this.MurphyTab.Location = new System.Drawing.Point(4, 25);
            this.MurphyTab.Name = "MurphyTab";
            this.MurphyTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MurphyTab.Size = new System.Drawing.Size(1323, 647);
            this.MurphyTab.TabIndex = 1;
            this.MurphyTab.Text = "Murphy";
            this.MurphyTab.UseVisualStyleBackColor = true;
            // 
            // Office
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1346, 689);
            this.Controls.Add(this.tabControl1);
            this.Name = "Office";
            this.Text = "Office";
            this.Load += new System.EventHandler(this.Office_Load);
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
            this.systemBox.ResumeLayout(false);
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
        private System.Windows.Forms.Label authValueLabel;
        private System.Windows.Forms.Label speedValueLabel;
        private System.Windows.Forms.Label updateTimeLabel;
        private System.Windows.Forms.Button yardTrain;
        private System.Windows.Forms.HScrollBar speedScrollBar;
        private System.Windows.Forms.HScrollBar authScrollBar;
        private System.Windows.Forms.ListView systemListView;
        private System.Windows.Forms.Label updateThroughputLabel;
        private System.Windows.Forms.Label updateNumTrainsLabel;
        private System.Windows.Forms.Label updateLineLabel;
        private System.Windows.Forms.Label updateSectionLabel;
        private System.Windows.Forms.Label updateBlockStatLabel;
        private System.Windows.Forms.Label updateBlockLabel;
        private System.Windows.Forms.Label updateSugAuthLabel;
        private System.Windows.Forms.Label updateSugSpeedLabel;
        private System.Windows.Forms.Label updateTrainLabel;
        private System.Windows.Forms.ColumnHeader Block;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Trains;
        private System.Windows.Forms.ColumnHeader Switches;
        private System.Windows.Forms.ColumnHeader Crossings;
    }
}