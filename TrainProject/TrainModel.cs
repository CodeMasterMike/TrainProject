using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainControllerProject;

namespace TrainModelProject
{
    public partial class TrainModel : Form
    {
        private double train_mass = 37103.86; //kg
        private double person_mass = 73; //kg
        private double mass = 0;
        private double train_length = 32.2; //m
        private double train_height = 3.42; //m
        private double train_width = 2.65; //m
        private double train_pass = 1;
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
        private bool service = false;
        private bool emergency = false;
        private TrainController TC;
        private int start = 0;
        private int AC = 0;
        private int heater = 0;
        private double block_distance = 0;


        public void updateSpeedAndAuthority(double speed, int authority)
        {

        }

        public TrainModel()
        {
            InitializeComponent();
            TC = new TrainController(this);
            TC.Show();
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
            if (TC != null)
            {
                //trainControllerWindow.updateTime(displayTime);
                Invoke(new MethodInvoker(delegate { TC.updateTime(time); }));
            }
        }

        public void currentBlock()
        {
         //Figure out block occupancy!   

        }

        public void updateGUI()
        {
            currSpeedmsF = currSpeedms / 0.44704;
            currSpeedmsF = Math.Round(currSpeedmsF, 2);
            Train_Speed.Text = currSpeedmsF.ToString() + " m/hr";
            Train_Passenger_L.Text = train_pass.ToString();
            Train_Crew_L.Text = train_crew.ToString();
            Train_Internal_Temperature_L.Text = currTemp.ToString() + " *F";
            Train_Mass_L.Text = mass.ToString() + " kg";
            Train_Width_L.Text = train_width.ToString() + " m";
            Train_Height_L.Text = train_height.ToString() + " m";
            Train_Length_L.Text = train_length.ToString() + " m";
            Train_Facilities_L.Text = train_facilities.ToString();
            Train_Door_L.Text = "Closed";
            power = Math.Round(power, 2);
            train_power.Text = power.ToString() + " W";
        }

        public void updatePower(double p)
        {
            power = p;
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
        public void Start()
        {
            start = 1;
        }
        private void calculateSpeed()
        {
            if (currSpeedms > 0)
            {
                force = power / currSpeedms;
                acceleration = force / mass;
                if (acceleration > max_acceleration) acceleration = max_acceleration;
                currSpeedms = acceleration + currSpeedms;
            }
            else if(power > 0) currSpeedms = max_acceleration + currSpeedms;
        }
        private void calculateService()
        {
            currSpeedms = currSpeedms - serviceBrake;
            if (currSpeedms < serviceBrake) currSpeedms = 0;
        }
        private void calculateEmergency()
        {
            currSpeedms = currSpeedms - emergencyBrake;
            if (currSpeedms < emergencyBrake) currSpeedms = 0;
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
    }
}
