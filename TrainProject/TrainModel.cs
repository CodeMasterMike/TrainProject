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
        private double mass = 1000;
        private double friction = 0.3;
        private double currSpeedms = 0;
        private double power = 0;
        private bool service = false;
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
            TC.trackPosition(currSpeedms);
            if (!service) currSpeedms = currSpeedms + power / 10000;
            else currSpeedms = currSpeedms - 1;
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
        private void TrainModel_Load(object sender, EventArgs e)
        {

        }
    }
}
