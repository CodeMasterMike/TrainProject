using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    class Switch
    {
        int switchId { get; set; }
        int sourceBlockId { get; set; }
        int targetBlockId1 { get; set; }
        int targetBlockId2 { get; set; }
        int currentState { get; set; }

        public Switch(int s, int sb, int t1, int t2)
        {
            switchId = s;
            sourceBlockId = sb;
            targetBlockId1 = t1;
            targetBlockId2 = t2;
            currentState = targetBlockId1;
        }
    }
}
