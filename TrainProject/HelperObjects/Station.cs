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

        public Station(String n)
        {
            name = n;
            numWaiting = 0;
        }
    }
}
