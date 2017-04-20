//Train Controller Module
//Created by : Naran Babha
//Date Created : 2/20/17
//This class is the main code for the Train Controller. It heavily uses the block tracker class
//found in the helper objects folder, as well as the Power controller class found in the same folder
//This class runs from the updateTime functon, which does things such as update the gui, calculate power, track
//positions, etc.
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
using System.Media;

namespace TrainControllerProject
{
    public partial class TrainController : Form
    {
        //initialize variables
        private double driverSetSpeed = 0;
        private double ctcSetSpeed = 0;
        private double setSpeed = 0;
        private int authority = 0;
        private double setTemp = 70;
        private double speedLimitms = 0;
        private double temp = 70;
        private double distanceToStop = 0;
        private double distanceToStation = 0;
        private double distanceToAuthority = 0;
        private double minStopDistanceStation = 0;
        private double minStopDistanceAuthority = 0;
        private double minStopDistance = 0;
        private double futureSpeedLimit = 0;
        private double futureSpeedLimitms = 0;
        private SmallBlock[] blocks;
        private BlockTracker blockTracker;
        int testMode = 0; //test mode off = 0 test mode on = 1
        int mode = 1; //manual = 0 automatic  = 1
        int currentBlockID;
        int speedLimit;
        int blockNum;
        private bool prevToNext = true;
        int wait = 0;
        int thermostat = 0; // 0 = both off, 1 = AC, 2 = Heater
        int doorStatus;
        int trainID = 0;
        int stationSide = 1;
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
        int lineID = 2;
        bool forceStop = false;
        bool emergencyOverride = false;
        Block currentBlock;
        Block nextBlock;
        String stationName = "";
        bool stationPrevToNext;
        bool simulate = false;
        bool approachingStation = false;
        bool authorityChanged = false;
        public int failureStatus = 0;
        bool lightStatus = false;
        PowerController powerController;
        TrainModel TM;
        Map map;

        public double getRemainingAuthority()
        {
            return distanceToAuthority;
        }
        //initialize labels and controls

