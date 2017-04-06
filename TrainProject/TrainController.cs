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
using TrainProject.HelperObjects;
using System.IO;

namespace TrainControllerProject
{
    public partial class TrainController : Form
    {
        //initialize variables
        private double driverSetSpeed = 0;
        private double ctcSetSpeed = 0;
        private double setSpeed = 0;
        private double setTemp = 70;
        private double temp = 70;
        private double distanceToStop = 1000;
        private double minStopDistance = 1000;
        private SmallBlock[] blocks;
        private BlockTracker blockTracker;
        int testMode = 0; //test mode off = 0 test mode on = 1
        int mode = 1; //manual = 0 automatic  = 1
        int currentBlockID;
        int speedLimit;
        int direction = 0;
        int authority = 0;
        int thermostat = 0; // 0 = both off, 1 = AC, 2 = Heater
        double distanceLeft = 0;
        double Kp = 0;//100000;
        double Ki = 0;//5000;
        double error = 0;
        double ek = 0;
        double mass = 37103;
        double u = 0;
        double uk = 0;
        double currSpeed = 0;
        double power = 80000;
        double acceleration = 0;
        double currSpeedms = 0;
        double setSpeedms = 0;
        double force = 0;
        double serviceBreak = 1.2;
        bool serviceOverride = false;
        bool forceStop = false;
        Block currentBlock;
        Block nextBlock;
        
        bool simulate = false;
        PowerController powerController;
        TrainModel TM;

      
        
        //initialize labels and controls

        //methods
        public TrainController(TrainModel t)
        {
            
            InitializeComponent();
            TM = t;
            
            blockTestTextBox.Enabled = false;
            speedTestTextBox.Enabled = false;
            tempTestTextBox.Enabled = false;
            ctcSpeedTestTextBox.Enabled = false;
            ctcAuthorityTestTextBox.Enabled = false;
            timeLabel.Text = "-";
            powerController = new PowerController(mass, 120000);

            //begin in automatic mode
            testMode = 0;
            setSpeedTrackBar.Enabled = false;
            Left_Closed.Enabled = false;
            Left_Open.Enabled = false;
            serviceButton.Enabled = false;


        }
        //every time interval update all of the displays and internal variables, set calculations for real time
        public void updateTime(String time)
        {
            setTimeLabel(time);
            if (blocks != null)
            {
                speedLimit = currentBlock.speedLimit;
            }
            if (testMode == 0) {
                //figure out setSpeed;
                if (mode == 0) setSpeed = driverSetSpeed;
                else setSpeed = ctcSetSpeed;
                setSpeedms = setSpeed * 0.44704;
            }
            //considerAuthority(); 
            //considerStations();
            if ((currSpeed <= setSpeed) && !forceStop)
            {
                sBreakOFF();
                power = powerController.getPower(currSpeedms, setSpeedms);
            }
            else
            {
                sBreakON();
                power = 0;
            }
            setThermostat();
            TM.updatePower(power);
            TM.updateThermostat(thermostat);

            //update the GUI
            trainSpeedLabel.Text = (currSpeedms).ToString("#.###") + "MPH";
            trainPowerLabel.Text = (power / 1000).ToString("#.###") + "kW";
            ctcSpeedLabel.Text = (ctcSetSpeed).ToString("#.###") + "MPH";
            ctcAuthorityLabel.Text = authority.ToString() + " blocks";
            trainTempLabel.Text = (temp.ToString()) + "F";
            blockIDLabel.Text = currentBlock.blockNum.ToString();
            blockSpeedLimitLabel.Text = speedLimit.ToString();
            distanceToLabel.Text = distanceLeft.ToString();
            
        }
        public void updateCurrentSpeed(double s)
        {
            currSpeedms = s;
            currSpeed = s / (0.44704);
        }
        //set control functionality for set speed trackbar
        private void setSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            setSpeedLabel.Text = Convert.ToString(setSpeedTrackBar.Value) + "MPH";
            driverSetSpeed = setSpeedTrackBar.Value;
            serviceOverride = false;
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
            //speedTestTextBox.Text = Convert.ToString(currSpeedms);
            speedTestTextBox.Text = "0";
            tempTestTextBox.Enabled = true;
            //tempTestTextBox.Text = Convert.ToString(temp);
            tempTestTextBox.Text = "0";
            ctcSpeedTestTextBox.Enabled = true;
            //ctcSpeedTestTextBox.Text = Convert.ToString(currSpeedms);
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
            automaticRadioButton.Checked = true;
            manualRadioButton.Checked = false;
            serviceButton.Enabled = false;
            mode = 1;
        }

