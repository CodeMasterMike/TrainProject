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
        private double max_acceleration = 0.5; //m per s^2
        private double serviceBrake = 1.2;
        private double emergencyBrake = 2.73; //m per s^2
        private double acceleration = 0;
        private double force = 0;
        private double friction = 0.3;
        private double currSpeedms = 0;
        private double power = 0;
        private bool service = false;
        private bool emergency = false;
        private TrainController TC;
        private int start = 0;
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
            label5.Text = currSpeedms.ToString();
            TC.updateCurrentSpeed(currSpeedms);
            if (TC != null)
            {
                //trainControllerWindow.updateTime(displayTime);
                Invoke(new MethodInvoker(delegate { TC.updateTime(time); }));
            }
        }
        public void updatePower(double p)
        {
            power = p;
        }

        private void setTimeLabel(String t)
        {
            label8.Text = t;
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

        private void TrainModel_Load(object sender, EventArgs e)
        {

        }
    }
}
