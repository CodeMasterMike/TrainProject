namespace TrainProject
{
    partial class TrainSimulation
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
            this.beginButton = new System.Windows.Forms.Button();
            this.clockLabel = new System.Windows.Forms.Label();
            this.clockDisplayedText = new System.Windows.Forms.Label();
            this.speedButton1 = new System.Windows.Forms.RadioButton();
            this.speedButton10 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // beginButton
            // 
            this.beginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginButton.Location = new System.Drawing.Point(42, 30);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(509, 145);
            this.beginButton.TabIndex = 0;
            this.beginButton.Text = "Begin Train System";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockLabel.Location = new System.Drawing.Point(131, 189);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(144, 46);
            this.clockLabel.TabIndex = 1;
            this.clockLabel.Text = "Clock :";
            // 
            // clockDisplayedText
            // 
            this.clockDisplayedText.AutoSize = true;
            this.clockDisplayedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockDisplayedText.Location = new System.Drawing.Point(281, 189);
            this.clockDisplayedText.Name = "clockDisplayedText";
            this.clockDisplayedText.Size = new System.Drawing.Size(174, 46);
            this.clockDisplayedText.TabIndex = 2;
            this.clockDisplayedText.Text = "00:00:00";
            // 
            // speedButton1
            // 
            this.speedButton1.AutoSize = true;
            this.speedButton1.Checked = true;
            this.speedButton1.Location = new System.Drawing.Point(38, 18);
            this.speedButton1.Name = "speedButton1";
            this.speedButton1.Size = new System.Drawing.Size(137, 29);
            this.speedButton1.TabIndex = 4;
            this.speedButton1.TabStop = true;
            this.speedButton1.Text = "1X Speed";
            this.speedButton1.UseVisualStyleBackColor = true;
            this.speedButton1.Click += new System.EventHandler(this.speedButton1_Click);
            // 
            // speedButton10
            // 
            this.speedButton10.AutoSize = true;
            this.speedButton10.Location = new System.Drawing.Point(38, 53);
            this.speedButton10.Name = "speedButton10";
            this.speedButton10.Size = new System.Drawing.Size(149, 29);
            this.speedButton10.TabIndex = 5;
            this.speedButton10.Text = "10X Speed";
            this.speedButton10.UseVisualStyleBackColor = true;
            this.speedButton10.Click += new System.EventHandler(this.speedButton10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.speedButton10);
            this.groupBox1.Controls.Add(this.speedButton1);
            this.groupBox1.Location = new System.Drawing.Point(174, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 75);
            this.button1.TabIndex = 7;
            this.button1.Text = "openTM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TrainSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clockDisplayedText);
            this.Controls.Add(this.clockLabel);
            this.Controls.Add(this.beginButton);
            this.Name = "TrainSimulation";
            this.Text = "TrainSimulation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Label clockDisplayedText;
        private System.Windows.Forms.RadioButton speedButton1;
        private System.Windows.Forms.RadioButton speedButton10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}