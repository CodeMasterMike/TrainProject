﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using CTC;
using TrainProject;

namespace TrainProject.Clock
{
    class CustomClock
    {
        private Timer t { get; set; }
        private int interval { get; set; } //this represents the length of whatever is considered a single second, in milliseconds
        private int numIntervals { get; set; }
        private String displayString { get; set; }
        private string hours { get; set; }
        private string minutes { get; set; }
        private string seconds { get; set; }
        private TrainSimulation homepage;

        public CustomClock(TrainSimulation s)
        {
            //Console.WriteLine("Starting");
            interval = 1;
            numIntervals = 0;
            homepage = s;
            t = new Timer(interval);
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

    }
}
