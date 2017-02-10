using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTC
{
    public partial class CentralTrainControl : Form
    {
        public CentralTrainControl()
        {
            InitializeComponent();
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            //setSpeed()
            //sendSpeedAndAuthority
        }

        private void authTrackBar_Scroll(object sender, EventArgs e)
        {
            //setAuthority()
            //sendSpeedAndAuthority

        }

        private void openBlockButton_Click(object sender, EventArgs e)
        {
            //openBlock()
        }

        private void closeBlockButton_Click(object sender, EventArgs e)
        {
            //closeBlock()
        }

        private void lineSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectLineToShow()
        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            //setSystemMode = manual
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            //setSystemMode() = automatic
        }

        private void mboRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setAutomaticMode() = MBO
        }

        private void fbRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setAutomaticMode() = FB
        }

        private void selectScheduleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectDispatchSchedule() || selectDispatchBlock()
        }

        private void dispatchTrainButton_Click(object sender, EventArgs e)
        {
            //dispatchTrain()
        }

        private void wallClockRadio_CheckedChanged(object sender, EventArgs e)
        {
            //setSystemSpeed() = wallClock
        }

        private void tenTimesLabel_CheckedChanged(object sender, EventArgs e)
        {
            //setSystemSpeed() = tenTime
        }

        private void fixTrainButton_Click(object sender, EventArgs e)
        {
            //sendTrainMaintenance()
        }

        private void fixTrackButton_Click(object sender, EventArgs e)
        {
            //sendTrackMaintenance()
        }
    }
}

