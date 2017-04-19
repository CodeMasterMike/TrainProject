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
        public BlockTracker(String line, int l)
        {
            lineID = l;
            loadClassesFromDB();
            if (lineID == 2) currentBlock = getBlock(229);
            else currentBlock = getBlock(152);

        }
        public BlockTracker(bool b, int i, int l)
        {
            lineID = l;
            loadClassesFromDB();
            int blockID = getDataBaseID(i);
            currentBlock = getBlock(blockID);
            prevToNext = b;
        }
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
        public Block getBlock(int blockID)
        {
            foreach (Block block in blocks)
            {
                if (block.blockId == blockID) return block;
            }
            return null;
        }
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
        public void configureDirection()
        {
            if (currentBlock.prevBlockId == null) prevToNext = true;
            else prevToNext = false;
        }
        public Block getCurrentBlock()
        {
            return currentBlock;
        }
        public double getDistance(int n)
        {
            int distance = currentBlock.length;
            for(int i = 0; i < n-1; i++)
            {
                currentBlock = getNextBlock(currentBlock.blockNum);
                distance += currentBlock.length;
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
    }
}
