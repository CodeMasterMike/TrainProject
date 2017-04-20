﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainControllerProject;
using Track_Layout_UI;
using TrainProject;

namespace TrainModelProject
{
    public partial class TrainModel : Form
    {
        private int trainId;
        private double train_mass = 37103.86; //kg
        private double person_mass = 73; //kg
        private double mass = 0;
        private double train_length = 32.2; //m
        private double train_height = 3.42; //m
        private double train_width = 2.65; //m
        private double train_pass = 10;
        private double train_crew = 1; //m
        private string train_facilities = "Good";
        private double max_acceleration = 0.5; //m per s^2
        private double serviceBrake = 1.2;
        private double emergencyBrake = 2.73; //m per s^2
        private double acceleration = 0;
        private double force = 0;
        private double friction = 0.3;
        private double currSpeedms = 0;
        private double currSpeedmsF = 0;
        private double power = 0;
        private double currTemp = 69;
        private double Train_Door = 0;
        private double station_status = 0;
        private double passenger_off = 0;
        private double passenger_on = 0;
        private bool service = false;
        private bool emergency = false;
        private TrainController TC;
        private int start = 0;
        private int AC = 0;
        private int heater = 0;
        private int train_failures = 0;
        private double block_distance = 0;
        private double train_slope = 0;
        private double pass_from_station = 0;
        Block current_block;
        Block currentT_block;
        Block first_block;
        Block second_block;
        Block next_block;
        Block prev_block;
        Station curr_Station;
        private int TM_count = 0;
        double p;
        double sugSpeed;
        int sugAuthority;
        int lineId;

        public double getCurrSpeed()
        {
            return currSpeedms;
        }
        public void updateAnnouncement(string s)
        {
            announcementLabel.Text = s;
        }

        public int getCurrBlock()
        {
            return current_block.blockId;
        }

        public int getTrainId()
        {
            return trainId;
        }

        public TrainController getTC()
        {
            return TC;
        }


        public void updateSpeedAndAuthority(double speed, int authority)
        {
            TC.updateSpeedAndAuthority(speed, authority);
        }

        public TrainModel() { }

        public TrainModel(int lId, int trainId) 
        {
            InitializeComponent();
            lineId = lId;
            TC = new TrainController(this, trainId, lineId);
            TC.Show();

            double block_length = 0;
            double train_distance = 0;

            current_block = TrainSimulation.trackModelWindow.getNextBlock(null, null, lineId);
            prev_block = null;
            block_distance = current_block.length;
            train_slope = current_block.grade;
            TrainSimulation.trackModelWindow.updateBlockStatus(current_block.blockId, true);
        }

 
        public void updateTime(String time)
        {
            if (start == 0) return;
            setTimeLabel(time);
            mass = person_mass + train_mass;
            TC.trackPosition(currSpeedms);
            if (!service && !emergency) calculateSpeed();
            else if (service) calculateService();
            else if (emergency) calculateEmergency();
            calculateTemperature();
            TC.updateCurrentSpeed(currSpeedms);
            TC.updateCurrentTemp(currTemp);
            updateGUI();
            currentBlock();
            if (TC != null)
            {
                //trainControllerWindow.updateTime(displayTime);
               Invoke(new MethodInvoker(delegate { TC.updateTime(time); }));
            }
        }
        public void updateDoorStatus(int n)
        {
            if (n == 0) Train_Door_L.Text = "Closed";
            else if (n == 1) Train_Door_L.Text = "Left";
            else if (n == 2) Train_Door_L.Text = "Right";
            if(n != 0) announcementLabel.Text = "";
            Train_Door = n;
        }
        public void currentBlock()
        {
            
            
            p = currSpeedms;
            if (block_distance >= p) block_distance -= p;
            else
            {
                double p = currSpeedms;
                p = p - block_distance;

                next_block = TrainSimulation.trackModelWindow.getNextBlock(prev_block, current_block);
                
                prev_block = current_block;
                current_block = next_block;
                

                int number = 0;
                if(current_block.switchBeacon != null) number = current_block.switchBeacon.blockId;
                TC.sendSwitchBeaconInfo(number);
                block_distance = current_block.length - p;
                if (lineId == 2)
                {
                    if (TrackModelUI.redLineStationBeacons[current_block.blockNum] != null) TC.getStationBeaconInfo(TrackModelUI.redLineStationBeacons[current_block.blockNum].isPreviousToNext, TrackModelUI.redLineStationBeacons[current_block.blockNum].distanceTo, TrackModelUI.redLineStationBeacons[current_block.blockNum].name);
                }

                if (lineId == 1)
                {
                    if (TrackModelUI.greenLineStationBeacons[current_block.blockNum] != null) TC.getStationBeaconInfo(TrackModelUI.greenLineStationBeacons[current_block.blockNum].isPreviousToNext, TrackModelUI.redLineStationBeacons[current_block.blockNum].distanceTo, TrackModelUI.redLineStationBeacons[current_block.blockNum].name);

                }
                TrainSimulation.trackModelWindow.updateBlockStatus(prev_block.blockId, false);
                TrainSimulation.trackModelWindow.updateBlockStatus(current_block.blockId, true);
               // Train_Height_L.Text = current_block.blockNum.ToString() + " ..";
            }

            if (Train_Door != 0)
            {
                // Enter Passenger Code
                stationPassengers(current_block.station);
                train_width = 6;
            }


        }

