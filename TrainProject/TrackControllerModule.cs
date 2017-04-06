using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Layout_UI;


namespace TrainProject
{
    //handles initializing controllers, delegating speed requests
    public class TrackControllerModule
    {
 
        public static TrackController greenLineCtrl1 = new TrackController(0, "green1");
        public static TrackController greenLineCtrl2 = new TrackController(1, "green2");
        public static TrackController redLineCtrl1 = new TrackController(2, "red1");
        public static TrackController redLineCtrl2 = new TrackController(3, "red2");
        public static List<TrackController> activeControllers = new List<TrackController>();

        public void updateSpeedAndAuthority(int trainId, Double speed, Double authority)
        {

        }

        public void dispatchNewTrain(int trainId, Double speed, Double authority)
        {
            //Track.dispatchTrain(Train t, Double speed, int authority)
        }

        public void dispatchNewTrain(Train newTrain)
        {
            Console.WriteLine("dispatching train!!!!!");
            TrainSimulation.trackModelWindow.dispatchTrain(newTrain);
            //TrackModelUI.
        }

        public void updateBlockOccupancy(int blockId, Boolean occupied)
        {
            foreach(TrackController ctrl in activeControllers)
            {
                //new block occupied
                if (occupied)
                {
                    Block newBlock;
                    foreach (Block b in ctrl.getBlocks())
                    {
                        //need better way of determining direction
                        if (b.blockId == blockId + 1)
                        {
                            newBlock = new Block(blockId, 1);
                            ctrl.addNewBlock(newBlock);
                            break;
                        }
                        else if (b.blockId == blockId - 1)
                        {
                            newBlock = new Block(blockId, -1);
                            ctrl.addNewBlock(newBlock);
                            break;
                        }

                        //after this, call monitor switches
                        ctrl.monitorSwitches();
                        ctrl.monitorCrossings();
                    }
                }
                //block unoccupied
                else
                {
                    foreach (Block b in ctrl.getBlocks())
                    {
                        if (b.blockId == blockId)
                        {
                            ctrl.blocks.Remove(b);
                        }
                    }
                    //remove block from ctrl
                }
                
            }
            //find the controller who has the block + or - 1 in active blocks
            //update a new block, from that you can get direction too
        }

        public int? getSwitchState(int switchId)
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
            foreach(Switch s in switches)
            {
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
            }
            initializeTrackControllers();
            return true;
        }

        //manually add switches, crossings, blocks to controllers for now
        //eventually will get them from track model
        public static void initializeTrackControllers()
        {
            Switch s1 = new Switch(0, 12, 1, 13);
            Switch s2 = new Switch(1, 29, 28, 150);
            Switch s3 = new Switch(2, 50, 57, 151);
            Train t1 = new Train(1, 15.0, 20);
            Crossing c1 = new Crossing(0, 19);
            //greenLineCtrl1.addNewSwitch(s1);
            //greenLineCtrl1.addNewSwitch(s2);
            //greenLineCtrl1.addNewSwitch(s3);
            //greenLineCtrl1.addNewTrain(t1);
            //greenLineCtrl1.addNewCrossing(c1);
            activeControllers.Add(redLineCtrl1);
            activeControllers.Add(redLineCtrl2);
            activeControllers.Add(greenLineCtrl1);
            activeControllers.Add(greenLineCtrl2);
            TrainSimulation.trackControllerWindow.initializeControllerTable();
            TrainSimulation.trackControllerWindow.initializeSwitchTable();
            TrainSimulation.trackControllerWindow.updateSwitches();
        }
    }
}
