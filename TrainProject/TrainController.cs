using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainControllerProject
{
    public partial class TrainController : Form
    {
        //initialize variables
        private int setSpeed = 0;
        private int setTemp = 0;
        int testMode = 0; //test mode off = 0 test mode on = 1
        
        //initialize labels and controls

        //methods
        public TrainController()
        {
            InitializeComponent();

            testMode = 0;
            blockTestTextBox.Enabled = false;
            speedTestTextBox.Enabled = false;
            tempTestTextBox.Enabled = false;
            ctcSpeedTestTextBox.Enabled = false;
            ctcAuthorityTestTextBox.Enabled = false;

        }
        //every time interval update all of the displays and internal variables
        public void updateTime(String time)
        {
            if (this.timeLabel.InvokeRequired)
            {
                timeLabel.Invoke(new MethodInvoker(delegate { timeLabel.Text = time; }));
            }
            string [] x = time.Split(':');
            int seconds = Convert.ToInt32(x[1]);
            //use this if statement to update displays and internal variables every 2 seconds
            if (seconds % 2 == 0)
            { 
                if (this.trainIDLabel.InvokeRequired)
                {
                    trainIDLabel.Invoke(new MethodInvoker(delegate { trainIDLabel.Text = Convert.ToString(seconds); }));
                }
            }
        }
        //set control functionality for set speed trackbar
        private void setSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            setSpeedLabel.Text = Convert.ToString(setSpeedTrackBar.Value);
            setSpeed = setSpeedTrackBar.Value;
        }
        //set control functionality for set temp trackbar
        private void setTempTrackBar_Scroll(object sender, EventArgs e)
        {
            setTempLabel.Text = Convert.ToString(setTempTrackBar.Value);
            setTemp = setTempTrackBar.Value;
        }
        //activate test mode
        private void testModeOn_Click(object sender, EventArgs e)
        {
            testMode = 1;
            blockTestTextBox.Enabled = true;
            speedTestTextBox.Enabled = true;
            tempTestTextBox.Enabled = true;
            ctcSpeedTestTextBox.Enabled = true;
            ctcAuthorityTestTextBox.Enabled = true;
        }
        //de-activate test mode
        private void testModeOff_Click(object sender, EventArgs e)
        {
            testMode = 0;
            blockTestTextBox.Enabled = false;
            speedTestTextBox.Enabled = false;
            tempTestTextBox.Enabled = false;
            ctcSpeedTestTextBox.Enabled = false;
            ctcAuthorityTestTextBox.Enabled = false;
        }

        private void automaticRadioButton_Click(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = false;
        }

        private void manualRadioButton_Click(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = true;
        }

        private decimal calculate_power(decimal currSpeed, decimal setSpeed)
        {

            return 0;
        }





        //*******************************************************************************//
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Emergency_Stop_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void Driver_Tab_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void emergencyButton_Click(object sender, EventArgs e)
        {

        }

        private void serviceButton_Click(object sender, EventArgs e)
        {

        }

        private void testModeOff_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
