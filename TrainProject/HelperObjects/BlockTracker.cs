//Block Tracker helper class
//Created by : Naran Babha
//Date Created : 2/20/17
//This class helps the train controller figure out its position on the track
//it holds the direction of the train as well

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TrainProject.HelperObjects
{
    class BlockTracker
    {
        int lineID;
        int count = 0;
        bool prevToNext = true;
        bool onSwitch = false;
        Block currentBlock;
        List<Line> lineList = new List<Line>();
        List<Section> sectionList = new List<Section>();
        List<Block> blockList = new List<Block>();
        List<Block> blocks = new List<Block>();
        List<Switch> switchList = new List<Switch>();
        //constructor used for the main tracker
        public BlockTracker(String line, int l)
        {
            lineID = l;
            loadClassesFromDB();
            if (lineID == 2) currentBlock = getBlock(229);
            else currentBlock = getBlock(152);

        }
        //constructor used to conduct future searches for speed and authority
        public BlockTracker(bool b, int i, int l)
        {
            lineID = l;
            loadClassesFromDB();
            int blockID = getDataBaseID(i);
            currentBlock = getBlock(blockID);
            prevToNext = b;
        }
        //loads the blocks for the line that the train is assigned to
        private void loadClassesFromDB()
        {
            string str = ConfigurationManager.ConnectionStrings["TrainProject.Properties.Settings.TrackDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                lineList = DatabaseInterface.loadLinesFromDB(con);
                sectionList = DatabaseInterface.loadSectionsFromDB(con, lineList);
                blockList = DatabaseInterface.loadBlocksFromDB(con, lineList);
                switchList = DatabaseInterface.loadSwitchesFromDB(con, blockList);
                DatabaseInterface.updateBlocksNextPrevious(lineList);
            }
            foreach(Line line in lineList)
            {
                if (line.lineId == lineID)
                {
                    foreach (Section section in line.sections)
                    {
                        foreach (Block block in section.blocks)
                        {
                            blocks.Add(block);
                            count++;
                        }
                    }
                }
            }
        }
        //gets a block from the blocks list based on the block ID
        public Block getBlock(int blockID)
        {
            foreach (Block block in blocks)
            {
                if (block.blockId == blockID) return block;
            }
            return null;
        }
        //main fucntion for the class. gets next block based on current block and direction.
        //if the next block is ambiguous because the train is on a swtich, it returns null
        //and the train has to figure out its next block based on the switch beacons
        public Block getNextBlock(int i)
        {
            int blockID = getDataBaseID(i);
            currentBlock = getBlock(blockID);
            if (onSwitch) {
                configureDirection();
                onSwitch = false;
            }
            
            if (prevToNext)
            {
                if (currentBlock.nextBlockId != null)
                {
                    return getBlock((int)currentBlock.nextBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId1 == blockID)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId2 == blockID)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else
                {
                    onSwitch = true;
                    return null;
                }
            }
           else
            {
                if (currentBlock.prevBlockId != null)
                {
                    return getBlock((int)currentBlock.prevBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId1 == blockID)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId2 == blockID)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else
                {
                    onSwitch = true;
                    return null;
                }
            }
        }
        public int getDataBaseID(int i)
        {
            foreach(Block block in blocks)
            {
                if (block.blockNum == i) return block.blockId;
            }
            return 0;
        }
        //cofigures direction for the train after passing a switch
        public void configureDirection()
        {
            if (currentBlock.prevBlockId == null) prevToNext = true;
            else prevToNext = false;
        }
        public Block getCurrentBlock()
        {
            return currentBlock;
        }
        //gets the distance until the block exceeds its authority
        //if the next block is ambiguous, then it simply returns a value telling the controller
        // to slow down to a very slow speed so that it can stop when it needs to
        public double getDistance(int n)
        {
            int distance = currentBlock.length;
            for(int i = 0; i < n-1; i++)
            {
                currentBlock = getNextBlock(currentBlock.blockNum);
                if (currentBlock != null)
                {
                    distance += currentBlock.length;
                }
                else
                {
                    return distance + 50;
                }
            }
            return distance;
        }
        public bool getPrevToNext()
        {
            return prevToNext;
        }
        public bool getOnSwtich()
        {
            return onSwitch;
        }
        //gets direction of the train
        public bool getDirection(int i)
        {
            Block temp = getBlock(i);
            if (onSwitch)
            {
                if (temp.prevBlockId == null) return true;
                else return false;
            }
            return prevToNext;
        }
        //gets the minimum speed limit of the next two blocks
        public double getSpeedLimit()
        {
            int speed = currentBlock.speedLimit;
            for(int n = 0; n < 2; n++)
            {
                currentBlock = getNextBlock(currentBlock.blockNum);
                if(currentBlock != null)
                {
                    if (currentBlock.speedLimit < speed)
                    {
                        speed = currentBlock.speedLimit;
                    }
                }
                else return speed - 15;
            }
            return speed;
        }
    }
    
}
