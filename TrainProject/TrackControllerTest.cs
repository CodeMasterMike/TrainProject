using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    class TrackControllerTest
    {
        public void run()
        {
            TrackController.TrackController tc = new TrackController.TrackController();
            Switch s1 = new Switch(0, 12, 1, 13);
            Switch s2 = new Switch(1, 29, 28, 150);
            Switch s3 = new Switch(2, 50, 57, 151);
            Train t1 = new Train(1, 15.0, 20);
            tc.addNewSwitch(s1);
            tc.addNewSwitch(s2);
            tc.addNewSwitch(s3);
            tc.addNewTrain(t1);
        }
    }
}