        //constructor for train controller. Gets reference to its train model for communication, and gets
        //its train id and the line (red or green)
        public TrainController(TrainModel t, int id, int line)
        {
            InitializeComponent();
            TM = t;
            trainID = id;
            lineID = line;
            //speaker = new SpeechSynthesizer();
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
            leftClosed.Enabled = false;
            leftOpen.Enabled = false;
            serviceButton.Enabled = false;
        }
        //every time interval update all of the displays and internal variables, set calculations for real time
        public void updateTime(String time)
        {
            setTimeLabel(time);
            speedLimit = currentBlock.speedLimit;
            speedLimitms = speedLimit / 3.6;
            //look ahead and find if the next two blocks have a lower speed limit than the current block
            considerSpeedLimit();
            //this section sets the speed limit and the allowed set speed for the train
            if (futureSpeedLimitms < speedLimitms)
            {
                speedLimitms = futureSpeedLimitms;
            }
            if (testMode == 0) {
                //figure out setSpeed;
                if (mode == 0) setSpeed = driverSetSpeed;
                else setSpeed = ctcSetSpeed;
                setSpeedms = setSpeed * 0.44704;
                if (setSpeedms > speedLimitms) setSpeedms = speedLimitms;
            }
            //calculate minumum stopping distance for authority and stations. Use this
            //information to figure out when train needs to start stopping
            considerAuthority();
            considerStations();
            resetStation();
            if (distanceToStation < minStopDistanceStation || distanceToAuthority < minStopDistanceAuthority) forceStop = true;
            if ((currSpeedms <= setSpeedms) && !forceStop &&!emergencyOverride && authority > 0)
            {
                sBreakOFF();
                emergencyOFF();
                power = powerController.getPower(currSpeedms, setSpeedms);
            }
            //else if (forceStop)
           // {
           //
           // }
           else if (emergencyOverride)
            {
                emergencyON();
            }
            else
            {
                sBreakON();
                power = 0;
            }
            //set all control signals and pass them on to the train model so then next unit of time, train
            //model updates with the information
            setThermostat();
            setLights();
            TM.updatePower(power);
            TM.updateThermostat(thermostat);
            TM.updateDoorStatus(doorStatus);
            TM.updateLightStatus(lightStatus);
            //update the GUI with all relevant signals
            trainSpeedLabel.Text = (currSpeedms* 2.23694).ToString("#.###") + "MPH";
            trainPowerLabel.Text = (power / 1000).ToString("#.###") + "kW";
            ctcSpeedLabel.Text = (ctcSetSpeed).ToString("#.###") + "MPH";
            ctcAuthorityLabel.Text = authority.ToString() + " blocks";
            trainTempLabel.Text = (temp.ToString()) + "F";
            blockIDLabel.Text = currentBlock.blockNum.ToString();
            blockSpeedLimitLabel.Text = (speedLimit * 0.621371).ToString("#.##") + "MPH";
            //blockSpeedLimitLabel.Text = minStopDistanceAuthority.ToString();
            //tunnelStatusLabel.Text = distanceToAuthority.ToString();
            distanceLeftLabel.Text = distanceLeft.ToString("#.##");
            distanceToLabel.Text = (distanceToStation).ToString("#.##");
            stationLabel.Text = stationName.ToString();
            trainIDLabel.Text = trainID.ToString();
            if (lightStatus)
            {
                tunnelStatusLabel.Text = "Underground";
            }
            else
            {
                tunnelStatusLabel.Text = "Above";
            }
            if (lightStatus)
            {
                lightsON.Checked = true;
            }
            else
            {
                lightsON.Checked = false;
            }
            //set the door status on the GUI
            if(doorStatus == 0)
            {
                leftClosed.Checked = true;
                rightClosed.Checked = true;
            }
            else if(doorStatus == 1)
            {
                leftOpen.Checked = true;
                rightClosed.Checked = true;
            }
            else if(doorStatus == 2)
            {
                leftClosed.Checked = true;
                rightOpen.Checked = true;
            }
            
        }
        //determine if the train is underground or not, turn on/off lights accordingly
        private void setLights()
        {
            if (currentBlock.isUnderground) lightStatus = true;
            else lightStatus = false;
        }
        //0 = no failure, 1 = Train Engine Failure, 2 = signal pickup failure, 3 = brake failure
        //method for train model to call to update with failure status
        public void updateFailure(int a)
        {
            failureStatus = a;
            if (failureStatus > 0) emergencyOverride = true;
            if (failureStatus == 0)
            {
                brakeStatusLabel.Text = "Normal";
                engineStatusLabel.Text = "Normal";
                signalStatusLabel.Text = "Normal";
            }
            if(failureStatus == 1)
            {
                engineStatusLabel.Text = "Failed";
            }
            if (failureStatus == 2)
            {
                signalStatusLabel.Text = "Failed";
            }
            if (failureStatus == 3)
            {
                brakeStatusLabel.Text = "Failed";
            }

        }
        //sets emergency break on and sends signal to train model
        private void emergencyON()
        {
            if (failureStatus != 0 || currSpeedms > 0)
            {
                emergencyButton.Checked = true;
                TM.setEmergency(true);
                power = 0;
            }
            else
            {
                emergencyOFF();
                emergencyOverride = false;
            }

        }
        private void emergencyOFF()
        {
            emergencyButton.Checked = false;
            TM.setEmergency(false);
        }
        //once arrived at a station, reset all the flags so the train can continue moving
        //freely after it exits the station
        private void resetStation()
        {
            if (forceStop && currSpeedms == 0)
            {
                forceStop = false;
                stationName = "";
                wait++;
                doorStatus = stationSide;
            }
            if (wait == 5 && distanceToStation == 0)
            {
                minStopDistanceStation = 0;
                wait = 0;
                doorStatus = 0;
            }
        }
        //calculate minumum stopping distance to a station
        private void considerStations()
        {
            if(distanceToStation > 0)
            {
                minStopDistanceStation = (currSpeedms *currSpeedms) / (2 * serviceBreak);
            }
        }
        //figure out if future speed limit is lower than the current speed limit
        private void considerSpeedLimit()
        {
            BlockTracker bs = new BlockTracker(prevToNext, currentBlock.blockNum, lineID);
            futureSpeedLimit = bs.getSpeedLimit();
            futureSpeedLimitms = futureSpeedLimit / 3.6;
        }
        //calculate minumum stopping distance for the authority that the train has left
        private void considerAuthority()
        {
            if(authority <= 3 && authorityChanged)
            {
                BlockTracker bs = new BlockTracker(prevToNext, currentBlock.blockNum, lineID);
                //if (blockTracker.getOnSwtich()) bs.configureDirection();
                distanceToAuthority = bs.getDistance(authority);
                authorityChanged = false;
            }
            if(distanceToAuthority > 0) minStopDistanceAuthority = (currSpeedms * currSpeedms) / (2 * serviceBreak);
        }
        //function called by the train model
        public void getStationBeaconInfo(bool pn, double distance, String n, bool left)
        {
            if (left) stationSide = 1;
            else stationSide = 2;
            distanceToStation = distance + 5;
            stationName = n;
            stationPrevToNext = pn;
            if (prevToNext != stationPrevToNext)
            {
                distanceToStation = 0;
                stationName = "";
            }
            approachingStation = true;
            if(mode == 1 && distanceToStation != 0)
            {
                TM.updateAnnouncement("Now arriving at station " + stationName);
            }
        }
        //function called by train model to send controller the beacon info which is just the current block
        //in the switch beacon case
        public void sendSwitchBeaconInfo(int b)
        {
            blockNum = b;
        }
        //function called by the train model to update controller with the current speed
        public void updateCurrentSpeed(double s)
        {
            currSpeedms = s;
            currSpeed = s / (0.44704);
        }
        //set control functionality for set speed trackbar
        private void setSpeedTrackBarScroll(object sender, EventArgs e)
        {
            setSpeedLabel.Text = Convert.ToString(setSpeedTrackBar.Value) + "MPH";
            driverSetSpeed = setSpeedTrackBar.Value;
            serviceOverride = false;
        }
        //set control functionality for set temp trackbar
        private void setTempTrackBarScroll(object sender, EventArgs e)
        {
            setTempLabel.Text = Convert.ToString(setTempTrackBar.Value) + "F";
            setTemp = setTempTrackBar.Value;
        }
        //activate test mode
        private void testModeOnClick(object sender, EventArgs e)
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
        private void testModeOffClick(object sender, EventArgs e)
        {
            testMode = 0;
            blockTestTextBox.Enabled = false;
            speedTestTextBox.Enabled = false;
            tempTestTextBox.Enabled = false;
            ctcSpeedTestTextBox.Enabled = false;
            ctcAuthorityTestTextBox.Enabled = false;
            simulateButton.Enabled = false;
        }
        //driver chooses automatic mode. de-enables buttons for driver and changes the mode so that
        //the train knows to follow ctc set speed
        private void automaticRadioButtonClick(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = false;
            automaticRadioButton.Checked = true;
            manualRadioButton.Checked = false;
            sendAnnouncementButton.Enabled = false;
            serviceButton.Enabled = false;
            mode = 1;
        }
        //driver chooses manual mode. enables buttons for drivers and changes the mode so that the train knows to
        //follow the driver set speed
        private void manualRadioButtonClick(object sender, EventArgs e)
        {
            setSpeedTrackBar.Enabled = true;
            automaticRadioButton.Checked = false;
            manualRadioButton.Checked = true;
            serviceButton.Enabled = true;
            sendAnnouncementButton.Enabled = true;
            mode = 0;
        }
        private void updateTimeLabel(String time)
        {
            timeLabel.Text = time;
        }

