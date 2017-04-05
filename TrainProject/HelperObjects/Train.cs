using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Train
    {
        public int trainId { get; set; }
        public int currBlock { get; set; }
        public int prevBlock { get; set; }
        public double suggestedSpeed { get; set; }
        public int authority { get; set; }
        public int remainingAuthority { get; set; }
        public double actualSpeed { get; set; }

        public Train(int id, double ss, int a)
        {
            trainId = id;
            suggestedSpeed = ss;
            authority = a;
        }
    }
}
