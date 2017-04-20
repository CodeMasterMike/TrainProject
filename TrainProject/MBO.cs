using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using TrainProject;
using TrainProject.HelperObjects;
using TrainProject.Clock;
using TrainModelProject;

namespace MBO_UI
{
    public partial class MBO : Form
    {
        public List<Block> blockList = new List<Block>();
        public List<Block> filteredBlockList = new List<Block>();
        public List<Section> sectionList = new List<Section>();
        public List<Line> lineList = new List<Line>();
        public Block selectedBlock;
        public Line selectedLine;

        public Boolean autoMode = false;
        public Boolean MBOMode = false;
        public Boolean liveGPS;
        public int trainId;
        public int trainsPerHour;
        public int numDrivers;
        public int blockAdjustment;
        public int SuggestedSpeed;
        public int lineId;
        public int timeStart;
        public int timeEnd;

        public TrainModel TM;
        public DriverSchedule driverSchedule;
        public TrainSchedule trainSchedule;
        public string initialClock;
        public Boolean updateNeed;


        //public TrainSimulation trainSimulation = new TrainSimulation();
        //CustomClock clk = new CustomClock(trainSimulation);

        public MBO()
        {
            InitializeComponent();
            label18.Text = "Inactive";
            label18.ForeColor = System.Drawing.Color.Red;
            updateNeed = false;
        }

