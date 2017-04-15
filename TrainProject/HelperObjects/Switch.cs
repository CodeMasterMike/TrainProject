using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Switch
    {
        public int switchId { get; set; }
        public int? sourceBlockId { get; set; }
        public int? targetBlockId1 { get; set; }
        public int? targetBlockId2 { get; set; }
        public int? sourceBlockId_end { get; set; }
        public int? targetBlockId1_end { get; set; }
        public int? targetBlockId2_end { get; set; }
        public int? currentState { get; set; }
        public bool sourceLight { get; set; }
        public bool t1Light { get; set; }
        public bool t2Light { get; set; }
        public bool sourceActive { get; set; }
        public bool t1Active { get; set; }
        public bool t2Active { get; set; }
        public String infrastructure { get; set; }

        public Switch(int s, int? sb, int? t1, int? t2)
        {
            switchId = s;
            sourceBlockId = sb;
            targetBlockId1 = t1;
            targetBlockId2 = t2;
            currentState = targetBlockId1;
            sourceLight = true;
            t1Light = true;
            t2Light = false;
            sourceActive = true;
            t1Active = true;
            t2Active = true;
        }

        //This method simply changes the switch and returns the current target block the switch is point to
        public int? changeSwitchState()
        {
            if(currentState == targetBlockId1)
            {
                t1Light = false;
                t2Light = true;
                currentState = targetBlockId2;
                return targetBlockId2;
            }
            else
            {
                t2Light = false;
                t1Light = true;
                currentState = targetBlockId1;
                return targetBlockId1;
            }
        }
    }
}
