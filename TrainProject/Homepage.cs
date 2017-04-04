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


using TrainProject;

namespace TrainProject
{
    public partial class Homepage : Form
    {
        private TrainController trainControllerWindow;
        private TrainModel trainModelWindow;

        public Homepage()
        {
            InitializeComponent();
            //CustomClock clk = new CustomClock(this);
        }

        private void openTrackModel_Click(object sender, EventArgs e)
        {
            TrackModelUI trackModelWindow = new TrackModelUI();
            trackModelWindow.Show();
        }

        private void openTrackController_Click(object sender, EventArgs e)
        {
            TrackControllerWindow trackControllerWindow = new TrackControllerWindow();
            trackControllerWindow.Show();
            TrackControllerTest test = new TrackControllerTest();
            test.run();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void openCTC_Click(object sender, EventArgs e)
        {
            Office ctcWindow = new Office();
            ctcWindow.Show();
        }

        private void clockDisplayedText_Click(object sender, EventArgs e)
        {

        }

        public void updateTime(String displayTime)
        {
            //Console.WriteLine("updating time");
            if (this.clockDisplayedText.InvokeRequired)
            {
                clockDisplayedText.Invoke(new MethodInvoker(delegate { this.clockDisplayedText.Text = displayTime; }));
            }
            //this.clockDisplayedText.Text = displayTime;
            if (trainControllerWindow != null)
            {
                //trainControllerWindow.updateTime(displayTime);
                Invoke(new MethodInvoker(delegate { trainControllerWindow.updateTime(displayTime); }));
            }
            if (trainModelWindow != null)
            {
                Invoke(new MethodInvoker(delegate { trainModelWindow.updateTime(displayTime); }));
            }
        }

        private void openTrainController_Click(object sender, EventArgs e)
        {
            //trainControllerWindow = new TrainController();
            //trainControllerWindow.Show();
        }

        private void openTrainModel_Click(object sender, EventArgs e)
        {
            trainModelWindow = new TrainModel();
            trainModelWindow.Show();
        }
    }
}
