//This is the track controller module that actually controls the track
//This class is the main point of communication with the system. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainProject;

namespace TrainProject
{
    public class TrackController
    {
        public int controllerId;
        //public int startBlock;
        //public int endBlock;
        public List<Block> blocks; //this represents the occupied blocks
        public List<Train> trains;
        public List<Switch> switches;
        public List<Crossing> crossings;
        public String controllerName; //used for finding things on screen
        //need to declare an array of blocks that this controller will keep track of
        //maybe an array of switches too
        public void testMethod()
        {
            Console.Write("testmethod\n");
        }

        public Boolean updateBlockOccupancy(int blockId)
        {
            return false;
        }

        public TrackController(int id, String name)
        {
            controllerId = id;
            controllerName = name;
            //startBlock = sb
            //sB = startBlock;
            //eB = endBlock;
            blocks = new List<Block>();
            trains = new List<Train>();
            switches = new List<Switch>();
            crossings = new List<Crossing>();
        }

        public Boolean dispatchNewTrain(int trainId, int speed, int authority)
        {
            return true;
        }

        public void monitorSwitches()
        {
            foreach (Switch s in switches)
            {
                int a = 0, b = 0, c = 0;
                Block src = blocks.Find(x => x.blockNum == s.sourceBlockId);
                Block t1 = (blocks.Find(x => x.blockNum == s.targetBlockId1));
                Block t2 = (blocks.Find(x => x.blockNum == s.targetBlockId2));
                if (src != null)
                {
                    a = src.direction;
                }
                if (t1 != null)
                {
                    b = t1.direction;
                }
                if(t2 != null)
                {
                    c = t2.direction;
                }
                if (a == -1 && b == -1 && c == -1)
                {
                    return;
                }
                //if target block 1 is occupied
                Console.WriteLine("Switch " + s.switchId);
                Console.WriteLine(TrackControllerWindow.plc.determineSwitchState(s.switchId, a, b, c));
            }
        }

        public void monitorCrossings()
        {
            foreach(Crossing c in crossings)
            {
                Block b = blocks.Find(x => x.blockNum == c.blockId);
                if (b != null)
                {
                    c.activated = true;
                }
                else
                {
                    c.activated = false;
                }
            }
        }

        public void addNewCrossing(Crossing c)
        {
            crossings.Add(c);
        }

        public void addNewSwitch(Switch s)
        {
            switches.Add(s);
        }

        public void addNewTrain(Train t)
        {
            trains.Add(t);
        }

        public void addNewBlock(Block b)
        {
            blocks.Add(b);
        }

        public List<Train> getTrains()
        {
            return trains;
        }

        public List<Block> getBlocks()
        {
            return blocks;
        }

        public List<Switch> getSwitches()
        {
            return switches;
        }

        public List<Crossing> getCrossings()
        {
            return crossings;
        }

        public int? changeSwitchState(int id)
        {
            return switches.Find(x => x.switchId == id).changeSwitchState();
        }

        public bool toggleCrossing(int id)
        {
            crossings.Find(x => x.blockId == id).activated ^= true;
            return crossings.Find(x => x.blockId == id).activated;
        }
    }
}