        private void simulateButtonClick(object sender, EventArgs e)
        {
            if (simulate) simulate = false;
            else
            {
                simulate = true;
            }
        }
        //turn service break on and notify train model
        private void sBreakON()
        {
            serviceButton.Checked = true;
            TM.setService(true);
            //currSpeed = currSpeed - serviceBreak;
        }
        //turn service break off and notify train model
        private void sBreakOFF()
        {
            serviceButton.Checked = false;
            TM.setService(false);
        }
        //set ac or heater based on current temp of the train and the set temp
        private void setThermostat()
        {
            if (setTemp > temp)
            {
                thermostat = 2;
                heaterON.Checked = true;
                acOFF.Checked = true;
            }
            else if (setTemp < temp)
            {
                thermostat = 1;
                acON.Checked = true;
                heaterOFF.Checked = true;
            }
            else
            {
                thermostat = 0;
                acOFF.Checked = true;
                heaterOFF.Checked = true;
            }
        }
        //function for the train model to update its current temp
        public void updateCurrentTemp(double t)
        {
            temp = t;
        }
        //sets the time label for the GUI
        private void setTimeLabel(String t)
        {
            timeLabel.Text = t;
        }
        /*
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
        }*/
        //when set parameters button is hit, train starts and is lodaed with kp and ki or default values
        private void uploadTrackButtonClick(object sender, EventArgs e)
        {
            if (KpTextBox.Text != "")
            {
                Kp = Convert.ToDouble(KpTextBox.Text);
                powerController.setKP(Kp);
            }
            if (KiTextBox.Text != "")
            {
                Ki = Convert.ToDouble(KiTextBox.Text);
                powerController.setKI(Ki);
            }
            setTrack(trackFileTextBox.Text);
            TM.Start();
            uploadTrackButton.Enabled = false;
        }
        //sets up the internal track in the block tracker object
        private void setTrack(string input)
        {
            blockTracker = new BlockTracker(input, lineID);
            currentBlock = blockTracker.getCurrentBlock();
            distanceLeft = currentBlock.length;
        }
        //function called by train model - updates distance train has moved since the last unit of time
        //if the distance does not pass the current block, we simply update with the distance left in the block
        //if we pass a block, we have to get the next block by using block tracker object and possibly
        //the beacons if the next block is ambiguous
        public void trackPosition(double p)
        {
            distanceToStation = distanceToStation - p;
            if (distanceToStation < 0) distanceToStation = 0;
            distanceToAuthority = distanceToAuthority - p;
            if (distanceToAuthority < 0) distanceToAuthority = 0;
           if(distanceLeft >= p) distanceLeft -= p;
            else
            {
                authority = authority - 1;
                p = p - distanceLeft;
                nextBlock = blockTracker.getNextBlock(currentBlock.blockNum);
                if (nextBlock == null)
                {
                    currentBlock = blockTracker.getBlock(blockNum);
                    distanceLeft = currentBlock.length - p;
                }
                else
                {
                    currentBlock = nextBlock;
                    distanceLeft = currentBlock.length - p;
                }
                prevToNext = blockTracker.getDirection(currentBlock.blockId);
            }
        }
        //method called by train model to update setpoints from the CTC
        public void updateSpeedAndAuthority(double s, int a)
        {
            ctcSetSpeed = s;
            authority = a;
            authorityChanged = true;
            minStopDistanceAuthority = 0;
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

        private void emergencyButtonClick(object sender, EventArgs e)
        {
            emergencyOverride = true;
            emergencyButton.Checked = true;
            setSpeedTrackBar.Value = 0;
            setSpeedLabel.Text = "0MPH";
            driverSetSpeed = 0;
        }

        private void serviceButtonClick(object sender, EventArgs e)
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

        private void setParametersButtonClick(object sender, EventArgs e)
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

        private void sendAnnouncementButtonClick(object sender, EventArgs e)
        {
            TM.updateAnnouncement(announcementTextBox.Text);
            announcementTextBox.Text = "";
        }
    }
}