        private void manualRadioButton_Click(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = true;
            automaticRadioButton.Checked = false;
            manualRadioButton.Checked = true;
            serviceButton.Enabled = true;
            mode = 0;
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

        private void sBreakON()
        {
            serviceButton.Checked = true;
            TM.setService(true);
            //currSpeed = currSpeed - serviceBreak;
        }

        private void sBreakOFF()
        {
            serviceButton.Checked = false;
            TM.setService(false);
        }
        private void setThermostat()
        {
            if (setTemp > temp) thermostat = 2;
            else if (setTemp < temp) thermostat = 1;
            else thermostat = 0;
        }
        public void updateCurrentTemp(double t)
        {
            temp = t;
        }

        /*private void raiseTemp()
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
        }*/

        private void updateDoors()
        {
            if (Left_Open.Checked) leftDoorStatusLabel.Text = "Open";
            else leftDoorStatusLabel.Text = "Closed";
            if (Right_Open.Checked) rightDoorStatusLabel.Text = "Open";
            else rightDoorStatusLabel.Text = "Closed";
            if (Lights_On.Checked) lightStatusLabel.Text = "On";
            else lightStatusLabel.Text = "Off";
        }
        private void setTimeLabel(String t)
        {
            timeLabel.Text = t;
        }

        private void updateSetPoints()
        {
            if (testMode == 0)
            {
                //ctcSetSpeed = currSpeedms;
                // currSpeedms = 0;
            }
            else
            {
                if (!simulate)
                {
                    if (speedTestTextBox.Text != "") currSpeedms = Convert.ToDouble(speedTestTextBox.Text);
                    if (ctcSpeedTestTextBox.Text != "") ctcSetSpeed = Convert.ToDouble(ctcSpeedTestTextBox.Text);
                    if (tempTestTextBox.Text != "") temp = Convert.ToDouble(tempTestTextBox.Text);
                    u = 0;
                    uk = 0;
                    ek = 0;
                }
                else currSpeedms = currSpeed * 3600 / 1000;
                driverSetSpeed = (setSpeedTrackBar.Value) / Convert.ToDouble(0.44704);
                if (mode == 0)
                {
                    setSpeedms = driverSetSpeed;
                }
                else setSpeedms = ctcSetSpeed;
                if (setSpeedms > 80) setSpeedms = 80;
                setTemp = setTempTrackBar.Value;
                setSpeed = setSpeedms * 1000 / 3600;
                currSpeed = currSpeedms * 1000 / 3600;
            }
        }

        private void uploadTrackButton_Click(object sender, EventArgs e)
        {
            setTrack(trackFileTextBox.Text);
            TM.Start();
            uploadTrackButton.Enabled = false;
        }
        private void setTrack(string input)
        {
            blockTracker = new BlockTracker(input);
            currentBlock = blockTracker.getCurrentBlock();
            distanceLeft = currentBlock.length;
        }
        /*private void setTrack(String input)
        {
            StreamReader file = new StreamReader(input);
            string line = file.ReadLine();
            blocks = new SmallBlock[Convert.ToInt32(line) + 1];
            line = file.ReadLine();
            currentBlock = Convert.ToInt32(line);
            tunnelStatusLabel.Text = line;
            for (int i = 0; i < 10; i++) //instead of 10 put block.Length
            {
                line = file.ReadLine();
                string[] elements = line.Split('\t');
                int id = Convert.ToInt32(elements[0]);
                blocks[id] = new SmallBlock(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7]);
            }
            distanceLeft = blocks[currentBlock].getSize();
        }*/
        public void trackPosition(double p)
        {
           if(distanceLeft >= p) distanceLeft -= p;
            else
            {
                authority = authority - 1;
                p = p - distanceLeft;
                nextBlock = blockTracker.getNextBlock(currentBlock.blockNum);
                if (nextBlock == null)
                {
                    currentBlock = blockTracker.getNextBlock(readBeacon());
                    distanceLeft = currentBlock.length - p;
                }
                else
                {
                    currentBlock = nextBlock;
                    distanceLeft = currentBlock.length - p;
                }
            }
        }
        /*private int getNextBlock()
        {
            if (direction == 0)
            {
                if (blocks[currentBlock].getNext2() == 0) return blocks[currentBlock].getNext1();
                else return 0;
            }
            else {
                if (blocks[currentBlock].getPrev2() == 0) return blocks[currentBlock].getPrev2();
                else return 0;
            }
        }*/
        private int readBeacon() { return 0; }
        public void updateSpeedAndAuthority(double s, int a)
        {
            ctcSetSpeed = s;
            authority = a;
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
            serviceOverride = true;
            serviceButton.Checked = true;
            setSpeedTrackBar.Value = 0;
            setSpeedLabel.Text = "0MPH";
            driverSetSpeed = 0;
        }

        private void testModeOff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void setParametersButton_Click(object sender, EventArgs e)
        {
            if(KpTextBox.Text != "") Kp = Convert.ToDouble(KpTextBox.Text);
            if(KpTextBox.Text != "") Ki = Convert.ToDouble(KiTextBox.Text);
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void serviceButton_CheckedChanged(object sender, EventArgs e)
        {
            //serviceOverride = true;
            //setSpeedTrackBar.Value = 0;
            //setSpeedLabel.Text = "0MPH";
        }
    }
}