        public void travel()
        {

        }

        public void stationPassengers(Station station)
        {
            Random rnd = new Random();
            passenger_off = rnd.Next(1, Convert.ToInt32(train_pass));
            train_pass = Math.Abs(passenger_off - train_pass);
            pass_from_station = curr_Station.getWaiting();
            if (pass_from_station + train_pass > 75 )
            {
                passenger_on = rnd.Next(1, (75 - Convert.ToInt32(train_pass)));
            }
            else
            {
                passenger_on = pass_from_station;
            }
            train_pass = passenger_on + train_pass;
        }

        public void updateGUI()
        {
            currSpeedmsF = currSpeedms / 0.44704;
            currSpeedmsF = Math.Round(currSpeedmsF, 2);
            Train_Speed.Text = currSpeedmsF.ToString() + " m/hr";
            Train_Passenger_L.Text = train_pass.ToString();
            Train_Crew_L.Text = passenger_off.ToString();
            Train_Internal_Temperature_L.Text = passenger_on.ToString() + " *F";
            //Train_Internal_Temperature_L.Text = currTemp.ToString() + " *F";
            Train_Mass_L.Text = mass.ToString() + " kg";
            Train_Width_L.Text = train_width.ToString() + " m";
            Train_Height_L.Text = train_height.ToString() + " m";
            Train_Length_L.Text = train_length.ToString() + " m";
            Train_Facilities_L.Text = train_facilities.ToString();
            //Train_Door_L.Text = "Closed";
            power = Math.Round(power, 2);
            train_power.Text = power.ToString() + " W";
           
        }

        public void updatePower(double p)
        {
            power = p;
            train_power.Text = p.ToString("#.##");
        }

        private void setTimeLabel(String t)
        {
            Train_ID_L.Text = t;
        }
        
        public void setService(bool b)
        {
            if (b) service = true;
            else service = false;
        }
        public void setEmergency(bool b)
        {
            if (b) emergency = true;
            else emergency = false;
        }
        public void Start()
        {
            start = 1;
        }
        private void calculateSpeed()
        {
            if (currSpeedms > 0)
            {
                double gravity = 9.8;
                double friction_coeff = 0.002;
                double train_slope_M = Math.Abs(train_slope);
                double cos_value = Math.Cos(train_slope_M * (Math.PI / 180.0));
                
                force = power / currSpeedms;

                force = force - (mass * gravity * friction_coeff * cos_value);

                if (train_slope_M == 0)
                {
                    acceleration = force / mass;
                }
                else
                {
                    acceleration = force / (mass * Math.Sin(train_slope_M * (Math.PI / 180.0)));
                }
                
                if (acceleration > max_acceleration) acceleration = max_acceleration;
                if (currSpeedms + acceleration < 0)
                {
                    currSpeedms = 0;
                    currSpeedms = acceleration + currSpeedms;
                }
                else
                {
                    currSpeedms = acceleration + currSpeedms;
                }
                //currSpeedms = acceleration + currSpeedms;
            }
            else if(power > 0) currSpeedms = max_acceleration + currSpeedms;
        }
        private void calculateService()
        {
            if (currSpeedms < serviceBrake) currSpeedms = 0;
            else currSpeedms = currSpeedms - serviceBrake;
           
        }
        private void calculateEmergency()
        {
            if (currSpeedms < emergencyBrake) currSpeedms = 0;
            else currSpeedms = currSpeedms - emergencyBrake;
            
        }
        public void updateThermostat(int status)
        {
            if(status == 0)
            {
                AC = 0;
                heater = 0;
                train_facilities = "Good";
            }
            else if(status == 1)
            {
                AC = 1;
                heater = 0;
                train_facilities = "A/C On";
            }
            else if(status == 2)
            {
                AC = 0;
                heater = 1;
                train_facilities = "Heater On";
            }
        }
        private void calculateTemperature()
        {
            if (AC == 1)
            {
                currTemp = currTemp - 1;
            }
            else if (heater == 1)
            {
                currTemp = currTemp + 1;

            }
            else
            {
                currTemp = currTemp;
            }
        }


        private void TrainModel_Load(object sender, EventArgs e)
        {

        }

        private void Train_Length_L_Click(object sender, EventArgs e)
        {

        }

        private void failTrainEngineButton_Click(object sender, EventArgs e)
        {
            train_failures = 1;
            TC.updateFailure(train_failures);
        }

        private void failSignalPickupButton_Click(object sender, EventArgs e)
        {
            train_failures = 2;
            TC.updateFailure(train_failures);
        }

        private void failBrakeButton_Click(object sender, EventArgs e)
        {
            train_failures = 3;
            TC.updateFailure(train_failures);
        }
    }
}
