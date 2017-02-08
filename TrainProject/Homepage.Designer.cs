namespace Train_Project
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
            this.openCTC = new System.Windows.Forms.Button();
            this.openTrackController = new System.Windows.Forms.Button();
            this.openTrackModel = new System.Windows.Forms.Button();
            this.openTrainModel = new System.Windows.Forms.Button();
            this.openTrainController = new System.Windows.Forms.Button();
            this.openMBO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openCTC
            // 
            this.openCTC.Location = new System.Drawing.Point(328, 52);
            this.openCTC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openCTC.Name = "openCTC";
            this.openCTC.Size = new System.Drawing.Size(121, 28);
            this.openCTC.TabIndex = 0;
            this.openCTC.Text = "CTC";
            this.openCTC.UseVisualStyleBackColor = true;
            this.openCTC.Click += new System.EventHandler(this.openCTC_Click);
            // 
            // openTrackController
            // 
            this.openTrackController.Location = new System.Drawing.Point(328, 89);
            this.openTrackController.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openTrackController.Name = "openTrackController";
            this.openTrackController.Size = new System.Drawing.Size(121, 28);
            this.openTrackController.TabIndex = 1;
            this.openTrackController.Text = "Track Controller";
            this.openTrackController.UseVisualStyleBackColor = true;
            this.openTrackController.Click += new System.EventHandler(this.openTrackController_Click);
            // 
            // openTrackModel
            // 
            this.openTrackModel.Location = new System.Drawing.Point(328, 124);
            this.openTrackModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openTrackModel.Name = "openTrackModel";
            this.openTrackModel.Size = new System.Drawing.Size(121, 28);
            this.openTrackModel.TabIndex = 2;
            this.openTrackModel.Text = "Track Model";
            this.openTrackModel.UseVisualStyleBackColor = true;
            this.openTrackModel.Click += new System.EventHandler(this.openTrackModel_Click);
            // 
            // openTrainModel
            // 
            this.openTrainModel.Location = new System.Drawing.Point(328, 162);
            this.openTrainModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openTrainModel.Name = "openTrainModel";
            this.openTrainModel.Size = new System.Drawing.Size(121, 28);
            this.openTrainModel.TabIndex = 3;
            this.openTrainModel.Text = "Train Model";
            this.openTrainModel.UseVisualStyleBackColor = true;
            // 
            // openTrainController
            // 
            this.openTrainController.Location = new System.Drawing.Point(328, 198);
            this.openTrainController.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openTrainController.Name = "openTrainController";
            this.openTrainController.Size = new System.Drawing.Size(121, 28);
            this.openTrainController.TabIndex = 4;
            this.openTrainController.Text = "Train Controller";
            this.openTrainController.UseVisualStyleBackColor = true;
            // 
            // openMBO
            // 
            this.openMBO.Location = new System.Drawing.Point(328, 235);
            this.openMBO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openMBO.Name = "openMBO";
            this.openMBO.Size = new System.Drawing.Size(121, 28);
            this.openMBO.TabIndex = 5;
            this.openMBO.Text = "MBO";
            this.openMBO.UseVisualStyleBackColor = true;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 356);
            this.Controls.Add(this.openMBO);
            this.Controls.Add(this.openTrainController);
            this.Controls.Add(this.openTrainModel);
            this.Controls.Add(this.openTrackModel);
            this.Controls.Add(this.openTrackController);
            this.Controls.Add(this.openCTC);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Homepage";
            this.Text = "Main Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openCTC;
        private System.Windows.Forms.Button openTrackController;
        private System.Windows.Forms.Button openTrackModel;
        private System.Windows.Forms.Button openTrainModel;
        private System.Windows.Forms.Button openTrainController;
        private System.Windows.Forms.Button openMBO;
    }
}

