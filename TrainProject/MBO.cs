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

namespace MBO_UI
{
    public partial class MBO : Form
    {
        public MBO()
        {
            InitializeComponent();
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


            Excel.Workbook schedulesWorkBook;
            Excel.Worksheet schedulesWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            schedulesWorkBook = schedulesApp.Workbooks.Add(misValue);
            schedulesWorkSheet = (Excel.Worksheet)schedulesWorkBook.Worksheets.get_Item(1);

            schedulesWorkSheet.Cells[1, 1] = "ID";
            schedulesWorkSheet.Cells[1, 2] = "Name";
            schedulesWorkSheet.Cells[2, 1] = "1";
            schedulesWorkSheet.Cells[2, 2] = "One";
            schedulesWorkSheet.Cells[3, 1] = "2";
            schedulesWorkSheet.Cells[3, 2] = "Two";



            schedulesWorkBook.SaveAs("C:\\Users\\Alejandro\\Documents\\TrainProject\\TrainProject\\MBOSchedules-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            schedulesWorkBook.Close(true, misValue, misValue);
            schedulesApp.Quit();

            Marshal.ReleaseComObject(schedulesWorkSheet);
            Marshal.ReleaseComObject(schedulesWorkBook);
            Marshal.ReleaseComObject(schedulesApp);

            MessageBox.Show("Excel file created , you can find the file at fuck you I made it");
        }

        private void createDriverSchedule()
        {
            ShowDialog();
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
