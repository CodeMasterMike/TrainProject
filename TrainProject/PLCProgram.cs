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
        private enum SwitchTypes { Loop1, SplitIn, SplitOut, Loop2, BiLoop };
        private Dictionary<Switch, SwitchTypes> switchTypes;

        public PLCProgram()
        {
            switchTypes = new Dictionary<Switch, SwitchTypes>();
            switches = new List<Switch>();
            closedBlocks = new List<Block>();
        }

        //id is switch id
        //which branch determines whether source, t1, or t2 is to be gotten
        public int? getSwitchDirection(int id, int whichBranch)
        {
            Switch sw = switches.Find(x => x.switchId == id);
            SwitchTypes type = switchTypes[sw];
            if (whichBranch > 2 || whichBranch < 0)
            {
                return null;
            }
            switch (type)
            {
                case SwitchTypes.Loop1:
                    if (whichBranch == 0)
                    {
                        return 0;
                    }
                    else if (whichBranch == 1)
                    {
                        return -1;
                    }
                    else if (whichBranch == 2)
                    {
                        return 1;
                    }
                    break;
                case SwitchTypes.Loop2:
                    if (whichBranch == 0)
                    {
                        return 0;
                    }
                    else if (whichBranch == 1)
                    {
                        return 1;
                    }
                    else if (whichBranch == 2)
                    {
                        return -1;
                    }
                    break;
                case SwitchTypes.BiLoop:
                    if (whichBranch == 0)
                    {
                        return 0;
                    }
                    else if (whichBranch == 1)
                    {
                        return 0;
                    }
                    else if (whichBranch == 2)
                    {
                        return 0;
                    }
                    break;
                case SwitchTypes.SplitIn:
                    if (whichBranch == 0)
                    {
                        return -1;
                    }
                    else if (whichBranch == 1)
                    {
                        return 1;
                    }
                    else if (whichBranch == 2)
                    {
                        return 1;
                    }
                    break;
                case SwitchTypes.SplitOut:
                    if (whichBranch == 0)
                    {
                        return 1;
                    }
                    else if (whichBranch == 1)
                    {
                        return -1;
                    }
                    else if (whichBranch == 2)
                    {
                        return -1;
                    }
                    break;
                default:
                    return null;
            }
            return null;
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
            if (split.Length != 4)
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
        public int? determineSwitchState(int switchId, int? s, int? t1, int? t2)
        {
            Switch sw = switches.Find(x => x.switchId == switchId);
            SwitchTypes type = switchTypes[sw];
            switch (type)
            {
                case SwitchTypes.Loop1:
                    return Loop1(sw, s, t1, t2);
                case SwitchTypes.Loop2:
                    return Loop2(sw, s, t1, t2);
                case SwitchTypes.BiLoop:
                    return BiLoop(sw, s, t1, t2);
                case SwitchTypes.SplitIn:
                    return SplitIn(sw, s, t1, t2);
                case SwitchTypes.SplitOut:
                    return SplitOut(sw, s, t1, t2);
                default:
                    return -1;
            }
        }

        //Loop1 has a bidirectional source, going into t1 and back in from t2
        private int? Loop1(Switch sw, int? s, int? t1, int? t2)
        {
            if (!sw.sourceActive || !sw.t1Active || !sw.t2Active)
            {
                sw.t1Light = false;
                sw.t2Light = false;
                sw.sourceLight = false;
                return sw.currentState;
            }
            //t1Light should always be red because it is a 1-way track going away from system
            sw.t1Light = false;
            //train approaches from source
            if (s > 0 && t2 == 0)
            {
                //sourceLightTrue
                sw.sourceLight = true;
                //t2LightFalse
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            else if (t2 > 0 && s == 0)
            {
                //sourceLightFalse
                sw.sourceLight = false;
                sw.t2Light = true;
                //t2LightTrue
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
            }
            else
            {
                //sourceLightTrue
                sw.sourceLight = true;
                //t2LightFalse
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            return sw.currentState;
        }

        //Loop2 has a bidirectional source, going into t2 and back in from t1
        private int? Loop2(Switch sw, int? s, int? t1, int? t2)
        {
            if (!sw.sourceActive || !sw.t1Active || !sw.t2Active)
            {
                sw.t1Light = false;
                sw.t2Light = false;
                sw.sourceLight = false;
                return sw.currentState;
            }
            sw.t2Light = false;
            //train approaches from source
            if (s > 0 && t1 == 0)
            {
                sw.sourceLight = true;
                sw.t1Light = false;
                //sourceLightTrue
                //t1LightFalse
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
            }
            else if (t1 > 0 && s == 0)
            {
                sw.sourceLight = false;
                sw.t1Light = true;
                //sourceLightFalse
                //t1LightTrue
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            return sw.currentState;
        }

        private int BiLoop(Switch sw, int? s, int? t1, int? t2)
        {
            if (!sw.sourceActive)
            {
                sw.sourceLight = false;
                sw.t1Light = false;
                sw.t2Light = false;
                return (int)sw.currentState;
            }
            else if (!sw.t1Active)
            {
                sw.sourceLight = true;
                sw.t1Light = false;
                sw.t2Light = true;
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
                return (int)sw.currentState;
            }
            else if (!sw.t2Active)
            {
                sw.sourceLight = true;
                sw.t1Light = true;
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
                return (int)sw.currentState;
            }
            //if train approaches switch
            if (s > 0)
            {
                //if train approaches from target 1, and another train is leaving switch
                if (t1 > 0 && t2 < 0)
                {
                    sw.sourceLight = true;
                    sw.t1Light = false;
                    sw.t2Light = false;
                    if (sw.currentState != sw.targetBlockId2)
                    {
                        sw.changeSwitchState();
                    }
                }
                else if (t1 < 0 && t2 > 0)
                {
                    sw.sourceLight = true;
                    sw.t2Light = false;
                    sw.t1Light = false;
                    if (sw.currentState != sw.targetBlockId1)
                    {
                        sw.changeSwitchState();
                    }
                }
                else if (t1 > 0)
                {
                    sw.sourceLight = true;
                    sw.t1Light = false;
                    sw.t2Light = false;
                    if (sw.currentState != sw.targetBlockId2)
                    {
                        sw.changeSwitchState();
                    }
                }
                else if (t2 > 0)
                {
                    sw.sourceLight = true;
                    sw.t2Light = false;
                    sw.t1Light = false;
                    if (sw.currentState != sw.targetBlockId1)
                    {
                        sw.changeSwitchState();
                    }
                }
                //else, the switch is in safe state, it is up to track engineer to route train
                else
                {

                }
            }
            else if (t1 > 0)
            {
                sw.sourceLight = false;
                sw.t1Light = true;
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            else if (t2 > 0)
            {
                sw.sourceLight = false;
                sw.t1Light = false;
                sw.t2Light = true;
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
            }
            return (int)sw.currentState;
        }

        private int SplitIn(Switch sw, int? s, int? t1, int? t2)
        {
            sw.sourceLight = false;
            if (!sw.sourceActive)
            {
                sw.t1Light = false;
                sw.t2Light = false;
                return (int)sw.currentState;
            }
            else if (!sw.t1Active)
            {
                sw.t1Light = false;
                sw.t2Light = true;
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
                return (int)sw.currentState;
            }
            else if (!sw.t2Active)
            {
                sw.t1Light = true;
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
                return (int)sw.currentState;
            }

            if (s > 0)
            {
                return -1;
            }

            //need to decide which gets precedence, will go with t1 by default
            if (t1 > 0 && t2 > 0)
            {
                sw.t1Light = true;
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            else if (t1 > 0)
            {
                sw.t1Light = true;
                sw.t2Light = false;
                if (sw.currentState != sw.targetBlockId1)
                {
                    sw.changeSwitchState();
                }
            }
            else if (t2 > 0)
            {
                sw.t1Light = false;
                sw.t2Light = true;
                if (sw.currentState != sw.targetBlockId2)
                {
                    sw.changeSwitchState();
                }
            }
            return (int)sw.currentState;
        }

        private int SplitOut(Switch sw, int? s, int? t1, int? t2)
        {
            if (sw.sourceActive)
            {
                sw.sourceLight = false;
                return (int)sw.currentState;
            }
            //in terms of safety, this switch is usually in state
            if (s > 0)
            {

            }
            return (int)sw.currentState;
        }
    }
}