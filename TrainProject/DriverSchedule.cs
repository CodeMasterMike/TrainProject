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
        int shift;
        int timeStart;
        int timeEnd;
        enum days { fri, sat};
        //Excel.Workbook schedulesWorkbook;
        //Excel.Worksheet schedulesWorksheet;
        TimeSpan timespan;
        DateTime time;
        //enum Hours {(3:00),3:30,4:00,4:30,5:00,5:30,6:00,6:30,7:00,7:30,8:00,8:30,9:00,9:30,10:00,10:30,11:00,11:30,12:00,12:30,1:00,1:30,2:00,2:30,3:00,3:30,4:00,4:30,5:00,5:30,6:00,6:30,7:00,7:30,8:00,8:30,9:00,9:30,10:00,10:30,11:00,11:30,12:00,12:30,1:00};
        //enum Hours {3, 4, 5, 6, 7, 8, 9, 10, 11, 12};



        public struct RealRange
        {
            public int FirstRow;
            public int FirstColumn;
            public int LastRow;
            public int LastColumn;

            public RealRange(int fr, int fc, int lr, int lc)
            {
                FirstRow = fr;
                FirstColumn = fc;
                LastRow = lr;
                LastColumn = lc;
            }
        }



        public DriverSchedule(int Start, int End)         
        {

            timeStart = Start;
            timeEnd = End;
            Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();

            if (schedulesApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            /* String input = "Please enter train station opening time";
             timeStart = ShowInputDialog(ref input);
             //MessageBox.Show("You chose " + timeStart + " o'clock");
             input = "Please enter train station closing time";
             timeEnd = ShowInputDialog(ref input);
             MessageBox.Show("You chose " + timeEnd + " o'clock");*/


           // MessageBox.Show("You chose " + timeEnd + " o'clock");
            timespan = new TimeSpan(timeStart, 0, 0);
             time = DateTime.Today.Add(timespan);
            //MessageBox.Show("Starting time chosen is " + time.ToString("hh:mm tt") + "");
           // MessageBox.Show("Closing time chosen is " + timeEnd + "");




            MessageBox.Show("Please wait while the schedule is being generated...");



            Excel.Workbook schedulesWorkbook;
            Excel.Worksheet schedulesWorksheet;
            object misValue = System.Reflection.Missing.Value;

            schedulesWorkbook = schedulesApp.Workbooks.Add(misValue);
            schedulesWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            schedulesWorksheet.Cells[1, 1] = "Driver ID";
            schedulesWorksheet.Cells[1, 2] = time.ToString("hh:mm tt");
            

            TimeSpan addTime = new TimeSpan(0, 30, 0);
            //time = time.Add(addTime);
            /* int wtf = 4;
             schedulesWorksheet.Cells[1, 3] = check;
             schedulesWorksheet.Cells[1, wtf] = check;
             schedulesWorksheet.Cells[1, (wtf+1)] = time.ToString("hh:mm tt");
             */


            //Create operating hours



            //Calculate operating hours
            int operHours = (timeEnd-timeStart);

            if (operHours < 0)
            {
                timeEnd = 12 - Math.Abs(operHours);
            }

            if (operHours > 0)
            {
                timeEnd = 12 + Math.Abs(operHours);
            }

            if (operHours == 0)
            {
                timeEnd = 12;
            }


            timeEnd = timeEnd * 2;

            //MessageBox.Show("timeEnd is " + timeEnd + "");
            int count = 1;
            for (int i = 3; count <= timeEnd; i++)
            {

                time = time.Add(addTime);
                schedulesWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                count++;
                //timeEnd++;
            }

            //int three = 4;
            //time = time.Add(addTime);
           // MessageBox.Show("next input is " + time.ToString("hh:mm tt") + "");
            
            //WORKS!!!!!!!!!!!!!!!!!!!!!!!
           // schedulesWorksheet.Cells[1, (three)] = time.ToString("hh:mm tt");


            //Excel.Range usedRange = schedulesWorksheet.UsedRange;

            //Excel.Range newRng = schedulesApp.get_Range(schedulesWorksheet.Cells[1, 1], schedulesWorksheet.Cells[1, timeEnd]);

            int row = 1;
            int column = timeEnd;
            // var data = new object[rows, columns];
            // for (var row = 2; row <= rows; row++)
            // {

            var data = new object[row, column];
            /*for (column = 2; column > timeEnd; column++)
                {
                    time = time.Add(addTime);
                    String test = time.ToString("hh:mm tt");
                    MessageBox.Show("" + test + "");
                    //data[row, column] = test;
                    schedulesWorksheet.Cells[1, column] = test;
                //data[row - 1, column - 1] = "Test";
                    //column++;
               
                }*/
            //}

           /* var startCell = (Excel.Range)schedulesWorksheet.Cells[1, 1];
            var endCell = (Excel.Range)schedulesWorksheet.Cells[rows, columns];
            var writeRange = schedulesWorksheet.Range[startCell, endCell];

            writeRange.Value2 = data;*/

            /* foreach (var row in schedulesWorksheet.newRng)
             {
                 // either put your logic here, 
                 // or look at columns if you prefer 

                 foreach (var cell in row.Columns)
                 {
                    // do something with cells 
                 } 

             }*/



            //Create Driver Schedule
            int z = 4;
                                    for (int i = 1; i <= z; i++)
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

    /*public Range RealUsedRange()
    {
        // ...
        return schedulesWorksheet.get_Range(xlWorkSheet.Cells[FirstRow, FirstColumn],
                                     xlWorkSheet.Cells[LastRow, LastColumn]);
    }*/



}