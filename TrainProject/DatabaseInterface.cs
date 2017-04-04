using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using TrainProject;
using TrainProject.HelperObjects;

namespace TrainProject
{
    static class DatabaseInterface
    {
        //Use the below format to properly get and update your lists (ALWAYS)
        /*private void loadClassesFromDB()
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
        }*/

        //just returns the lines array
        public static List<Line> loadLinesFromDB(SqlConnection con)
        {
            List<Line> lines = new List<Line>();

            SqlCommand read = new SqlCommand("SELECT * FROM Lines");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            con.Open();
            SqlDataReader reader = read.ExecuteReader();
            while (reader.Read())
            {
                int lineId = reader.GetInt32(0);
                string name = reader.GetString(1);
                Line line = new Line(lineId, name);
                lines.Add(line);
            }
            reader.Close();
            con.Close();

            return lines;
        }

        //will add sections to the line.sections and return an array of all the new sections
        public static List<Section> loadSectionsFromDB(SqlConnection con, List<Line> lineList)
        {
            List<Section> sections = new List<Section>();

            SqlCommand read = new SqlCommand("SELECT * FROM Sections");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            con.Open();
            SqlDataReader reader = read.ExecuteReader();
            while (reader.Read())
            {
                int sectionId = reader.GetInt32(0);
                string name = reader.GetString(1);
                int lineId = reader.GetInt32(2);
                Section section = new Section(sectionId, name, lineId, null, null, false);
                sections.Add(section);
                foreach (Line line in lineList)
                {
                    if (line.lineId == section.lineId)
                    {
                        line.sections.Add(section);
                    }
                }
            }
            reader.Close();
            con.Close();

            return sections;
        }

        //will add blocks to the line.sections.blocks and return an array of all the new blocks
        public static List<Block> loadBlocksFromDB(SqlConnection con, List<Line> lineList)
        {
            List<Block> blocks = new List<Block>();

            SqlCommand read = new SqlCommand("SELECT * FROM Blocks");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            con.Open();
            SqlDataReader reader = read.ExecuteReader();
            while (reader.Read())
            {
                int blockId = reader.GetInt32(0);
                int blockNumber = reader.GetInt32(1);
                int sectionId = reader.GetInt32(2);
                decimal length = reader.GetDecimal(3);
                decimal grade = reader.GetDecimal(4);
                decimal elevation = reader.GetDecimal(5);
                decimal cumulativeElevation = reader.GetDecimal(6);
                int speedLimit = reader.GetInt32(7);
                String infrastructure = reader.GetString(8);

                Block block = new Block(blockId, blockNumber, sectionId, length, grade, elevation, cumulativeElevation, speedLimit, false);
                block.prevBlockId = null;
                block.nextBlockId = null;
                block.isUnderground = false;
                if(infrastructure.Contains("UNDERGROUND"))
                {
                    block.isUnderground = true;
                }
                if(infrastructure.Contains("TO/FROM YARD"))
                {
                    block.isToYard = true;
                    block.isFromYard = true;
                }
                else if(infrastructure.Contains("TO YARD"))
                {
                    block.isToYard = true;
                    block.isFromYard = false;
                }
                else if (infrastructure.Contains("FROM YARD"))
                {
                    block.isToYard = false;
                    block.isFromYard = true;
                }
                else
                {
                    block.isToYard = false;
                    block.isFromYard = false;
                }
                blocks.Add(block);

                foreach (Line line in lineList)
                {
                    foreach (Section section in line.sections)
                    {
                        if (section.sectionId == block.sectionId)
                        {
                            section.blocks.Add(block);
                        }
                    }
                }
            }
            reader.Close();
            con.Close();

            return blocks;
        }

        public static List<Switch> loadSwitchesFromDB(SqlConnection con, List<Block> blockList)
        {
            List<Switch> switches = new List<Switch>();

            SqlCommand read = new SqlCommand("SELECT * FROM Blocks");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            con.Open();
            SqlDataReader reader = read.ExecuteReader();
            while (reader.Read())
            {
                int blockId = reader.GetInt32(0);
                int blockNumber = reader.GetInt32(1);
                int sectionId = reader.GetInt32(2);
                Block currBlock = null;
                String infrastructure = reader.GetString(8);
                String switchBlock = reader.GetString(9);
                Switch currSwitch = null;

                //now parse the SwitchBlock column
                if (switchBlock != null && switchBlock.Length > 0)
                {
                    //first find block object currently being referenced
                    foreach (Block block in blockList)
                    {
                        if (block.blockId == blockId)
                        {
                            currBlock = block;
                        }
                    }
                    switchBlock = switchBlock.Replace("Switch ", "");
                    int currId = Convert.ToInt32(switchBlock);
                    bool found = false;
                    foreach (Switch s in switches)
                    {
                        if (s.switchId == currId)
                        {
                            currSwitch = s;
                            found = true;
                            break;
                        }
                    }
                    bool isNew = false;
                    if (!found)
                    {
                        currSwitch = new Switch(currId, null, null, null);
                        isNew = true;
                    }
                    if (infrastructure.Contains("SWITCH"))
                    {
                        currSwitch.sourceBlockId = currBlock.blockId;
                    }
                    else if (currSwitch.targetBlockId1 == null)
                    {
                        currSwitch.targetBlockId1 = currBlock.blockId;
                    }
                    else
                    {
                        currSwitch.targetBlockId2 = currBlock.blockId;
                    }
                    if (isNew)
                    {
                        switches.Add(currSwitch);
                    }
                    currBlock.parentSwitch = currSwitch;
                }

            }
            reader.Close();
            con.Close();

            return switches;
        }

        //uses blocks in Line/Section/Block format
        public static void updateBlocksNextPrevious(List<Line> lineList) 
        {
            foreach (Line line in lineList)
            {
                Block prevBlock = null;
                foreach (Section section in line.sections)
                {
                    foreach (Block block in section.blocks)
                    {
                        if (prevBlock != null)
                        {
                            if (!(prevBlock.parentSwitch != null && block.parentSwitch != null))
                            {
                                block.prevBlockId = prevBlock.blockId;
                                prevBlock.nextBlockId = block.blockId;
                            }
                        }
                        prevBlock = block;
                    }
                }
            }
        }
    }
}
