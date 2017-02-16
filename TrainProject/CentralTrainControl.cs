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

            Console.Out.WriteLine("hit ctc()");
            trainInfoList.View = View.Details;
            trainInfoList.Columns.Add("Train ID", 80);
            trainInfoList.Columns.Add("Block Location", 120);
            trainInfoList.Columns.Add("Sug. Speed", 100);
            trainInfoList.Columns.Add("Sug. Auth", 100);
            trainInfoList.Items.Add("1", 1);
            trainInfoList.Items[0].SubItems.Add("yard");
            trainInfoList.Items[0].SubItems.Add("0mph");
            trainInfoList.Items[0].SubItems.Add("-");
            trainInfoList.Items.Add("2", 2);
            trainInfoList.Items[1].SubItems.Add("yard");
            trainInfoList.Items[1].SubItems.Add("0mph");
            trainInfoList.Items[1].SubItems.Add("-");
            trainInfoList.Items.Add("3", 3);
            trainInfoList.Items[2].SubItems.Add("yard");
            trainInfoList.Items[2].SubItems.Add("0mph");
            trainInfoList.Items[2].SubItems.Add("-");
            trainInfoList.Items.Add("4", 4);
            trainInfoList.Items[3].SubItems.Add("yard");
            trainInfoList.Items[3].SubItems.Add("0mph");
            trainInfoList.Items[3].SubItems.Add("-");
            trainInfoList.Items.Add("5", 5);
            trainInfoList.Items[4].SubItems.Add("yard");
            trainInfoList.Items[4].SubItems.Add("0mph");
            trainInfoList.Items[4].SubItems.Add("-");
            trainInfoList.Items.Add("6", 6);
            trainInfoList.Items[5].SubItems.Add("yard");
            trainInfoList.Items[5].SubItems.Add("0mph");
            trainInfoList.Items[5].SubItems.Add("-");
            trainInfoList.Items.Add("7", 7);
            trainInfoList.Items[6].SubItems.Add("yard");
            trainInfoList.Items[6].SubItems.Add("0mph");
            trainInfoList.Items[6].SubItems.Add("-");
            trainInfoList.Items.Add("8", 8);
            trainInfoList.Items[7].SubItems.Add("yard");
            trainInfoList.Items[7].SubItems.Add("0mph");
            trainInfoList.Items[7].SubItems.Add("-");
            trainInfoList.Items.Add("9", 9);
            trainInfoList.Items[8].SubItems.Add("yard");
            trainInfoList.Items[8].SubItems.Add("0mph");
            trainInfoList.Items[8].SubItems.Add("-");
            trainInfoList.Items.Add("10", 10);
            trainInfoList.Items[9].SubItems.Add("yard");
            trainInfoList.Items[9].SubItems.Add("0mph");
            trainInfoList.Items[9].SubItems.Add("-");
            trainInfoList.Items.Add("11", 11);
            trainInfoList.Items[10].SubItems.Add("yard");
            trainInfoList.Items[10].SubItems.Add("0mph");
            trainInfoList.Items[10].SubItems.Add("-");
            trainInfoList.Items.Add("yard", 12);
            trainInfoList.Items[11].SubItems.Add("12");
            trainInfoList.Items[11].SubItems.Add("0mph");
            trainInfoList.Items[11].SubItems.Add("-");




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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectScheduleLabel_Click(object sender, EventArgs e)
        {

        }

        private void trainInfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

