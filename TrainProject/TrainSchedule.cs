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
    public class TrainSchedule
    {

        int shift;
        int timeStart;
        int timeEnd;
        enum days { fri, sat };
        
        TimeSpan timespan;
        DateTime time;
        int breakCount;
        int nextCell;
        TimeSpan addTime;


        public TrainSchedule()
        {
            Excel.Application schedulesApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook schedulesWorkbook;
            Excel.Worksheet redWorksheet;
            Excel.Worksheet greenWorksheet;


            if (schedulesApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            String input = "Please enter train station opening time";
            int timeStart = ShowInputDialog(ref input);
           // MessageBox.Show("You chose " + timeStart + " o'clock");
            input = "Please enter train station closing time";
            int timeEnd = ShowInputDialog(ref input);
            //MessageBox.Show("You chose " + timeEnd + " o'clock");


           

            object misValue = System.Reflection.Missing.Value;

            schedulesWorkbook = schedulesApp.Workbooks.Add(misValue);
            redWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            timespan = new TimeSpan(timeStart, 0, 0);
            time = DateTime.Today.Add(timespan);
            MessageBox.Show("Time chosen is " + time.ToString("hh:mm tt") + "");





            MessageBox.Show("Please wait while the schedule is being generated...");



            redWorksheet.Cells[1, 1] = "Train ID";
            redWorksheet.Cells[1, 2] = time.ToString("hh:mm tt");
            redWorksheet.Cells[2, 1] = "1";
            redWorksheet.Cells[2, 2] = "Dispatch";


            //TimeSpan addTime = new TimeSpan(0, 30, 0);

            //Calculate operating hours
            int operHours = (timeEnd - timeStart);

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

            MessageBox.Show("timeEnd is " + timeEnd + "");
            int count = 1;


            //red line schedule
            for (int i = 3; breakCount <= 8; i = i)
            {
                addTime = new TimeSpan(0, 3, 42);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Shadyside";
                i++;

                addTime = new TimeSpan(0, 3, 18);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Herron Ave";
                i++;

                addTime = new TimeSpan(0, 2, 30);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Swissvale";
                i++;

                addTime = new TimeSpan(0, 2, 48);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Penn Station";
                i++;

                addTime = new TimeSpan(0, 3, 6);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Steel Plaza";
                i++;

                addTime = new TimeSpan(0, 3, 6);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "First Ave";
                i++;

                addTime = new TimeSpan(0, 2, 42);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "Station Square";
                i++;

                addTime = new TimeSpan(0, 3, 18);
                time = time.Add(addTime);
                redWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                redWorksheet.Cells[2, (i)] = "South Hills";
                i++;

                nextCell = i;
                breakCount++;


            }

            addTime = new TimeSpan(0, 5, 0);
            time = time.Add(addTime);
            redWorksheet.Cells[1, (nextCell)] = time.ToString("hh:mm tt");
            redWorksheet.Cells[2, (nextCell)] = "Yard";


            //Excel.Worksheet greenWorksheet = schedulesWorkbook.Sheets[2];
            //schedulesWorkbook.Sheets[2].Activate();
            //greenWorksheet.Cells[1, 1] = "Train ID";


            timespan = new TimeSpan(timeStart, 0, 0);
            time = DateTime.Today.Add(timespan);


            greenWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)schedulesWorkbook.Worksheets.Add
                    (System.Reflection.Missing.Value,
                        schedulesWorkbook.Worksheets[schedulesWorkbook.Worksheets.Count],
                        System.Reflection.Missing.Value,
                        System.Reflection.Missing.Value);
            
            schedulesWorkbook.Sheets[2].Activate();

            greenWorksheet.Cells[1, 1] = "Train ID";
            greenWorksheet.Cells[1, 2] = time.ToString("hh:mm tt");
            greenWorksheet.Cells[2, 1] = "1";
            greenWorksheet.Cells[2, 2] = "Dispatch";

            //green line schedule
            breakCount = 0;
            for (int i = 3; breakCount <= 3; i = i)
            {
                addTime = new TimeSpan(0, 2, 18);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Pioneer";
                i++;

                addTime = new TimeSpan(0, 3, 18);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Edgebrook";
                i++;

                addTime = new TimeSpan(0, 3, 24);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Station";
                i++;

                addTime = new TimeSpan(0, 3, 42);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Whited";
                i++;

                addTime = new TimeSpan(0, 3, 36);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "South Bank";
                i++;

                addTime = new TimeSpan(0, 2, 54);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Central";
                i++;

                addTime = new TimeSpan(0, 3, 0);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Inglewood";
                i++;

                addTime = new TimeSpan(0, 3, 0);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Overbrook";
                i++;

                addTime = new TimeSpan(0, 3, 12);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Glenbury";
                i++;

                addTime = new TimeSpan(0, 3, 30);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Dormont";
                i++;

                addTime = new TimeSpan(0, 3, 12);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Mt. Lebanon";
                i++;

                addTime = new TimeSpan(0, 5, 24);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Poplar";
                i++;

                addTime = new TimeSpan(0, 3, 12);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Castle Shannon";
                i++;

                addTime = new TimeSpan(0, 3, 18);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Dormont";
                i++;

                addTime = new TimeSpan(0, 3, 24);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Glenbury";
                i++;

                addTime = new TimeSpan(0, 3, 6);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Overbrook";
                i++;

                addTime = new TimeSpan(0, 3, 0);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Inglewood";
                i++;

                addTime = new TimeSpan(0, 3, 0);
                time = time.Add(addTime);
                greenWorksheet.Cells[1, (i)] = time.ToString("hh:mm tt");
                greenWorksheet.Cells[2, (i)] = "Central";
                i++;

                nextCell = i;
                breakCount++;


            }



            addTime = new TimeSpan(0, 4, 0);
            time = time.Add(addTime);
            greenWorksheet.Cells[1, (nextCell)] = time.ToString("hh:mm tt");
            greenWorksheet.Cells[2, (nextCell)] = "Yard";





            schedulesWorkbook.SaveAs("C:\\Users\\Public\\TrainSchedule", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //schedulesWorkBook.Open("C:\\Users\\Public\\Schedules");

            System.Diagnostics.Process.Start(@"C:\\Users\\Public\\TrainSchedule.xls");



            schedulesWorkbook = schedulesApp.Workbooks.Open("C:\\Users\\Public\\TrainSchedule", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            redWorksheet = (Excel.Worksheet)schedulesWorkbook.Worksheets.get_Item(1);

            //MessageBox.Show(redWorksheet.get_Range("A1", "A1").Value2.ToString());

            schedulesWorkbook.Close(true, misValue, misValue);
            schedulesApp.Quit();

            Marshal.ReleaseComObject(redWorksheet);
            Marshal.ReleaseComObject(schedulesWorkbook);
            Marshal.ReleaseComObject(schedulesApp);

            MessageBox.Show("Excel file created , you can find the file at C:\\Users\\Public\\TrainSchedule");

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