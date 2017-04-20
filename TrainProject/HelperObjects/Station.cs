using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Station
    {
        public String name { get; set; }
        public int numWaiting { get; set; }
        public int maxWaiting { get; set; }
        Random rnd { get; set; }

        public Station(String n)
        {
            name = n;
            numWaiting = 0;
            maxWaiting = 75;
            rnd = new Random();
        }

        public int getWaiting()
        {
            if(numWaiting < 10)
            {
                int maxRand = 75 - numWaiting;
                int numNewPassengers = rnd.Next(maxRand);
                numWaiting = numWaiting + numNewPassengers;
            }
            return numWaiting;
        }
    }
}
