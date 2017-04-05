using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProject;
using TrainModelProject;

namespace CTC
{
    public partial class Office : Form
    {
        TrainModel tm_window;
        int trainId;
        int selTrainId;
        bool trainSelected;
        double sugSpeed;
        int sugAuth;
        int trainCounter = 0;
        public static TrackControllerModule module;

        public Office()
        {
            InitializeComponent();
            module = new TrackControllerModule();
        }

        public void updateTime(String time)
        {
            updateTimeLabel.Text = time;
            if (tm_window != null)
            {
                Invoke(new MethodInvoker(delegate { tm_window.updateTime(time); }));
            }
        }

        public void dispatchNewTrain()
        {
            trainCounter++;
            Train newTrain = new Train(trainCounter, sugSpeed, sugAuth);
            module.dispatchNewTrain(newTrain);
            tm_window = new TrainModel();
            tm_window.Show();
        }

        public void dispatchOldTrain(int trainId)
        {
            module.dispatchNewTrain(trainId, sugSpeed, sugAuth);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void infoBox_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dispTrain_Click(object sender, EventArgs e)
        {
           if (trainSelected)
            {
                dispatchOldTrain(selTrainId);
            }
           else
            {
                dispatchNewTrain();
            }
        }

        private void dispatchGroup_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openBlockButton_Click(object sender, EventArgs e)
        {

        }

        private void closeBlockButton_Click(object sender, EventArgs e)
        {

        }

        private void fixTrackButton_Click(object sender, EventArgs e)
        {

        }

        private void fixTrainButton_Click(object sender, EventArgs e)
        {

        }

        private void manButton_Click(object sender, EventArgs e)
        {

        }

        private void autoButton_Click(object sender, EventArgs e)
        {

        }

        private void fbRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mboButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void notifLabel_Click(object sender, EventArgs e)
        {

        }

        private void yardTrain_Click(object sender, EventArgs e)
        {
            trainSelected = false;
        }

        private void trackTrain_Click(object sender, EventArgs e)
        {
            trainSelected = true;
            trainId = 1;
        }

        private void speedScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            sugSpeed = speedScrollBar.Value;
            speedValueLabel.Text = sugSpeed + " mph";
        }

        private void authScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            sugAuth = authScrollBar.Value;
            authValueLabel.Text = sugAuth + " blocks";
        }
    }
}
