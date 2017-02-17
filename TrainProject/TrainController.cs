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
        private decimal driverSetSpeed = 0;
        private decimal ctcSetSpeed = 0;
        private decimal setSpeed = 0;
        private decimal setTemp = 0;
        private decimal temp = 0;
        int testMode = 0; //test mode off = 0 test mode on = 1
        int mode = 0; //manual = 0 automatic  = 1
        decimal Kp = 0;//100000;
        decimal Ki = 0;//5000;
        decimal error = 0;
        decimal ek = 0;
        decimal mass = 37103;
        decimal u = 0;
        decimal uk = 0;
        decimal currSpeed = 0;
        decimal power = 0;
        decimal acceleration = 0;
        decimal currSpeedkmh = 0;
        decimal setSpeedkmh = 0;
        decimal force = 0;
        decimal serviceBreak = Convert.ToDecimal(1.2);
        bool simulate = false;
      
        
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
            updateDoors();
            if (testMode == 0)
            {
                //ctcSetSpeed = currSpeedkmh;
                // currSpeedkmh = 0;
            }
            else
            {
                
                
                if (!simulate)
                {
                    if (speedTestTextBox.Text != "") currSpeedkmh = Convert.ToDecimal(speedTestTextBox.Text);
                    if (ctcSpeedTestTextBox.Text != "") ctcSetSpeed = Convert.ToDecimal(ctcSpeedTestTextBox.Text);
                    if (tempTestTextBox.Text != "") temp = Convert.ToDecimal(tempTestTextBox.Text);
                    u = 0;
                    uk = 0;
                    ek = 0;
                }
                else currSpeedkmh = currSpeed * 3600 / 1000;
                //trainTempLabel.Text = Convert.ToString(setSpeed);
                driverSetSpeed = (setSpeedTrackBar.Value) / Convert.ToDecimal(0.44704);
                if (mode == 0)
                {
                    setSpeedkmh = driverSetSpeed;
                }
                else setSpeedkmh = ctcSetSpeed;
                if (setSpeedkmh > 80) setSpeedkmh = 80;
                setTemp = setTempTrackBar.Value;
                setSpeed = setSpeedkmh * 1000 / 3600;
                currSpeed = currSpeedkmh * 1000 / 3600;
                if ((currSpeedkmh < (setSpeedkmh - 1 / 2)) && simulate)
                {
                    calculate_power();
                }
                else power = 0;
                if ((currSpeedkmh > setSpeedkmh + 1/2) && simulate) sBreak();
                if ((temp < setTemp) && simulate) raiseTemp();
                if ((temp > setTemp) && simulate) lowerTemp();
                if ((temp == setTemp) && simulate)
                {
                    AC_OFF.Checked = true;
                    Heater_Off.Checked = true;
                }
                //trainPowerLabel.Text = String.Format("{0:F2}",Convert.ToString(power / 1000));
                trainSpeedLabel.Text = (currSpeed * 3600 / 1000 * Convert.ToDecimal(0.44704)).ToString("#.###") + "MPH";
                trainPowerLabel.Text = (power / 1000).ToString("#.###") + "kW";
                ctcSpeedLabel.Text = ((ctcSetSpeed) * Convert.ToDecimal(0.44704)).ToString("#.###") + "MPH";
                trainTempLabel.Text = (temp.ToString()) + "F";
                //speedTestTextBox.Text = Convert.ToString(currSpeed * 3600 / 1000);


            }


        }
        //set control functionality for set speed trackbar
        private void setSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            setSpeedLabel.Text = Convert.ToString(setSpeedTrackBar.Value) + "MPH";
            driverSetSpeed = setSpeedTrackBar.Value;
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
            blockTestTextBox.Text = "0";
            speedTestTextBox.Enabled = true;
            //speedTestTextBox.Text = Convert.ToString(currSpeedkmh);
            speedTestTextBox.Text = "0";
            tempTestTextBox.Enabled = true;
            //tempTestTextBox.Text = Convert.ToString(temp);
            tempTestTextBox.Text = "0";
            ctcSpeedTestTextBox.Enabled = true;
            //ctcSpeedTestTextBox.Text = Convert.ToString(currSpeedkmh);
            ctcSpeedTestTextBox.Text = "0";
            ctcAuthorityTestTextBox.Enabled = true;
            ctcAuthorityTestTextBox.Text = "0";
            simulateButton.Enabled = true;
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
            simulateButton.Enabled = false;
        }

        private void automaticRadioButton_Click(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = false;
        }

        private void manualRadioButton_Click(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = true;
        }

        private decimal calculate_power()
        {
            serviceButton.Checked = false;
            error = setSpeed - currSpeed;
            u = uk + (1/2)*(error + ek);
            ek = error;
            power = Kp * error + Ki * u;
            if (power > 120000)
            {
                u = uk;
                power = 120000;
            }
            else uk = u;
            if (currSpeed != 0)
            {
                acceleration = power / (currSpeed * mass);
            }
            else acceleration = power / (mass);
            currSpeed = currSpeed + acceleration;

            return 0;
        }

        private void updateTimeLabel(String time)
        {
            timeLabel.Text = time;
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            if (simulate) simulate = false;
            else
            {
                simulate = true;
            }
        }

        private void sBreak()
        {
            serviceButton.Checked = true;
            currSpeed = currSpeed - serviceBreak;
            power = 0;
        }

        private void raiseTemp()
        {
            Heater_On.Checked = true;
            AC_OFF.Checked = true;
            temp = temp + 1;
        }

        private void lowerTemp()
        {
            Heater_Off.Checked = true;
            AC_ON.Checked = true;
            temp = temp - 1;
        }

        private void updateDoors()
        {
            if (Left_Open.Checked) leftDoorStatusLabel.Text = "Open";
            else leftDoorStatusLabel.Text = "Closed";
            if (Right_Open.Checked) rightDoorStatusLabel.Text = "Open";
            else rightDoorStatusLabel.Text = "Closed";
            if (Lights_On.Checked) lightStatusLabel.Text = "On";
            else lightStatusLabel.Text = "Off";
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

        private void setParametersButton_Click(object sender, EventArgs e)
        {
            if(KpTextBox.Text != "") Kp = Convert.ToDecimal(KpTextBox.Text);
            if(KpTextBox.Text != "") Ki = Convert.ToDecimal(KiTextBox.Text);
        }

        private void Heater_On_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Left_Open_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void blockSpeedLimitLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
