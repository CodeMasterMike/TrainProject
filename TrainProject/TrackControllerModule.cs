using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Layout_UI;
using TrainModelProject;


namespace TrainProject
{
    //handles initializing controllers, delegating speed requests
    public class TrackControllerModule
    {
 
        public static TrackController greenLineCtrl1 = new TrackController(0, "green1");
        public static TrackController greenLineCtrl2 = new TrackController(1, "green2");
        public static TrackController redLineCtrl1 = new TrackController(2, "red1");
        public static TrackController redLineCtrl2 = new TrackController(3, "red2");
        public static List<TrainModel> activeTrains = new List<TrainModel>();
        public static List<Train> trainTrackings = new List<Train>();
        public static List<TrackController> activeControllers = new List<TrackController>();

        public void updateSpeedAndAuthority(int trainId, Double speed, int authority)
        {
            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(trainId, speed, authority);
        }

        public static void closeBlock(int blockId)
        {
            foreach (TrackController ctrl in activeControllers)
            {
                foreach (Switch s in ctrl.getSwitches())
                {
                    if (checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                    {
                        s.sourceActive = false;
                    }
                    if (checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                    {
                        s.t1Active = false;
                    }
                    if (checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                    {
                        s.t2Active = false;
                    }
                    foreach (Train t in trainTrackings)
                    {
                        if (checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                        }
                        if (checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                        }
                        if (checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                        }
                    }
                }
                
            }
        }

        //new function
        public void updateBlockOccupancy(Block blk, Boolean occupied)
        {
            if(blk.isFromYard || blk.isToYard)
            {

            }
            foreach (Train t in trainTrackings)
            {
                //increasing in block id
                if(t.currBlock == blk.blockId + 1)
                {
                    t.direction = 1;
                }

                //decreasing in block id
                else if (t.currBlock == blk.blockId - 1)
                {
                    t.direction = -1;
                }
                else //check switches to see if train just traveled over switch
                {
                    foreach (TrackController ctrl in activeControllers)
                    {
                        foreach (Switch s in ctrl.switches)
                        {
                            if(s.sourceBlockId == blk.blockId)
                            {

                            }
                            else if (s.targetBlockId1 == blk.blockId)
                            {

                            }
                            else if (s.targetBlockId2 == blk.blockId)
                            {

                            }
                            int? srcDir, t1Dir, t2Dir;
                            srcDir = trainHeadingTowardsSwitch(t, s, 0);
                            t1Dir = trainHeadingTowardsSwitch(t, s, 1);
                            t2Dir = trainHeadingTowardsSwitch(t, s, 2);
                            int switchState = (int)TrackControllerWindow.plc.determineSwitchState(s.switchId, srcDir, t1Dir, t2Dir);
                        }
                        foreach (Crossing c in ctrl.crossings)
                        {
                            if(c.blockId == blk.blockId && occupied)
                            {
                                c.activated = true;
                            }
                            else if (c.blockId == blk.blockId && !occupied)
                            {
                                c.activated = false;
                            }
                        }
                    }
                }
            }//end foreach
            TrainSimulation.trackControllerWindow.updateSwitches();
            TrainSimulation.trackControllerWindow.updateCrossings();
        }

        public static void openBlock(int blockId)
        {
            foreach (TrackController ctrl in activeControllers)
            {
                foreach (Switch s in ctrl.getSwitches())
                {
                    if (checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                    {
                        s.sourceActive = true;
                    }
                    if (checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                    {
                        s.t1Active = true;
                    }
                    if (checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                    {
                        s.t2Active = true;
                    }
                    foreach (Train t in trainTrackings)
                    {
                        if (checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                        }
                        if (checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                        }
                        if (checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                        {
                            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                        }
                    }
                }
            }
        }

        public static void causeFailure(int blockId)
        {
            closeBlock(blockId);
            //TrainSimulation.mainOffice.causeFailure(blockId);
            
        }

        public void dispatchNewTrain(int trainId, TrainModel newTrain, double speed, int authority)
        {
            Console.WriteLine("dispatching train!!!!!");
            Train newT = new Train(newTrain.getTrainId(), speed, authority);
            newT.currBlock = newTrain.getCurrBlock();
            trainTrackings.Add(newT);
            activeTrains.Add(newTrain);
            TrainSimulation.trackModelWindow.dispatchTrain(trainId, newTrain, speed, authority);
            TrainSimulation.trackControllerWindow.updateTrains();
        }

        //public static void updateBlockOccupancy(int blockId, Boolean occupied)
        //{
        //    Console.WriteLine("updating block occupancy: " + blockId + " - " + occupied);
        //    Boolean found = false;
        //    foreach(TrackController ctrl in activeControllers)
        //    {
        //        //block hasnt been found yet
        //        if (!found)
        //        {
        //            Block newBlock;
        //            foreach (Block b in ctrl.getBlocks())
        //            {
        //                if (b.blockId == blockId + 1)
        //                {
        //                    foreach(Train t in trainTrackings)
        //                    {
        //                        if(t.currBlock == blockId - 1)
        //                        {
        //                            t.currBlock = blockId;
        //                            t.direction = 1;
        //                        }
        //                    }
        //                    newBlock = new Block(blockId, 1);
        //                    ctrl.addNewBlock(newBlock);
        //                    found = true;
        //                }
        //                else if (b.blockId == blockId - 1)
        //                {
        //                    foreach (Train t in trainTrackings)
        //                    {
        //                        if (t.currBlock == blockId + 1)
        //                        {
        //                            t.currBlock = blockId;
        //                            t.direction = -1;
        //                        }
        //                    }
        //                    newBlock = new Block(blockId, -1);
        //                    ctrl.addNewBlock(newBlock);
        //                    found = true;
        //                }
        //            }
        //            if (found && occupied)
        //            {
        //                foreach (Block b in ctrl.getBlocks())
        //                {
        //                    //need better way of determining direction
        //                    //check if block is within range
        //                    foreach (Switch s in ctrl.getSwitches())
        //                    {
        //                        int sourceState = 0, target1State = 0, target2State = 0;
        //                        foreach (Block blk in ctrl.getBlocks())
        //                        {
        //                            if (checkWithinRange(blk.blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
        //                            {
        //                                //getDirection of source section
        //                                int? sourceDir = TrackControllerWindow.plc.getSwitchDirection(s.switchId, 0);
        //                                if (sourceDir == null)
        //                                {
        //                                    break;
        //                                }

        //                                //train is in bidirectional section, need to get direction
        //                                if (sourceDir == 0)
        //                                {
        //                                    Boolean f = false;
        //                                    foreach (Block blk2 in ctrl.getBlocks())
        //                                    {
        //                                        //increasing in block id
        //                                        if (blk2.blockId - 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.sourceBlockId > s.sourceBlockId_end)
        //                                            {
        //                                                sourceState = 1;
        //                                            }
        //                                            else if (s.sourceBlockId < s.sourceBlockId_end)
        //                                            {
        //                                                sourceState = -1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                        //decreasing
        //                                        else if (blk2.blockId + 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.sourceBlockId > s.sourceBlockId_end)
        //                                            {
        //                                                sourceState = -1;
        //                                            }
        //                                            else if (s.sourceBlockId < s.sourceBlockId_end)
        //                                            {
        //                                                sourceState = 1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                    }
        //                                    //if run is not found, assume train heading towards switch
        //                                    if (!f)
        //                                    {
        //                                        sourceState = 1;
        //                                    }
        //                                }
        //                                else //it is 1 directional, so the train has to be moving in the direction of the section
        //                                {
        //                                    sourceState = (int)sourceDir;
        //                                }
        //                            }

        //                            else if (checkWithinRange(blk.blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
        //                            {
        //                                int? t1Dir = TrackControllerWindow.plc.getSwitchDirection(s.switchId, 1);
        //                                if (t1Dir == null)
        //                                {
        //                                    break;
        //                                }

        //                                //train is in bidirectional section, need to get direction
        //                                if (t1Dir == 0)
        //                                {
        //                                    Boolean f = false;
        //                                    foreach (Block blk2 in ctrl.getBlocks())
        //                                    {
        //                                        //increasing in block id
        //                                        if (blk2.blockId - 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.targetBlockId1 > s.targetBlockId1_end)
        //                                            {
        //                                                target1State = 1;
        //                                            }
        //                                            else if (s.targetBlockId1 < s.targetBlockId1_end)
        //                                            {
        //                                                target1State = -1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                        //decreasing
        //                                        else if (blk2.blockId + 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.targetBlockId1 > s.targetBlockId1_end)
        //                                            {
        //                                                target1State = -1;
        //                                            }
        //                                            else if (s.targetBlockId1 < s.targetBlockId1_end)
        //                                            {
        //                                                target1State = 1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                    }
        //                                    //if run is not found, assume train heading towards switch
        //                                    if (!f)
        //                                    {
        //                                        target1State = 1;
        //                                    }
        //                                }
        //                                else //it is 1 directional, so the train has to be moving in the direction of the section
        //                                {
        //                                    target1State = (int)t1Dir;
        //                                }
        //                            }

        //                            else if (checkWithinRange(blk.blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
        //                            {
        //                                int? t2Dir = TrackControllerWindow.plc.getSwitchDirection(s.switchId, 2);
        //                                if (t2Dir == null)
        //                                {
        //                                    break;
        //                                }

        //                                //train is in bidirectional section, need to get direction
        //                                if (t2Dir == 0)
        //                                {
        //                                    Boolean f = false;
        //                                    foreach (Block blk2 in ctrl.getBlocks())
        //                                    {
        //                                        //increasing in block id
        //                                        if (blk2.blockId - 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.targetBlockId2 > s.targetBlockId2_end)
        //                                            {
        //                                                target2State = 1;
        //                                            }
        //                                            else if (s.targetBlockId2 < s.targetBlockId2_end)
        //                                            {
        //                                                target2State = -1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                        //decreasing
        //                                        else if (blk2.blockId + 1 == blk.blockId && !f)
        //                                        {
        //                                            if (s.targetBlockId2 > s.targetBlockId2_end)
        //                                            {
        //                                                target2State = -1;
        //                                            }
        //                                            else if (s.targetBlockId2 < s.targetBlockId2_end)
        //                                            {
        //                                                target2State = 1;
        //                                            }
        //                                            f = true;
        //                                        }
        //                                    }
        //                                    //if run is not found, assume train heading towards switch
        //                                    if (!f)
        //                                    {
        //                                        target2State = 1;
        //                                    }
        //                                }
        //                                else //it is 1 directional, so the train has to be moving in the direction of the section
        //                                {
        //                                    target2State = (int)t2Dir;
        //                                }
        //                            }
        //                        }
        //                        //should also determine lights too
        //                        TrackControllerWindow.plc.determineSwitchState(s.switchId, sourceState, target1State, target2State);
        //                        checkSafety(s);
        //                    }
        //                    foreach (Crossing c in ctrl.getCrossings())
        //                    {
        //                        if (c.blockId == blockId)
        //                        {
        //                            c.activated = true;
        //                        }
        //                    }
        //                }
        //            }
        //            //block wasnt found in system, possible coming from yard
        //            else if (!found && occupied)
        //            {

        //            }

        //            //block unoccupied
        //            else if (!occupied && found)
        //            {
        //                foreach (Block b in ctrl.getBlocks())
        //                {
        //                    if (b.blockId == blockId)
        //                    {
        //                        ctrl.blocks.Remove(b);
        //                        found = true;
        //                    }
        //                }
        //                foreach (Crossing c in ctrl.getCrossings())
        //                {
        //                    if (c.blockId == blockId)
        //                    {
        //                        c.activated = false;
        //                    }
        //                }
        //                //remove block from ctrl
        //            }
        //        }
        //    }
        //    //find the controller who has the block + or - 1 in active blocks
        //    //update a new block, from that you can get direction too
        //    TrainSimulation.mainOffice.updateBlockOccupancy(blockId, occupied);
        //    //need to update Trains table too
        //}


        //function checks each train. if it is heading towards an unsafe switch, sends kill signal

        public static void checkSafety(Switch s)
        {
            foreach (Train t in trainTrackings)
            {
                if (trainHeadingTowardsSwitch(t, s, 0)  > 0 && s.sourceLight == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
                if (trainHeadingTowardsSwitch(t, s, 1) > 0 && s.t1Light == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
                if (trainHeadingTowardsSwitch(t, s, 2) > 0 && s.t2Light == false)
                {
                    TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                }
            }
        }

        //given a train and a switch, it returns whether a train is heading towards a switch
        //returns direction as well
        public static int? trainHeadingTowardsSwitch(Train t, Switch s, int whichBranch)
        {
            if(t.direction == 0 || t.direction == null)
            {
                Console.WriteLine("Error. Train has no direction");
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
                            if(t.direction > 0 && s.sourceBlockId > s.sourceBlockId_end)
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

        private static Boolean checkWithinRange(int numToCheck, int bound1, int bound2)
        {
            if(bound1 < bound2)
            {
                if(numToCheck >= bound1 && numToCheck <= bound2)
                {
                    return true;
                }
            }
            else if (bound1 > bound2)
            {
                if(numToCheck <= bound1 && numToCheck >= bound2)
                {
                    return true;
                }
            }
            return false;
        }

        public static void shutdown()
        {

        }

        public static void resume()
        {

        }

        public static int? getSwitchState(int switchId)
        {
            foreach (TrackController ctrl in TrackControllerModule.activeControllers)
            {
                foreach(Switch s in ctrl.getSwitches())
                {
                    if(s.switchId == switchId)
                    {
                        return s.currentState;
                    }
                }
            }
            return -1;
        }

        public static Boolean initializeSwitches(List<Switch> switches)
        {
            Console.WriteLine("Initializing switches");
            Console.WriteLine(switches.Count);
            foreach(Switch s in switches)
            {
                Console.WriteLine("SwitchId: " + s.switchId);
                Console.WriteLine(s.sourceBlockId + ", " + s.sourceBlockId_end);
                Console.WriteLine(s.targetBlockId1 + ", " + s.targetBlockId1_end);
                Console.WriteLine(s.targetBlockId2 + ", " + s.targetBlockId2_end);
                Console.WriteLine("\n");

                if (s.switchId >= 0 && s.switchId <= 2)
                {
                    greenLineCtrl1.addNewSwitch(s);
                }
                else if (s.switchId >= 3 && s.switchId <= 5)
                {
                    greenLineCtrl2.addNewSwitch(s);
                }
                else if (s.switchId >= 6 && s.switchId <= 9)
                {
                    redLineCtrl1.addNewSwitch(s);
                }
                else
                {
                    redLineCtrl2.addNewSwitch(s);
                }
                TrackControllerWindow.plc.addSwitch(s);
            }
            return true;
        }

        public static void initializeCrossings(List<Crossing> crossings)
        {
            Console.WriteLine("Initializing crossings");
            foreach (Crossing c in crossings)
            {
                Console.WriteLine(c.blockId);
                if(c.blockId == 19)
                {
                    greenLineCtrl1.addNewCrossing(c);
                }
                else
                {
                    redLineCtrl1.addNewCrossing(c);
                }
            }
            initializeTrackControllers();
        }

        //manually add switches, crossings, blocks to controllers for now
        //eventually will get them from track model
        public static void initializeTrackControllers()
        {
            activeControllers.Add(redLineCtrl1);
            activeControllers.Add(redLineCtrl2);
            activeControllers.Add(greenLineCtrl1);
            activeControllers.Add(greenLineCtrl2);
            TrainSimulation.trackControllerWindow.initializeControllerTable();
            TrainSimulation.trackControllerWindow.initializeSwitchTable();
            TrainSimulation.trackControllerWindow.initializeCrossingTable();
            TrainSimulation.trackControllerWindow.updateSwitches();
            TrainSimulation.trackControllerWindow.updateCrossings();
        }
    }
}
