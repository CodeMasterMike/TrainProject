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
        public Boolean liveGPS;
        public int trainId;
        public int trainsPerHour;
        public int numDrivers;
        public int blockAdjustment;
        public int SuggestedSpeed;
        public int lineId;

        public TrainModel TM;
        public DriverSchedule driverSchedule;

        public MBO()
        {
            InitializeComponent();
            label18.Text = "Inactive";
            label18.ForeColor = System.Drawing.Color.Red;  
        }

        private void createTrainScheduleButton_Click(object sender, EventArgs e)
        {
            createTrainSchedule();
        }

        private void createDriverScheduleButton_Click(object sender, EventArgs e)
        {
            createDriverSchedule();
        }

        private void createTrainSchedule()
        {

            Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();

            if (schedulesApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook schedulesWorkbook;
            Excel.Worksheet schedulesWorksheet;
            object misValue = System.Reflection.Missing.Value;

            schedulesWorkbook = schedulesApp.Workbooks.Add(misValue);
            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            schedulesWorksheet.Cells[1, 1] = "Train ID";
            //schedulesWorksheet.Cells[1, 2] = "Name";
            schedulesWorksheet.Cells[2, 1] = "1";
            schedulesWorksheet.Cells[2, 2] = "Drive";
            schedulesWorksheet.Cells[2, 3] = "Drive";
            schedulesWorksheet.Cells[2, 4] = "Drive";
            schedulesWorksheet.Cells[2, 5] = "Drive";
            schedulesWorksheet.Cells[2, 6] = "Drive";
            schedulesWorksheet.Cells[2, 7] = "Drive";
            schedulesWorksheet.Cells[2, 8] = "Drive";
            schedulesWorksheet.Cells[2, 9] = "Drive";
            schedulesWorksheet.Cells[2, 10] = "Drive";
            schedulesWorksheet.Cells[2, 11] = "Drive";
            schedulesWorksheet.Cells[2, 12] = "Drive";
            schedulesWorksheet.Cells[2, 13] = "Drive";
            schedulesWorksheet.Cells[2, 14] = "Drive";
            schedulesWorksheet.Cells[2, 15] = "Drive";
            schedulesWorksheet.Cells[2, 16] = "Drive";
            schedulesWorksheet.Cells[2, 17] = "Drive";
            schedulesWorksheet.Cells[2, 18] = "Drive";
            schedulesWorksheet.Cells[2, 19] = "Clock Out";



            schedulesWorksheet.Cells[1, 2] = "8:00";
            schedulesWorksheet.Cells[1, 3] = "8:30";
            schedulesWorksheet.Cells[1, 4] = "9:00";
            schedulesWorksheet.Cells[1, 5] = "9:30";
            schedulesWorksheet.Cells[1, 6] = "10:00";
            schedulesWorksheet.Cells[1, 7] = "10:30";
            schedulesWorksheet.Cells[1, 8] = "11:00";
            schedulesWorksheet.Cells[1, 9] = "11:30";
            schedulesWorksheet.Cells[1, 10] = "12:00";
            schedulesWorksheet.Cells[1, 11] = "12:30";
            schedulesWorksheet.Cells[1, 12] = "1:00";
            schedulesWorksheet.Cells[1, 13] = "1:30";
            schedulesWorksheet.Cells[1, 14] = "2:00";
            schedulesWorksheet.Cells[1, 15] = "2:30";
            schedulesWorksheet.Cells[1, 16] = "3:00";
            schedulesWorksheet.Cells[1, 17] = "3:30";
            schedulesWorksheet.Cells[1, 18] = "4:00";
            schedulesWorksheet.Cells[1, 19] = "4:30";

            schedulesWorksheet.Cells[1, 20] = "5:00";
            schedulesWorksheet.Cells[1, 21] = "5:30";
            schedulesWorksheet.Cells[1, 22] = "6:00";

            schedulesWorksheet.Cells[1, 23] = "6:30";
            schedulesWorksheet.Cells[1, 24] = "7:00";


            
            



            schedulesWorkbook.SaveAs("C:\\Users\\Public\\TrainSchedule", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //schedulesWorkBook.Open("C:\\Users\\Public\\Schedules");

            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\TrainSchedule.xls");



            schedulesWorkbook = schedulesApp.Workbooks.Open("C:\\Users\\Public\\TrainSchedule", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            //MessageBox.Show(schedulesWorksheet.get_Range("A1", "A1").Value2.ToString());

            schedulesWorkbook.Close(true, misValue, misValue);
            schedulesApp.Quit();

            Marshal.ReleaseComObject(schedulesWorksheet);
            Marshal.ReleaseComObject(schedulesWorkbook);
            Marshal.ReleaseComObject(schedulesApp);

            MessageBox.Show("Excel file created , you can find the file at C:\\Users\\Public\\TrainSchedule");

        }

       
        private void createDriverSchedule()
        {
            driverSchedule = new DriverSchedule();
        }

        public void viewTrainSchedule_Click(object Sender, EventArgs e)
        {
            driverSchedule.viewDriverSchedule();   
            //viewTrainSchedule();
        }

        public void viewDriverSchedule_Click(object Sender, EventArgs e)
        {
            viewDriverSchedule();
        }
        public void viewTrainSchedule()
        {
            //System.Diagnostics.Process.Start(@"C:\\Users\\Public\\TrainSchedule.xls");
            //Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();
            //schedulesApp.Workbooks.Open("C:\\Users\\Public\\TrainSchedule", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        }

        public void viewDriverSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\DriverSchedule.xls");
        }
        public void updateTrainSchedule()
        {

        }

        public void updateDriverSchedule()
        {

        }

        public void dispatchTrain()
        {
            TrainSimulation.mainOffice.dispatchNewTrain();
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

        public void isAuto(Boolean mode)
        {
            if (mode)
            {
                autoMode = true;
                label18.Text = "Active";
                label18.ForeColor = System.Drawing.Color.Lime;
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
            getPos();
        }

        public void getPos()
        {
            TM = new TrainModel();
            int test = TM.getTrainTest();
            MessageBox.Show("TrainID testing value set from TrainController is " + test); 

            MessageBox.Show("Position and speed received.");
        }

        public void getSuggestedSpeed()
        {

        }

        public void setAuthority_Click(object Sender, EventArgs e)
        {
            setAuthority();
        }

        public void setAuthority()
        {
            MessageBox.Show("Authority sent.");
        }

        public void getTrainSchedule()
        {

        }

        public void getDriverSchedule()
        {

        }
        

        public void setNumDrivers()
        {

        }

        public void setTrainsPerHour()
        {

        }

        private void breakAntenna_Click(object sender, EventArgs e)
        {
            breakAntenna();
        }

        private void fixAntenna_Click(object sender, EventArgs e)
        {
            fixAntenna();
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
            calculateVariance();
        }

        private void calculateVariance()
        {
            label4.Text = "0";
            label4.ForeColor = System.Drawing.Color.Lime;
        }

        private void passengerMovement_Click(object sender, EventArgs e)
        {
            passengerMovement();
        }

        private void passengerMovement()
        {
            //MessageBox.Show("We have the best passengers. We have the best trains. We move so many passengers you wouldn't believe it, believe me.");


            //string input = Microsoft.VisualBasic.Interaction.InputBox("Title", "Prompt", "Default", 0, 0);
            string input = "Choose a starting time";
            String result = ShowInputDialog(ref input);
            //MessageBox.Show(result);

            int startTime = Convert.ToInt32(result);
           // MessageBox.Show("Today is " + dateTimePicker1.Value.Date);
            //MessageBox.Show("the time is " + dateTimePicker1.Value.Date.ToShortTimeString());

            //How to Parse strings to time
            //String timeString = "1:00 am";
            //TimeSpan chosenTime = TimeSpan.Parse(timeString);



            //MessageBox.Show("Time parsed is " + chosenTime + "");

            //This is how i will add time
            //TimeSpan time = new TimeSpan(13, 0, 0);
            TimeSpan timespan = new TimeSpan(startTime, 0, 0);
            DateTime time = DateTime.Today.Add(timespan);
            MessageBox.Show("Time chosen is " + time.ToString("hh:mm tt") + "");

            TimeSpan addTime = new TimeSpan(0, 0, 30, 0);

            time = time.Add(addTime);
            
            MessageBox.Show("Added time to chosen time is " + time);

            input = "Choose a closing time";
            result = ShowInputDialog(ref input);
            int closeTime = Convert.ToInt32(result);

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
