﻿using System;
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
        int shift;
        int timeStart;
        int timeEnd;
        enum days { fri, sat};
        //enum Hours {(3:00),3:30,4:00,4:30,5:00,5:30,6:00,6:30,7:00,7:30,8:00,8:30,9:00,9:30,10:00,10:30,11:00,11:30,12:00,12:30,1:00,1:30,2:00,2:30,3:00,3:30,4:00,4:30,5:00,5:30,6:00,6:30,7:00,7:30,8:00,8:30,9:00,9:30,10:00,10:30,11:00,11:30,12:00,12:30,1:00};
        //enum Hours {3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        //enum fuckyou { 1:00 pm, 2:00 pm , 3:00 pm};


        public DriverSchedule()
        {
            Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();

            if (schedulesApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            String input = "Please enter train station opening time";
            int timeStart = ShowInputDialog(ref input);
            MessageBox.Show("You chose " + timeStart + " o'clock");
            input = "Please enter train station closing time";
            int timeEnd = ShowInputDialog(ref input);
            MessageBox.Show("You chose " + timeEnd + " o'clock");

            //DateTime date1 = new DateTime(2017, 4, 20);



            MessageBox.Show("Please wait while the schedule is being generated...");



            Excel.Workbook schedulesWorkbook;
            Excel.Worksheet schedulesWorksheet;
            object misValue = System.Reflection.Missing.Value;

            schedulesWorkbook = schedulesApp.Workbooks.Add(misValue);
            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            schedulesWorksheet.Cells[1, 1] = "Driver ID";



            int z = 8;
            for (int i = 1; i < z; i++)
            {

                schedulesWorksheet.Cells[(i+1), 1] = "" + i + "";


                shift = 0;

                //Main drivers of a train
                if (i % 2 == 1)
                {
                    

                    for (int j = 2; j < 25; j++)
                    {


                        schedulesWorksheet.Cells[(i + 1), j] = "Drive";

                        if (shift == 8 || shift == 9)
                            schedulesWorksheet.Cells[(i + 1), j] = "Lunch";

                        if (shift == 10)
                            schedulesWorksheet.Cells[(i + 1), j] = "Break";

                        if (shift == 18)
                        {
                            schedulesWorksheet.Cells[(i + 1), j] = "Clock out";
                            break;
                        }

                        shift++;
                    }
                }

                //secondary drivers of same train
                if (i % 2 == 0)
                {
                    for (int j = 2; j < 25; j++)
                    {


                        schedulesWorksheet.Cells[(i + 1), j] = "";

                        if (shift == 8 || shift == 9)
                            schedulesWorksheet.Cells[(i + 1), j] = "Drive";

                        if (shift == 10)
                            schedulesWorksheet.Cells[(i + 1), j] = "Drive";

                        if(shift > 10 && shift <= 17)
                        {
                            schedulesWorksheet.Cells[(i + 1), j] = "Break";
                        }

                        if (shift > 17 && shift < 22)
                        {
                            schedulesWorksheet.Cells[(i + 1), j] = "Drive";

                        }

                        if (shift == 22)
                        {
                            schedulesWorksheet.Cells[(i + 1), j] = "Clock out";
                            break;
                        }

                        

                        shift++;
                    }
                }
            }
            //schedulesWorksheet.Cells[1, 2] = "Name";

            //schedulesWorksheet.Cells[2, 1] = "1";
            //schedulesWorksheet.Cells[2, 2] = "Drive";
            //schedulesWorksheet.Cells[2, 3] = "Drive";
            //schedulesWorksheet.Cells[2, 4] = "Drive";
            //schedulesWorksheet.Cells[2, 5] = "Drive";
            //schedulesWorksheet.Cells[2, 6] = "Drive";
            //schedulesWorksheet.Cells[2, 7] = "Drive";
            //schedulesWorksheet.Cells[2, 8] = "Drive";
            //schedulesWorksheet.Cells[2, 9] = "Drive";
            //schedulesWorksheet.Cells[2, 10] = "Break";
            //schedulesWorksheet.Cells[2, 11] = "Lunch";
            //schedulesWorksheet.Cells[2, 12] = "Lunch";
            //schedulesWorksheet.Cells[2, 13] = "Drive";
            //schedulesWorksheet.Cells[2, 14] = "Drive";
            //schedulesWorksheet.Cells[2, 15] = "Drive";
            //schedulesWorksheet.Cells[2, 16] = "Drive";
            //schedulesWorksheet.Cells[2, 17] = "Drive";
            //schedulesWorksheet.Cells[2, 18] = "Drive";
            //schedulesWorksheet.Cells[2, 19] = "Clock Out";





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

        private static int ShowInputDialog(ref string input)
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
            int value = Convert.ToInt32(textBox.Text);
            return value;

        }
    }



}