        private void createTrainScheduleButton_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                createTrainSchedule();
            }
        }

        private void createDriverScheduleButton_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                createDriverSchedule();
            }
        }

        private void createTrainSchedule()
        {

            trainSchedule = new TrainSchedule();
            MessageBox.Show("Please set up appropriate files and parameters then click okay.");
            dispatchTrain();
        }

       
        private void createDriverSchedule()
        {
            timeStart = trainSchedule.getStart();
            timeEnd = trainSchedule.getEnd();
            driverSchedule = new DriverSchedule(timeStart,timeEnd);
        }

        public void viewTrainSchedule_Click(object Sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                //trainSchedule.viewTrainSchedule();   
                viewTrainSchedule();
            }
            
        }

        public void viewDriverSchedule_Click(object Sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                viewDriverSchedule();
            }
        }

        public void viewTrainSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\TrainSchedule.xls");
            //Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();
            //schedulesApp.Workbooks.Open("C:\\Users\\Public\\TrainSchedule", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        }

        public void viewDriverSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\DriverSchedule.xls");
        }

        public void updateTime(String time)
        {
            initialClock = time;
            setTimeLabel(time);
        }

        public void setTimeLabel(String time)
        {
            label6.Text = time;
        }

        public int getTime()
        {
            //MessageBox.Show(label6.Text);
            char delimiter = ':';
            string currentClock = label6.Text;
            String[] textSubString = (currentClock.Split(delimiter));
            int clockPassed = Int32.Parse(textSubString[0]);
            return clockPassed;
        }


        public void updateTrainSchedule()
        {
            if(updateNeed)
            {
                MessageBox.Show("Train schedule updated as needed.");
                updateNeed = false;
            }
            else
            {
                MessageBox.Show("There are no changes to update.");
            }
        }

        public void updateDriverSchedule()
        {
            if (updateNeed)
            {
                MessageBox.Show("Train schedule updated as needed.");
                updateNeed = false;
            }
            else
            {
                MessageBox.Show("There are no changes to update.");
            }
        }

        public void dispatchTrain()
        {
            //TrainSimulation.mainOffice.dispatchNewTrain();
            TrainSimulation.mainOffice.dispatchMBOTrain(1, 65,308);
            TrainSimulation.mainOffice.dispatchMBOTrain(2, 65, 608);
        }

        public void sendTrainSchedule()
        {

        }

        public void sendDriverSchedule()
        {

        }

        public void isGPS()
        {

        }

        public void isMBO(Boolean mode)
        {
            if (mode)
            {
                autoMode = true;
                label18.Text = "MBO";
                label18.ForeColor = System.Drawing.Color.Lime;
                trainSchedule = new TrainSchedule();
                timeStart = trainSchedule.getStart();
                timeEnd = trainSchedule.getEnd();
                driverSchedule = new DriverSchedule(timeStart, timeEnd);
                MessageBox.Show("Please set up appropriate files and parameters then click okay.");
                dispatchTrain();
            }
            else
            {
                autoMode = false;
                label18.Text = "Inactive";
                label18.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void isAuto(Boolean mode)
        {
            if (mode)
            {
                autoMode = true;
                label18.Text = "Fixed Block";
                label18.ForeColor = System.Drawing.Color.Lime;
                trainSchedule = new TrainSchedule();
                timeStart = trainSchedule.getStart();
                timeEnd = trainSchedule.getEnd();
                driverSchedule = new DriverSchedule(timeStart, timeEnd);
                MessageBox.Show("Please set up appropriate files and parameters then click okay.");
                dispatchTrain();
            }
            else
            {
                autoMode = false;
                label18.Text = "Inactive";
                label18.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void getPos_Click(object Sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                getPos();
            }
        }

        public void getPos()
        {
            //TM = new TrainModel();
            //int test = TM.getTrainTest();
           // MessageBox.Show("TrainID testing value set from TrainController is " + test); 
            
            MessageBox.Show("Position and speed received.");
        }

        public void getVitalSpeed()
        {
            
        }

        public void setAuthority_Click(object Sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                setAuthority();
            }
        }

        public void setAuthority()
        {
            MessageBox.Show("Authority sent.");
        }

        public void getTrainSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\TrainSchedule.xls");
        }

        public void getDriverSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\DriverSchedule.xls");
        }
        
        public void setUpdateNeed()
        {
            updateNeed = true;
        }

        public void setNumDrivers()
        {

        }

        public void setTrainsPerHour()
        {

        }

        private void breakAntenna_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                breakAntenna();
                updateNeed = true;
            }
        }

        private void fixAntenna_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                fixAntenna();
            }
        }

        public void breakAntenna()
        {
            label15.Text = "Disconnected";
            label15.ForeColor = System.Drawing.Color.Red;
        }

        public void fixAntenna()
        {
            label15.Text = "Connected";
            label15.ForeColor = System.Drawing.Color.Lime;
        }

        private void calculateVariance_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                calculateVariance();
            }
        }

        private void calculateVariance()
        {
            label4.Text = "0";
            label4.ForeColor = System.Drawing.Color.Lime;
            dispatchTrain();
            
        }

        private void passengerMovement_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                passengerMovement();
                //getTime();
            }
        }

        private void updateTrain_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                updateTrainSchedule();
            }
        }

        private void updateDriver_Click(object sender, EventArgs e)
        {
            if (autoMode == false && MBOMode == false)
            {
                MessageBox.Show("System is not in automatic mode, please switch modes and try again");
            }
            else
            {
                updateDriverSchedule();
            }
        }

        private void passengerMovement()
        {
            //MessageBox.Show("We have the best passengers. We have the best trains. We move so many passengers you wouldn't believe it, believe me. How do you calculate this? Nobody knows, not even we know, it's one of the world's greatest mysteries");
            getTime();
            string currentClock = label6.Text;
            MessageBox.Show("Passenger movement data recorded and sent from " + timeStart + " am up until " + currentClock + "");

            //string input = Microsoft.VisualBasic.Interaction.InputBox("Title", "Prompt", "Default", 0, 0);
            /*string input = "Choose a starting time";
            String result = ShowInputDialog(ref input);
            //MessageBox.Show(result);

            int startTime = Convert.ToInt32(result);
         

            //How to Parse strings to time
            //String timeString = "1:00 am";
            //TimeSpan chosenTime = TimeSpan.Parse(timeString);



            //MessageBox.Show("Time parsed is " + chosenTime + "");

           
            TimeSpan timespan = new TimeSpan(startTime, 0, 0);
            DateTime time = DateTime.Today.Add(timespan);
            MessageBox.Show("Time chosen is " + time.ToString("hh:mm tt") + "");

            TimeSpan addTime = new TimeSpan(0, 0, 30, 0);

            time = time.Add(addTime);
            
            MessageBox.Show("Added time to chosen time is " + time);

            input = "Choose a closing time";
            result = ShowInputDialog(ref input);
            int closeTime = Convert.ToInt32(result);*/

        }


        private static string ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return input;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

