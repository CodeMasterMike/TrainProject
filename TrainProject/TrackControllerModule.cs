using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Layout_UI;
using TrainModelProject;


namespace TrainProject
{
public class TrackControllerModule
{
    //controllers, various tracking data structures
    public static TrackController greenLineCtrl1 = new TrackController(0, "green1");
    public static TrackController greenLineCtrl2 = new TrackController(1, "green2");
    public static TrackController redLineCtrl1 = new TrackController(2, "red1");
    public static TrackController redLineCtrl2 = new TrackController(3, "red2");
    public static List<TrainModel> activeTrains = new List<TrainModel>();
    public static List<Train> trainTrackings = new List<Train>();
    public static List<TrackController> activeControllers = new List<TrackController>();

    //used by the CTC to update and speed and authority of a certain train
    public void updateSpeedAndAuthority(int trainId, Double speed, int authority)
    {
        Boolean found = false;
        int curBlock = -1;
        
        //find train
        foreach (Train t in trainTrackings)
        {
            if(t.trainId == trainId)
            {
                found = true;
                curBlock = t.currBlock;
            }
        }

        if (found)
        {
            if (TrainSimulation.trackModelWindow.findBlock(curBlock).speedLimit < speed)
            {
                TrainSimulation.trackModelWindow.updateSpeedAndAuthority(trainId, TrainSimulation.trackModelWindow.findBlock(curBlock).speedLimit, authority);
            }
            else
            {
                TrainSimulation.trackModelWindow.updateSpeedAndAuthority(trainId, speed, authority);
            }
        }
    }

