using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class PLCProgram
    {
        private List<Switch> switches;
        private List<Block> closedBlocks;
        private enum SwitchTypes { Loop1, SplitIn, SplitOut, Loop2, BiLoop};
        private Dictionary<Switch, SwitchTypes> switchTypes;

        public PLCProgram()
        {
            switchTypes = new Dictionary<Switch, SwitchTypes>();
            switches = new List<Switch>();
            closedBlocks = new List<Block>();
        }

        public void addSwitch(Switch s)
        {
            switches.Add(s);
        }

        public Boolean newPlcProgram(String plcText)
        {
            return false;
        }

        public Boolean handleLine(String plcLine)
        {
            String[] split = plcLine.Split(',');
            if(split.Length != 4)
            {
                return false;
            }
            int switchId = Convert.ToInt32(split[0]);
            Switch s = switches.Find(x => x.switchId == switchId);

            if (split[1] == "bi")
            {
                //BiLoop
                if (split[2] == "bi" && split[3] == "bi")
                {
                    switchTypes.Add(s, SwitchTypes.BiLoop);
                }
                //loop1
                else if (split[2] == "in" && split[3] == "out")
                {
                    switchTypes.Add(s, SwitchTypes.Loop1);
                }
                //loop2
                else if (split[2] == "out" && split[3] == "in")
                {
                    switchTypes.Add(s, SwitchTypes.Loop2);
                }
                else
                {
                    return false;
                }
            }
            else if (split[1] == "in")
            {
                //split in
                if (split[2] == "out" && split[3] == "out")
                {
                    switchTypes.Add(s, SwitchTypes.SplitOut);
                }
                else
                {
                    return false;
                }
            }
            else if (split[1] == "out")
            {
                //split in
                if (split[2] == "in" && split[3] == "in")
                {
                    switchTypes.Add(s, SwitchTypes.SplitIn);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public List<int> runProgram(List<Block> blockOccupancies)
        {
            List<int> switchIds = new List<int>();
            return switchIds;
        }

        //given the occupancy of the three blocks, the switch determines whether it should change or not
        //this boolean expression should be changeable by the PLC program!!!! later
        //changing to directions! positive number means train heading towards switch from that direction
        //this function assumes a unidirectional source, t1, and t2 but can easily be extrapolated to bidirectional given 
        public int determineSwitchState(int switchId, int s, int t1, int t2)
        {
            Switch sw = switches.Find(x => x.switchId == switchId);
            SwitchTypes type = switchTypes[sw];
            switch (type)
            {
                case SwitchTypes.Loop1:
                    break;
                case SwitchTypes.Loop2:
                    break;
                case SwitchTypes.BiLoop:
                    break;
                case SwitchTypes.SplitIn:
                    break;
                case SwitchTypes.SplitOut:
                    break;
                default:
                    return -1;
            }
            return -1;
        }

        //Loop1 has a bidirectional source, going into t1 and back in from t2
        private int? Loop1(Switch sw, int s, int t1, int t2)
        {
            //train approaches from source
            if(s > 0 && t2 == 0)
            {
                //sourceLightTrue
                //t2LightFalse
                if(sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
                return sw.currentState;
            }
            else if (t2 > 0 && s==0)
            {
                //sourceLightFalse
                //t2LightTrue
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
                return sw.currentState;
            }
            return -1;
        }

        //Loop2 has a bidirectional source, going into t2 and back in from t1
        private int? Loop2(Switch sw, int s, int t1, int t2)
        {
            //train approaches from source
            if (s > 0 && t1 == 0)
            {
                //sourceLightTrue
                //t1LightFalse
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
                return sw.currentState;
            }
            else if (t1 > 0 && s == 0)
            {
                //sourceLightFalse
                //t1LightTrue
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
                return sw.currentState;
            }
            return -1;
        }

        private int BiLoop(Switch sw, int s, int t1, int t2)
        {
            
            if(s > 0)
            {
                if(t1 > 0 && t2 < 0)
                {

                }
                else if (t1 < 0 && t2 > 0)
                {

                }
                else if (t1 > 0)
                {

                }
                else if (t2 > 0)
                {

                }
                else
                {

                }
            }
            else if (t1 > 0)
            {
                
            }
            else if (t2 > 0)
            {

            }
            return -1;
        }

        private int SplitIn(Switch sw, int s, int t1, int t2)
        {
            if (t1 > 0 && t2 > 0)
            {

            }
            else if (t1 > 0)
            {

            }
            else if (t2 > 0)
            {

            }
            return -1;
        }

        private int SplitOut(Switch sw, int s, int t1, int t2)
        {
            if(s > 0)
            {

            }
            return -1;
        }
    }
}
