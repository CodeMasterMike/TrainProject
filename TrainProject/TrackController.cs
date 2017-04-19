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

        public void checkSafety(Switch s)
        {
            foreach (Train t in TrackControllerModule.trainTrackings)
            {
                if (trainHeadingTowardsSwitch(t, s, 0) > 0 && s.sourceActive == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
                if (trainHeadingTowardsSwitch(t, s, 1) > 0 && s.t1Active == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
                if (trainHeadingTowardsSwitch(t, s, 2) > 0 && s.t2Active == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
            }
        }

        public int? trainHeadingTowardsSwitch(Train t, Switch s, int whichBranch)
        {
            if (s.switchId == 3)
            {

            }
            if (t.direction == 0 || t.direction == null)
            {
                //Console.WriteLine("Error. Train has no direction");
            }
            switch (whichBranch)
            {
                case 0:
                    //if train is contained in source branch
                    if (checkWithinRange(t.currBlock, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                    {
                        int srcDir = (int)TrackControllerWindow.plc.getSwitchDirection(s.switchId, 0);
                        if (srcDir > 0 || srcDir < 0)
                        {
                            return srcDir;
                        }
                        else if (srcDir == 0)
                        {
                            if (t.direction > 0 && s.sourceBlockId > s.sourceBlockId_end)
                            {
                                return 1;
                            }
                            else if (t.direction < 0 && s.sourceBlockId < s.sourceBlockId_end)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    break;
                case 1:
                    //if train is contained in source branch
                    if (checkWithinRange(t.currBlock, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                    {
                        int t1Dir = (int)TrackControllerWindow.plc.getSwitchDirection(s.switchId, 1);
                        if (t1Dir > 0 || t1Dir < 0)
                        {
                            return t1Dir;
                        }
                        else if (t1Dir == 0)
                        {
                            if (t.direction > 0 && s.targetBlockId1 > s.targetBlockId1_end)
                            {
                                return 1;
                            }
                            else if (t.direction < 0 && s.targetBlockId1 < s.targetBlockId1_end)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    break;
                case 2:
                    if (checkWithinRange(t.currBlock, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                    {
                        int t2Dir = (int)TrackControllerWindow.plc.getSwitchDirection(s.switchId, 1);
                        if (t2Dir > 0 || t2Dir < 0)
                        {
                            return t2Dir;
                        }
                        else if (t2Dir == 0)
                        {
                            if (t.direction > 0 && s.targetBlockId2 > s.targetBlockId2_end)
                            {
                                return 1;
                            }
                            else if (t.direction < 0 && s.targetBlockId2 < s.targetBlockId2_end)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        public Boolean checkWithinRange(int numToCheck, int bound1, int bound2)
        {
            if (bound1 < bound2)
            {
                if (numToCheck >= bound1 && numToCheck <= bound2)
                {
                    return true;
                }
            }
            else if (bound1 > bound2)
            {
                if (numToCheck <= bound1 && numToCheck >= bound2)
                {
                    return true;
                }
            }
            return false;
        }

        //send a list of Blocks
        public void testController(List<Block> blockOccupancies) 
        {
            foreach (Switch s in switches)
            {
                int a = 0, b = 0, c = 0;
                Block src = blockOccupancies.Find(x => x.blockNum == s.sourceBlockId);
                Block t1 = (blockOccupancies.Find(x => x.blockNum == s.targetBlockId1));
                Block t2 = (blockOccupancies.Find(x => x.blockNum == s.targetBlockId2));
                if (src != null)
                {
                    a = src.direction;
                }
                if (t1 != null)
                {
                    b = t1.direction;
                }
                if (t2 != null)
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

            foreach (Crossing c in crossings)
            {
                Block b = blockOccupancies.Find(x => x.blockNum == c.blockId);
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


        //public void monitorSwitches()
        //{
        //    foreach (Switch s in switches)
        //    {
        //        int a = 0, b = 0, c = 0;
        //        Block src = blocks.Find(x => x.blockNum == s.sourceBlockId);
        //        Block t1 = (blocks.Find(x => x.blockNum == s.targetBlockId1));
        //        Block t2 = (blocks.Find(x => x.blockNum == s.targetBlockId2));
        //        if (src != null)
        //        {
        //            a = src.direction;
        //        }
        //        if (t1 != null)
        //        {
        //            b = t1.direction;
        //        }
        //        if(t2 != null)
        //        {
        //            c = t2.direction;
        //        }
        //        if (a == -1 && b == -1 && c == -1)
        //        {
        //            return;
        //        }
        //        //if target block 1 is occupied
        //        Console.WriteLine("Switch " + s.switchId);
        //        Console.WriteLine(TrackControllerWindow.plc.determineSwitchState(s.switchId, a, b, c));
        //    }
        //}

        //public void monitorCrossings()
        //{
            
        //}

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
