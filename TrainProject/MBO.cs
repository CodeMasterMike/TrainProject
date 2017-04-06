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

            schedulesWorksheet.Cells[1, 1] = "ID";
            schedulesWorksheet.Cells[1, 2] = "Name";
            schedulesWorksheet.Cells[2, 1] = "1";
            schedulesWorksheet.Cells[2, 2] = "One";
            schedulesWorksheet.Cells[3, 1] = "2";
            schedulesWorksheet.Cells[3, 2] = "Two";



            schedulesWorkbook.SaveAs("C:\\Users\\Public\\Schedules", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //schedulesWorkBook.Open("C:\\Users\\Public\\Schedules");

            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\Schedules.xls");



            schedulesWorkbook = schedulesApp.Workbooks.Open("C:\\Users\\Public\\Schedules", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            MessageBox.Show(schedulesWorksheet.get_Range("A1", "A1").Value2.ToString());

            schedulesWorkbook.Close(true, misValue, misValue);
            schedulesApp.Quit();

            Marshal.ReleaseComObject(schedulesWorksheet);
            Marshal.ReleaseComObject(schedulesWorkbook);
            Marshal.ReleaseComObject(schedulesApp);

            MessageBox.Show("Excel file created , you can find the file at fuck you I made it");
        }

        private void createDriverSchedule()
        {
            tableLayoutPanel1.Show();
        }

        public void updateTrainSchedule()
        {

        }

        public void updateDriverSchedule()
        {

        }

        public void dispatchTrain()
        {

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

        public void getPos()
        {

        }

        public void getSuggestedSpeed()
        {

        }

        public void setAuthority()
        {

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

        public void breakAntenna()
        {

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
    }
}
