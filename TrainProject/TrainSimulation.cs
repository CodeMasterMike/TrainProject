﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Track_Layout_UI;
using MBO_UI;
using TrainProject.Clock;
using CTC;
using TrainControllerProject;
using TrainModelProject;

namespace TrainProject
{
    public partial class TrainSimulation : Form
    {
        int start = 0;
        CustomClock clk;
        public TrainModel trainModelWindow;
        public static Office mainOffice;
        public static TrackModelUI trackModelWindow;
        public static TrackControllerWindow trackControllerWindow;
        public static MBO MBOWindow;

        public TrainSimulation()
        {
            InitializeComponent();
            clk = new CustomClock(this);
        }

        public void beginButton_Click(object sender, EventArgs e)
        {
            start = 1;
            trackControllerWindow = new TrackControllerWindow();
            trackControllerWindow.Show();
            trackModelWindow = new TrackModelUI();
            trackModelWindow.Show();
            MBOWindow = new MBO();
            MBOWindow.Show();
            mainOffice = new Office();
            mainOffice.Show();
            trainModelWindow = new TrainModel();
        }
        public void updateTime(String displayTime)
        {
            if (start == 0) return;
            //Console.WriteLine("updating time");
            if (this.clockDisplayedText.InvokeRequired)
            {
                clockDisplayedText.Invoke(new MethodInvoker(delegate { this.clockDisplayedText.Text = displayTime; }));
            }
            //this.clockDisplayedText.Text = displayTime;
            if (trainModelWindow != null)
            {
                Invoke(new MethodInvoker(delegate { trainModelWindow.updateTime(displayTime); }));
            }
            if (mainOffice != null)
            {
                Invoke(new MethodInvoker(delegate { mainOffice.updateTime(displayTime); }));
            }
            if (MBOWindow != null)
            {
                Invoke(new MethodInvoker(delegate { MBOWindow.updateTime(displayTime); }));
            }
        }

        private void speedButton1_Click(object sender, EventArgs e)
        {
            clk.changeInterval(1000);
        }
        private void speedButton10_Click(object sender, EventArgs e)
        {
            clk.changeInterval(100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trainModelWindow = new TrainModel();
            trainModelWindow.Show();
        }

        private void TrainSimulation_Load(object sender, EventArgs e)
        {

        }
    }
}
