namespace TrainProject
{
    partial class Homepage
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
            this.openCTC = new System.Windows.Forms.Button();
            this.openTrackController = new System.Windows.Forms.Button();
            this.openTrackModel = new System.Windows.Forms.Button();
            this.openTrainModel = new System.Windows.Forms.Button();
            this.openTrainController = new System.Windows.Forms.Button();
            this.openMBO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clockDisplayedText = new System.Windows.Forms.Label();
            this.radioSpeed1x = new System.Windows.Forms.RadioButton();
            this.radioSpeed10x = new System.Windows.Forms.RadioButton();
            this.setTimeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // openCTC
            // 
            this.openCTC.Location = new System.Drawing.Point(172, 71);
            this.openCTC.Margin = new System.Windows.Forms.Padding(4);
            this.openCTC.Name = "openCTC";
            this.openCTC.Size = new System.Drawing.Size(188, 37);
            this.openCTC.TabIndex = 0;
            this.openCTC.Text = "CTC";
            this.openCTC.UseVisualStyleBackColor = true;
            this.openCTC.Click += new System.EventHandler(this.openCTC_Click);
            // 
            // openTrackController
            // 
            this.openTrackController.Location = new System.Drawing.Point(172, 119);
            this.openTrackController.Margin = new System.Windows.Forms.Padding(4);
            this.openTrackController.Name = "openTrackController";
            this.openTrackController.Size = new System.Drawing.Size(188, 37);
            this.openTrackController.TabIndex = 1;
            this.openTrackController.Text = "Track Controller";
            this.openTrackController.UseVisualStyleBackColor = true;
            this.openTrackController.Click += new System.EventHandler(this.openTrackController_Click);
            // 
            // openTrackModel
            // 
            this.openTrackModel.Location = new System.Drawing.Point(172, 163);
            this.openTrackModel.Margin = new System.Windows.Forms.Padding(4);
            this.openTrackModel.Name = "openTrackModel";
            this.openTrackModel.Size = new System.Drawing.Size(188, 37);
            this.openTrackModel.TabIndex = 2;
            this.openTrackModel.Text = "Track Model";
            this.openTrackModel.UseVisualStyleBackColor = true;
            this.openTrackModel.Click += new System.EventHandler(this.openTrackModel_Click);
            // 
            // openTrainModel
            // 
            this.openTrainModel.Location = new System.Drawing.Point(172, 212);
            this.openTrainModel.Margin = new System.Windows.Forms.Padding(4);
            this.openTrainModel.Name = "openTrainModel";
            this.openTrainModel.Size = new System.Drawing.Size(188, 37);
            this.openTrainModel.TabIndex = 3;
            this.openTrainModel.Text = "Train Model";
            this.openTrainModel.UseVisualStyleBackColor = true;
            // 
            // openTrainController
            // 
            this.openTrainController.Location = new System.Drawing.Point(172, 258);
            this.openTrainController.Margin = new System.Windows.Forms.Padding(4);
            this.openTrainController.Name = "openTrainController";
            this.openTrainController.Size = new System.Drawing.Size(188, 37);
            this.openTrainController.TabIndex = 4;
            this.openTrainController.Text = "Train Controller";
            this.openTrainController.UseVisualStyleBackColor = true;
            this.openTrainController.Click += new System.EventHandler(this.openTrainController_Click);
            // 
            // openMBO
            // 
            this.openMBO.Location = new System.Drawing.Point(172, 304);
            this.openMBO.Margin = new System.Windows.Forms.Padding(4);
            this.openMBO.Name = "openMBO";
            this.openMBO.Size = new System.Drawing.Size(188, 37);
            this.openMBO.TabIndex = 5;
            this.openMBO.Text = "MBO";
            this.openMBO.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "System Clock:";
            // 
            // clockDisplayedText
            // 
            this.clockDisplayedText.AutoSize = true;
            this.clockDisplayedText.Location = new System.Drawing.Point(518, 167);
            this.clockDisplayedText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clockDisplayedText.Name = "clockDisplayedText";
            this.clockDisplayedText.Size = new System.Drawing.Size(134, 25);
            this.clockDisplayedText.TabIndex = 7;
            this.clockDisplayedText.Text = "00:00:00 AM";
            this.clockDisplayedText.Click += new System.EventHandler(this.clockDisplayedText_Click);
            // 
            // radioSpeed1x
            // 
            this.radioSpeed1x.AutoSize = true;
            this.radioSpeed1x.Location = new System.Drawing.Point(668, 127);
            this.radioSpeed1x.Margin = new System.Windows.Forms.Padding(4);
            this.radioSpeed1x.Name = "radioSpeed1x";
            this.radioSpeed1x.Size = new System.Drawing.Size(134, 29);
            this.radioSpeed1x.TabIndex = 8;
            this.radioSpeed1x.TabStop = true;
            this.radioSpeed1x.Text = "1x Speed";
            this.radioSpeed1x.UseVisualStyleBackColor = true;
            // 
            // radioSpeed10x
            // 
            this.radioSpeed10x.AutoSize = true;
            this.radioSpeed10x.Location = new System.Drawing.Point(668, 162);
            this.radioSpeed10x.Margin = new System.Windows.Forms.Padding(4);
            this.radioSpeed10x.Name = "radioSpeed10x";
            this.radioSpeed10x.Size = new System.Drawing.Size(146, 29);
            this.radioSpeed10x.TabIndex = 9;
            this.radioSpeed10x.TabStop = true;
            this.radioSpeed10x.Text = "10x Speed";
            this.radioSpeed10x.UseVisualStyleBackColor = true;
            // 
            // setTimeButton
            // 
            this.setTimeButton.Location = new System.Drawing.Point(522, 212);
            this.setTimeButton.Margin = new System.Windows.Forms.Padding(4);
            this.setTimeButton.Name = "setTimeButton";
            this.setTimeButton.Size = new System.Drawing.Size(250, 37);
            this.setTimeButton.TabIndex = 10;
            this.setTimeButton.Text = "Set Time Manually";
            this.setTimeButton.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 556);
            this.Controls.Add(this.setTimeButton);
            this.Controls.Add(this.radioSpeed10x);
            this.Controls.Add(this.radioSpeed1x);
            this.Controls.Add(this.clockDisplayedText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openMBO);
            this.Controls.Add(this.openTrainController);
            this.Controls.Add(this.openTrainModel);
            this.Controls.Add(this.openTrackModel);
            this.Controls.Add(this.openTrackController);
            this.Controls.Add(this.openCTC);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Homepage";
            this.Text = "Main Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openCTC;
        private System.Windows.Forms.Button openTrackController;
        private System.Windows.Forms.Button openTrackModel;
        private System.Windows.Forms.Button openTrainModel;
        private System.Windows.Forms.Button openTrainController;
        private System.Windows.Forms.Button openMBO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label clockDisplayedText;
        private System.Windows.Forms.RadioButton radioSpeed1x;
        private System.Windows.Forms.RadioButton radioSpeed10x;
        private System.Windows.Forms.Button setTimeButton;
        private System.Windows.Forms.Timer timer1;
    }
}

