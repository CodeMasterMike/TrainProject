using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class StationBeacon
    {
        public String name { get; set; }
        public short distanceTo { get; set; }
        public bool isPreviousToNext { get; set; }
        public bool isLeft { get; set; }

        public StationBeacon(string n, short dt, bool isPTN)
        {
            name = n;
            distanceTo = dt;
            isPreviousToNext = isPTN;
            isLeft = true;
        }
    }
}