    //used by CTC to close a certain block
    public static void closeBlock(int blockId)
    {
        foreach (TrackController ctrl in activeControllers)
        {
            foreach (Switch s in ctrl.getSwitches())
            {
                if (ctrl.checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                {
                    s.sourceActive = false;
                }
                if (ctrl.checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                {
                        s.t1Active = false;
                }
                if (ctrl.checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                {
                        s.t2Active = false;
                }
                foreach (Train t in trainTrackings)
                {
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 0) > 0 && !s.sourceActive)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                    }
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 1) > 0 && !s.t1Active)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                    }
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 2) > 0 && !s.t2Active)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
                    }
                }
            }

        }
    }

    //reopen specific block
    public static void openBlock(int blockId)
    {
        foreach (TrackController ctrl in activeControllers)
        {
            foreach (Switch s in ctrl.getSwitches())
            {
                if (ctrl.checkWithinRange(blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end))
                {
                    s.sourceActive = true;
                }
                if (ctrl.checkWithinRange(blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end))
                {
                    s.t1Active = true;
                }
                if (ctrl.checkWithinRange(blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end))
                {
                    s.t2Active = true;
                }

                foreach (Train t in trainTrackings)
                {
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 0) > 0 && s.sourceActive)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                    }
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 1) > 0 && s.t1Active)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                    }
                    if (ctrl.trainHeadingTowardsSwitch(t, s, 2) > 0 && s.t2Active)
                    {
                        TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
                    }
                }
            }
        }
    }

        
    //called by track model to update block occupancy
    //this function makes calls to track controller and plc
    public static void updateBlockOccupancy(Block blk, Boolean occupied)
    {
        Boolean found = false, yardOccupancy = false;
        TrainSimulation.mainOffice.updateBlockOccupancy(blk.blockId, occupied);

        //red line only
        if(blk.isFromYard && blk.isToYard)
        {
            TrackControllerWindow.plc.determineSwitchState(blk.parentSwitch, 0, 0, 1);
            found = true;
            yardOccupancy = true;
        }

        //green lines
        else if (blk.isFromYard)
        {
            TrackControllerWindow.plc.determineSwitchState(blk.parentSwitch, 0, 0, 1);
            found = true;
            yardOccupancy = true;
        }
        else if (blk.isToYard)
        {

        }
        foreach (Train t in trainTrackings)
        {
            //increasing in block id
            if (t.currBlock == blk.blockId + 1)
            {
                t.direction = -1;
                found = true;
            }

            //decreasing in block id
            else if (t.currBlock == blk.blockId - 1)
            {
                t.direction = 1;
                found = true;
            }
                foreach (TrackController ctrl in activeControllers)
                {
                    foreach (Switch s in ctrl.switches)
                    {
                        int? srcDir, t1Dir, t2Dir;
                        srcDir = ctrl.trainHeadingTowardsSwitch(t, s, 0);
                        t1Dir = ctrl.trainHeadingTowardsSwitch(t, s, 1);
                        t2Dir = ctrl.trainHeadingTowardsSwitch(t, s, 2);
                        if((srcDir != 0 && ctrl.checkWithinRange(blk.blockId, (int)s.sourceBlockId, (int)s.sourceBlockId_end)) ||
                            (t1Dir != 0 && ctrl.checkWithinRange(blk.blockId, (int)s.targetBlockId1, (int)s.targetBlockId1_end)) ||
                            (t2Dir != 0 && ctrl.checkWithinRange(blk.blockId, (int)s.targetBlockId2, (int)s.targetBlockId2_end)))
                        {
                            t.currBlock = blk.blockId;
                            found = true;
                        }
                        int switchState = (int)TrackControllerWindow.plc.determineSwitchState(s, srcDir, t1Dir, t2Dir);
                        if(s.currentState != switchState)
                        {
                            s.changeSwitchState();
                        }
                        //Console.WriteLine("Switch " + s.switchId + " pointing to " + switchState);

                        //check controller safety
                        ctrl.checkSafety(s);

                        //Console.WriteLine("After checking safety, Switch " + s.switchId + " pointing to " + switchState);
                    }

                    //check crossings
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
        }//end foreach

        if (!found)
        {
            Console.WriteLine("Train not found in system");
            Console.WriteLine(blk.blockId);
            foreach (Train t in trainTrackings)
            {
                Console.WriteLine(t.trainId + " at block " + t.currBlock);
            }
        }
        foreach (Train t in trainTrackings)
        {
            Console.WriteLine(t.trainId + " at block " + t.currBlock + "Dir: " + t.direction);
        }
        TrainSimulation.trackControllerWindow.updateSwitches();
        TrainSimulation.trackControllerWindow.updateCrossings();
        TrainSimulation.trackControllerWindow.updateTrains();
    }

   

    public static void causeFailure(int blockId)
    {
            Console.WriteLine("Closing block " + blockId);
        closeBlock(blockId);
        //TrainSimulation.mainOffice.causeFailure(blockId);  
    }

    public void dispatchNewTrain(int trainId, TrainModel newTrain, double speed, int authority)
    {
        //Console.WriteLine("dispatching train!!!!!");
        Train newT = new Train(trainId, speed, authority);
        newT.currBlock = newTrain.getCurrBlock();
        double speedLimit = TrainSimulation.trackModelWindow.findBlock(newT.currBlock).speedLimit;
        if (speedLimit < speed)
        {
            TrainSimulation.trackModelWindow.dispatchTrain(trainId, newTrain, speedLimit, authority);
        }
        else
        {
            TrainSimulation.trackModelWindow.dispatchTrain(trainId, newTrain, speed, authority);
        }
        trainTrackings.Add(newT);
        activeTrains.Add(newTrain);
        TrainSimulation.trackControllerWindow.updateTrains();
    }

    public static void shutdown()
    {
        foreach (Train t in trainTrackings)
        {
            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, 0, 0);
        }
    }

    public static void resume()
    {
        foreach (Train t in trainTrackings)
        {
            TrainSimulation.trackModelWindow.updateSpeedAndAuthority(t.trainId, t.suggestedSpeed, t.authority);
        }
    }

    public static int? getSwitchState(int switchId)
    {
        foreach (TrackController ctrl in TrackControllerModule.activeControllers)
        {
            foreach (Switch s in ctrl.getSwitches())
            {
                if (s.switchId == switchId)
                {
                    return s.currentState;
                }
            }
        }
        return -1;
    }

    public static Boolean initializeSwitches(List<Switch> switches)
    {
        //Console.WriteLine("Initializing switches");
        //Console.WriteLine(switches.Count);
        foreach (Switch s in switches)
        {
            Console.WriteLine("SwitchId: " + s.switchId);
            Console.WriteLine(s.sourceBlockId + ", " + s.sourceBlockId_end);
            Console.WriteLine(s.targetBlockId1 + ", " + s.targetBlockId1_end);
            Console.WriteLine(s.targetBlockId2 + ", " + s.targetBlockId2_end);
            Console.WriteLine("\n");
            s.sourceBlockNum = TrainSimulation.trackModelWindow.findBlock((int)s.sourceBlockId).blockNum;
            s.targetBlockNum1 = TrainSimulation.trackModelWindow.findBlock((int)s.targetBlockId1).blockNum;
            s.targetBlockNum2 = TrainSimulation.trackModelWindow.findBlock((int)s.targetBlockId2).blockNum;
                s.currentStateNum = s.targetBlockNum1;

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
        //Console.WriteLine("Initializing crossings");
        foreach (Crossing c in crossings)
        {
            Console.WriteLine(c.blockId);
            if (c.blockId == 19)
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