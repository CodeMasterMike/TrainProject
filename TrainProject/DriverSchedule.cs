using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProject;
using TrainProject.HelperObjects;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace TrainProject
{
    public class DriverSchedule
    {

        public DriverSchedule()
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

            schedulesWorksheet.Cells[1, 1] = "Driver ID";
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
            schedulesWorksheet.Cells[2, 10] = "Break";
            schedulesWorksheet.Cells[2, 11] = "Lunch";
            schedulesWorksheet.Cells[2, 12] = "Lunch";
            schedulesWorksheet.Cells[2, 13] = "Drive";
            schedulesWorksheet.Cells[2, 14] = "Drive";
            schedulesWorksheet.Cells[2, 15] = "Drive";
            schedulesWorksheet.Cells[2, 16] = "Drive";
            schedulesWorksheet.Cells[2, 17] = "Drive";
            schedulesWorksheet.Cells[2, 18] = "Drive";
            schedulesWorksheet.Cells[2, 19] = "Clock Out";



            schedulesWorksheet.Cells[3, 1] = "2";
            schedulesWorksheet.Cells[3, 10] = "Drive";
            schedulesWorksheet.Cells[3, 11] = "Drive";
            schedulesWorksheet.Cells[3, 12] = "Drive";
            schedulesWorksheet.Cells[3, 13] = "Lunch";
            schedulesWorksheet.Cells[3, 14] = "Lunch";
            schedulesWorksheet.Cells[3, 15] = "Break";
            schedulesWorksheet.Cells[3, 16] = "Break";
            schedulesWorksheet.Cells[3, 17] = "Break";
            schedulesWorksheet.Cells[3, 18] = "Break";
            schedulesWorksheet.Cells[3, 19] = "Drive";
            schedulesWorksheet.Cells[3, 20] = "Drive";
            schedulesWorksheet.Cells[3, 21] = "Drive";
            schedulesWorksheet.Cells[3, 22] = "Drive";
            schedulesWorksheet.Cells[3, 23] = "Drive";
            schedulesWorksheet.Cells[3, 20] = "Drive";
            schedulesWorksheet.Cells[3, 21] = "Drive";
            schedulesWorksheet.Cells[3, 22] = "Drive";
            schedulesWorksheet.Cells[3, 23] = "Drive";
            schedulesWorksheet.Cells[3, 24] = "Drive";


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







            schedulesWorkbook.SaveAs("C:\\Users\\Public\\DriverSchedule", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //schedulesWorkBook.Open("C:\\Users\\Public\\Schedules");

            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\DriverSchedule.xls");



            schedulesWorkbook = schedulesApp.Workbooks.Open("C:\\Users\\Public\\DriverSchedule", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            //MessageBox.Show(schedulesWorksheet.get_Range("A1", "A1").Value2.ToString());

            schedulesWorkbook.Close(true, misValue, misValue);
            schedulesApp.Quit();

            Marshal.ReleaseComObject(schedulesWorksheet);
            Marshal.ReleaseComObject(schedulesWorkbook);
            Marshal.ReleaseComObject(schedulesApp);

            MessageBox.Show("Excel file created , you can find the file at C:\\Users\\Public\\DriverSchedule.xls");

        }

        public DriverSchedule(int passengers, int drivers)
        {

        }
        
        public void viewDriverSchedule()
        {
            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\DriverSchedule.xls");
        }

    }



}