using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Track_Layout_UI;
using TrackController;
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
        public TrainSimulation()
        {
            InitializeComponent();
            clk = new CustomClock(this);
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            start = 1;
            TrackControllerWindow trackControllerWindow = new TrackControllerWindow();
            trackControllerWindow.Show();
            TrackModelUI trackModelWindow = new TrackModelUI();
            trackModelWindow.Show();
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
        }

        private void speedButton1_Click(object sender, EventArgs e)
        {
            clk.changeInterval(1000);
        }
        private void speedButton10_Click(object sender, EventArgs e)
        {
            clk.changeInterval(100);
        }
    }
}
