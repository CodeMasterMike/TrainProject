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
        }

        //This method simply changes the switch and returns the current target block the switch is point to
        public int? changeSwitchState()
        {
            if(currentState == targetBlockId1)
            {
                currentState = targetBlockId2;
                return targetBlockId2;
            }
            else
            {
                currentState = targetBlockId1;
                return targetBlockId1;
            }
        }

        //given the occupancy of the three blocks, the switch determines whether it should change or not
        //this boolean expression should be changeable by the PLC program!!!! later
        //changing to directions! positive number means train heading towards switch from that direction
        //this function assumes a unidirectional source, t1, and t2 but can easily be extrapolated to bidirectional given 
        public int? determineSwitchState(int s, int t1, int t2)
        {
            //train approaching from switch source
            if (s > 0)
            {
                sourceLight = true;
                t1Light = true;
                t2Light = false;
                if (currentState != targetBlockId1)
                {
                    changeSwitchState();
                }
                return currentState;
            }
            else
            {
                //if train approaching from t2
                if (t2 > 0)
                {
                    sourceLight = false;
                    t1Light = false;
                    t2Light = true;
                    if(currentState != targetBlockId2)
                    {
                        changeSwitchState();
                    }
                    return currentState;
                }
            }
            return -1;
        }
    }
}
