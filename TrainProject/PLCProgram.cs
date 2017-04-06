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
        private enum SwitchTypes { Loop1, SplitIn, SplitOut, Loop2, BiLoop};
        private Dictionary<int, SwitchTypes> switchTypes;

        public PLCProgram()
        {
            switchTypes = new Dictionary<int, SwitchTypes>();
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

            if (split[1] == "bi")
            {
                //BiLoop
                if (split[2] == "bi" && split[3] == "bi")
                {
                    switchTypes.Add(switchId, SwitchTypes.BiLoop);
                }
                //loop1
                else if (split[2] == "in" && split[3] == "out")
                {
                    switchTypes.Add(switchId, SwitchTypes.Loop1);
                }
                //loop2
                else if (split[2] == "out" && split[3] == "in")
                {
                    switchTypes.Add(switchId, SwitchTypes.Loop2);
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
                    switchTypes.Add(switchId, SwitchTypes.SplitOut);
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
                    switchTypes.Add(switchId, SwitchTypes.SplitIn);
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
            SwitchTypes type = switchTypes[switchId];
            switch (type)
            {

            }
            return -1;
        }

        private int Loop1()
        {
            return -1;
        }

        private int Loop2()
        {
            return -1;
        }

        private int BiLoop()
        {
            return -1;
        }

        private int SplitIn()
        {
            return -1;
        }

        private int SplitOut()
        {
            return -1;
        }
    }
}
