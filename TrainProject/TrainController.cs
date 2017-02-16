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
        private decimal setSpeed = 0;
        private int setTemp = 0;
        int testMode = 0; //test mode off = 0 test mode on = 1
        int mode = 0; //manual = 0 automatic  = 1
        decimal Kp = 0;
        decimal Ki = 0;
        decimal error = 0;
        decimal ek = 0;
        decimal mass = 0;
        decimal u = 0;
        decimal uk = 0;
        decimal currSpeed = 0;
        decimal power = 0;
        decimal acceleration = 0;
        decimal currSpeedkmh = 0;
        decimal setSpeedkmh = 0;
      
        
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
            timeLabel.Text = "-";

        }
        //every time interval update all of the displays and internal variables
        public void updateTime(String time)
        {
            /* if (this.timeLabel.InvokeRequired)
             {
                 timeLabel.Invoke(new MethodInvoker(delegate { timeLabel.Text = time; }));
             }*/
            timeLabel.Text = time;
            
        }
        //set control functionality for set speed trackbar
        private void setSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            setSpeedLabel.Text = Convert.ToString(setSpeedTrackBar.Value) + "MPH";
            setSpeed = setSpeedTrackBar.Value;
        }
        //set control functionality for set temp trackbar
        private void setTempTrackBar_Scroll(object sender, EventArgs e)
        {
            setTempLabel.Text = Convert.ToString(setTempTrackBar.Value) + "F";
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
            error = currSpeed - setSpeed;
            u = uk + (1/2)*(error + ek);
            ek = error;
            power = Kp * error + Ki * u;
            if (power > 120000)
            {
                u = uk;
                power = 120000;
            }
            else uk = u;
            acceleration = power / (currSpeed * mass);
            currSpeed = currSpeed + acceleration;
            return 0;
        }

        private void updateTimeLabel(String time)
        {
            timeLabel.Text = time;
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

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
