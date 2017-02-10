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
using CTC;
using MBOForm;


namespace Train_Project
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void openTrackModel_Click(object sender, EventArgs e)
        {
            TrackModelUI trackModelWindow = new TrackModelUI();
            trackModelWindow.Show();
        }

        private void openMBO_Click(object sender, EventArgs e)
        {
            MBO mboWindow = new MBO();
            mboWindow.Show();
        }

        private void openTrackController_Click(object sender, EventArgs e)
        {
            TrackControllerWindow trackControllerWindow = new TrackControllerWindow();
            trackControllerWindow.Show();
        }

        private void openCTC_Click(object sender, EventArgs e)
        {
            CentralTrainControl ctcWindow = new CentralTrainControl();
            ctcWindow.Show();

        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
