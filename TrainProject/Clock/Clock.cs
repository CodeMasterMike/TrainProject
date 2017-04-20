using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using TrainProject;
using TrainControllerProject;

namespace TrainProject.Clock
{
    class CustomClock
    {
        private System.Timers.Timer t { get; set; }
        private int interval { get; set; } //this represents the length of whatever is considered a single second, in milliseconds
        private int numIntervals { get; set; }
        private String displayString { get; set; }
        private string hours { get; set; }
        private string minutes { get; set; }
        private string seconds { get; set; }
        private TrainSimulation homepage;
        private int startTime;

        public CustomClock(TrainSimulation s)
        {
            Console.WriteLine("Starting System Clock");
            interval = 1000; //starting in real time, 1000ms
            String input = "Please enter train station opening time";
            startTime = ShowInputDialog(ref input);
            numIntervals = (startTime-1)*3578; //8 AM because 0000 is 1AM :)
            homepage = s;
            t = new System.Timers.Timer(interval);
            t.Elapsed += HandleIntervalElapsed;
            t.Start();
        }

        private void HandleIntervalElapsed(object sender, ElapsedEventArgs e)
        {
            //Console.WriteLine("Interval passed");
            numIntervals += 1;
            if(numIntervals > 24 * 3600)
            {
                numIntervals = 0;
            }

            hours = (((numIntervals / 3600) % 12) + 1).ToString();
            if (hours.Length < 2)
                hours = "0" + hours;            
            minutes = (numIntervals / 60 % 60).ToString();
            if (minutes.Length < 2)
                minutes = "0" + minutes;
            seconds = (numIntervals % 60).ToString();
            if (seconds.Length < 2)
                seconds = "0" + seconds;

            displayString = hours + ":" + minutes + ":" + seconds;
            if (numIntervals > 23 * 3600)
            {
                displayString += " AM";
            }
            else if (numIntervals > 11 * 3600)
            {
                displayString += " PM";
            }
            else
            {
                displayString += " AM";
            }


            //trigger module events here
            homepage.updateTime(displayString);
        }

        public void changeInterval(int ms)
        {
            interval = ms;
            t.Interval = interval;
            Console.WriteLine("Interval updated to "+interval+"!");
        }

        public void resumeClock()
        {
            t.Stop();
            Console.WriteLine("Stopped...");
        }

        public void pauseClock()
        {
            t.Start();
            Console.WriteLine("Started...");
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
