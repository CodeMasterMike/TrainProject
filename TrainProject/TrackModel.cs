using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using TrainProject;
using TrainProject.HelperObjects;
using CTC;

namespace Track_Layout_UI
{
    public partial class TrackModelUI : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public static List<Block> blockList = new List<Block>();
        public static List<Block> filteredBlockList = new List<Block>();
        public static List<Section> sectionList = new List<Section>();
        public static List<Line> lineList = new List<Line>();
        public static List<Switch> switchList = new List<Switch>();
        public static List<Train> trainList = new List<Train>();
        public static Block selectedBlock;
        public static Line selectedLine;
        //temporary variables
        private int yardBlockId = 229;
        static List<StationBeacon> redLineStationBeacons = new List<StationBeacon>(78);
        private static void initializeRedLineStationBeacons()
        {
            StationBeacon currBeacon;
            currBeacon = new StationBeacon("SHADYSIDE", 75, false);
            redLineStationBeacons[8] = currBeacon;
            currBeacon = new StationBeacon("HERRON AVE", 50, false);
            redLineStationBeacons[1] = currBeacon;
        }
        public static StationBeacon getStationBeacon(int lineNum, int blockNum)
        {
            if (lineNum == 2)
            {
                return redLineStationBeacons[blockNum];
            }
            return null;
        }
        //end temp stuff
        public TrackModelUI()
        {
            InitializeComponent();
        }

        public void dispatchTrain(Train train)
        {
            trainList.Add(train);
        }

        public void updateSpeedAndAuthority(int trainId, double speed, int authority)
        {
            foreach(Train train in trainList)
            {
                if(trainId == train.trainId)
                {
                    //train.updateSpeedAndAuthority(speed, authority);
                    break;
                }
            }
        }

        private Block findBlock(int blockId)
        {
            foreach(Block block in blockList)
            {
                if(block.blockId == blockId)
                {
                    return block;
                }
            }
            return null;
        }

        //only returns null if the yard
        //need to test
        public Block getNextBlock(Block prevBlock, Block currBlock)
        {    
            Block nextBlock = null;
            bool isSource = false;
            bool isTarget = false;
            if (prevBlock == null && currBlock == null) //coming from yard
            {
                return findBlock(yardBlockId);
            }
            if(currBlock.parentSwitch != null)
            {
                if (currBlock.parentSwitch.sourceBlockId == currBlock.blockId)
                {
                    isSource = true;
                }
                else if (currBlock.parentSwitch.targetBlockId1 == currBlock.blockId || currBlock.parentSwitch.targetBlockId2 == currBlock.blockId)
                {
                    isTarget = true;
                }
            }
            if(prevBlock == null && currBlock.parentSwitch != null) //if already on 1st block from yard
            {
                if(isTarget)
                {
                    return findBlock((int)currBlock.parentSwitch.sourceBlockId);
                }
                else if(isSource)
                {
                    int targetId = (int)TrackControllerModule.getSwitchState(currBlock.parentSwitch.switchId);
                    return findBlock(targetId);
                }
            }
            else if(prevBlock.parentSwitch != null && currBlock.parentSwitch != null) //if coming off a switch
            {
                if(currBlock.prevBlockId == null)
                {
                    return findBlock((int)currBlock.nextBlockId);
                }
                else
                {
                    return findBlock((int)currBlock.prevBlockId);
                }
            }
            else if(currBlock.parentSwitch != null && prevBlock.parentSwitch == null) //if entering a switch
            {
                if (isTarget)
                {
                    return findBlock((int)currBlock.parentSwitch.sourceBlockId);
                }
                else if (isSource)
                {
                    int targetId = (int)TrackControllerModule.getSwitchState(currBlock.parentSwitch.switchId);
                    return findBlock(targetId);
                }
            }
            else //if no switches involved
            {
                if(prevBlock.nextBlockId != null && prevBlock.nextBlockId == currBlock.blockId)
                {
                    return findBlock((int)currBlock.nextBlockId);
                }
                else if(prevBlock.prevBlockId != null && prevBlock.prevBlockId == currBlock.blockId)
                {
                    return findBlock((int)currBlock.prevBlockId);
                }
            }
            return nextBlock;
        }

        internal void getNextBlock(object g)
        {
            throw new NotImplementedException();
        }

        public void updateBlockStatus(int blockId, bool occupied)
        {
            TrackControllerModule.updateBlockOccupancy(blockId, occupied);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e) //open file
        {

        }

        private void selectFile(object sender, EventArgs e)
        {
            openExcelFileDialog.ShowDialog();
        }

        private List<ExcelFileLayout> loadDvgIntoList(DataGridView excelFileData, List<ExcelFileLayout> excelFileList)
        {
            foreach (DataGridViewRow row in excelFileData.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    ExcelFileLayout currEntry = new ExcelFileLayout(
                        row.Cells[0].Value.ToString(),
                        row.Cells[1].Value.ToString(),
                        Convert.ToInt32(row.Cells[2].Value),
                        Convert.ToDouble(row.Cells[3].Value),
                        Convert.ToDouble(row.Cells[4].Value),
                        Convert.ToInt32(row.Cells[5].Value),
                        row.Cells[6].Value.ToString(),
                        Convert.ToDouble(row.Cells[8].Value),
                        Convert.ToDouble(row.Cells[9].Value),
                        row.Cells[10].Value.ToString(),
                        row.Cells[11].Value.ToString());
                    excelFileList.Add(currEntry);
                }
            }            
            return excelFileList;
        }

        private List<ExcelFileLayout> populateExcelListOfUniqueLines(List<ExcelFileLayout> allLines)
        {
            List<ExcelFileLayout> uniqueLines = new List<ExcelFileLayout>();
            foreach(ExcelFileLayout line in allLines)
            {
                bool found = false;
                foreach(ExcelFileLayout uniqueLine in uniqueLines)
                {
                    if(String.Compare(line.Line, uniqueLine.Line) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    uniqueLines.Add(line);
                }
            }
            return uniqueLines;
        }
        private List<ExcelFileLayout> populateExcelListOfUniqueSections(List<ExcelFileLayout> allSections)
        {
            List<ExcelFileLayout> uniqueSections = new List<ExcelFileLayout>();
            foreach (ExcelFileLayout section in allSections)
            {
                bool found = false;
                foreach (ExcelFileLayout uniqueSection in uniqueSections)
                {
                    //must also check line uniqueness since sections are repeated per line
                    if (String.Compare(section.Section, uniqueSection.Section) == 0 && String.Compare(section.Line, uniqueSection.Line) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    uniqueSections.Add(section);
                }
            }
            return uniqueSections;
        }
        private void insertLineIntoDB(SqlConnection con, ExcelFileLayout line)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Lines (Name) VALUES (@Name)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Name", line.Line);
            cmd.ExecuteNonQuery();
        }
        private void insertSectionIntoDB(SqlConnection con, ExcelFileLayout section) //assumes associated line is already in DB
        {
            SqlCommand read = new SqlCommand("SELECT * FROM Lines WHERE Name = @Name");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            read.Parameters.AddWithValue("@Name", section.Line);
            SqlDataReader reader = read.ExecuteReader();
            if (reader.Read())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Sections (Name, LineId) VALUES (@Name, @LineId)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Name", section.Section);
                int lineId = reader.GetInt32(0);
                cmd.Parameters.AddWithValue("@LineId", lineId);
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            else
                Console.WriteLine("Associated line not found for section.");
        }
        private void insertBlockIntoDB(SqlConnection con, ExcelFileLayout block)
        {
            SqlCommand read = new SqlCommand("SELECT Sections.SectionId, Sections.Name AS SectionName, Lines.Name AS LineName FROM Sections JOIN Lines ON Sections.LineId = Lines.LineId WHERE Sections.Name = @SectionName AND Lines.Name = @LineName");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            read.Parameters.AddWithValue("@SectionName", block.Section);
            read.Parameters.AddWithValue("@LineName", block.Line);
            SqlDataReader reader = read.ExecuteReader();
            if (reader.Read())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Blocks (BlockNumber, SectionId, Length, Grade, Elevation, CumulativeElevation, SpeedLimit, Infrastructure, SwitchBlock, ArrowDirection) VALUES (@BlockNumber, @SectionId, @Length, @Grade, @Elevation, @CumulativeElevation, @SpeedLimit, @Infrastructure, @SwitchBlock, @ArrowDirection)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@BlockNumber", block.BlockNumber);
                int sectionId = reader.GetInt32(0);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                cmd.Parameters.AddWithValue("@Length", block.BlockLength);
                cmd.Parameters.AddWithValue("@Grade", block.BlockGrade);
                cmd.Parameters.AddWithValue("@Elevation", block.Elevation);
                cmd.Parameters.AddWithValue("@CumulativeElevation", block.CumulativeElevation);
                cmd.Parameters.AddWithValue("@SpeedLimit", block.SpeedLimit);
                cmd.Parameters.AddWithValue("@Infrastructure", block.Infrastructure);
                cmd.Parameters.AddWithValue("@SwitchBlock", block.SwitchBlock);
                cmd.Parameters.AddWithValue("@ArrowDirection", block.ArrowDirection);
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            else
                Console.WriteLine("Associated section not found for block.");
        }
        // ***still need to get second sheet (need Green AND Red line)
        private void openExcelFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openExcelFileDialog.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = ""; //required to open the excel file
            string sheetName = "";

            switch (extension)
            {
                case ".xls":
                    conString = string.Format(Excel03ConString, filePath, "YES");
                    break;
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
            }

            //for each(dt.Rows.Count times)
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand()) //represents an sql statement or stored proc
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString(); //gets the name of the first sheet (Red Line)
                    con.Close();
                }
            }

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    oda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    con.Close();
                    dvgBlocks.DataSource = dt; //inserts entire excel table (not parsed) into DataSource
                }
            }
            //now load the data into a list of ExcelFileLayout classes
            List<ExcelFileLayout> excelFileEntries = new List<ExcelFileLayout>();
            excelFileEntries = loadDvgIntoList(dvgBlocks, excelFileEntries);

            List<ExcelFileLayout> excelFileLines = populateExcelListOfUniqueLines(excelFileEntries);
            List<ExcelFileLayout> excelFileSections = populateExcelListOfUniqueSections(excelFileEntries);
            List<ExcelFileLayout> excelFileBlocks = excelFileEntries;

            //now actually write/load the data into the database
            string str = ConfigurationManager.ConnectionStrings["TrainProject.Properties.Settings.TrackDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                //first delete all current db rows
                deleteAllDbRows(con);
                //then insert into Line table
                con.Open();
                foreach(ExcelFileLayout line in excelFileLines)
                {
                    insertLineIntoDB(con, line);
                }
                con.Close();
                //now insert into Sections table
                con.Open();
                foreach (ExcelFileLayout section in excelFileSections)
                {
                    insertSectionIntoDB(con, section);
                }
                con.Close();
                //now insert into Blocks table
                con.Open();
                foreach (ExcelFileLayout block in excelFileBlocks)
                {
                    insertBlockIntoDB(con, block);
                }
                con.Close();

                ExcelFileName.Text = openExcelFileDialog.FileName;
                MessageBox.Show("File loaded into local DataBase!");

                loadClassesFromDB();
            }
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
                initializeRedLineStationBeacons();
            }
            TrackControllerModule.initializeSwitches(switchList);
            //Office.initializeTrackLayout(lineList);
            initializeLists();
        }

        public void initializeLists()
        {
            lineSelectComboBox.DataSource = lineList;
            lineSelectComboBox.DisplayMember = "name";
            lineSelectComboBox.ValueMember = "lineId";

            int selectedLineId = (int)lineSelectComboBox.SelectedValue;
            List<Section> filteredSectionList = new List<Section>();
            foreach(Section section in sectionList)
            {
                if(section.lineId == selectedLineId)
                {
                    filteredSectionList.Add(section);
                }
            }
            filteredBlockList = new List<Block>();
            foreach (var block in blockList)
            {
                Section parentSection = null;
                foreach(Section section in filteredSectionList)
                {
                    if(block.sectionId == section.sectionId)
                    {
                        block.section = section.name;
                        filteredBlockList.Add(block);
                        break;
                    }
                }
            }

            blockSelectListBox.DataSource = filteredBlockList;
            blockSelectListBox.DisplayMember = "blockNum";
            blockSelectListBox.ValueMember = "blockId";
        }
        
        private void deleteAllDbRows(SqlConnection con)
        {
            con.Open();
            //first drop foreign keys
            dropConstraints(con);

            string sqlTrunc = "TRUNCATE TABLE dbo.Stations";
            SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            sqlTrunc = "TRUNCATE TABLE dbo.Switches";
            cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            sqlTrunc = "TRUNCATE TABLE dbo.Blocks";
            cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            sqlTrunc = "TRUNCATE TABLE dbo.Sections";
            cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            sqlTrunc = "TRUNCATE TABLE dbo.Lines";
            cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            //now recreate foreign keys
            addConstraints(con);

            con.Close();
        }

        //assume connection already open
        private void dropConstraints(SqlConnection con)
        {
            string sqlDropFK = "ALTER TABLE Sections DROP CONSTRAINT FK_Sections_ToTable";
            SqlCommand cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
            sqlDropFK = "ALTER TABLE Blocks DROP CONSTRAINT FK_SectionId";
            cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
            sqlDropFK = "ALTER TABLE Stations DROP CONSTRAINT FK_StationBlockId";
            cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
            sqlDropFK = "ALTER TABLE Switches DROP CONSTRAINT FK_SourceBlock";
            cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
            sqlDropFK = "ALTER TABLE Switches DROP CONSTRAINT FK_TargetBlock1";
            cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
            sqlDropFK = "ALTER TABLE Switches DROP CONSTRAINT FK_TargetBlock2";
            cmd = new SqlCommand(sqlDropFK, con);
            cmd.ExecuteNonQuery();
        }
        private void addConstraints(SqlConnection con)
        {
            string sqlAddFK = "ALTER TABLE Sections ADD CONSTRAINT [FK_Sections_ToTable] FOREIGN KEY ([LineId]) REFERENCES [dbo].[Lines] ([LineId])";
            SqlCommand cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
            sqlAddFK = "ALTER TABLE Blocks ADD CONSTRAINT [FK_SectionId] FOREIGN KEY ([SectionId]) REFERENCES [dbo].[Sections] ([SectionId])";
            cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
            sqlAddFK = "ALTER TABLE Stations ADD CONSTRAINT [FK_StationBlockId] FOREIGN KEY ([BlockId]) REFERENCES [dbo].[Blocks] ([BlockId])";
            cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
            sqlAddFK = "ALTER TABLE Switches ADD CONSTRAINT [FK_SourceBlock] FOREIGN KEY ([SourceBlockId]) REFERENCES [dbo].[Blocks] ([BlockId])";
            cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
            sqlAddFK = "ALTER TABLE Switches ADD CONSTRAINT [FK_TargetBlock1] FOREIGN KEY ([TargetBlockId_1]) REFERENCES [dbo].[Blocks] ([BlockId])";
            cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
            sqlAddFK = "ALTER TABLE Switches ADD CONSTRAINT [FK_TargetBlock2] FOREIGN KEY ([TargetBlockId_2]) REFERENCES [dbo].[Blocks] ([BlockId])";
            cmd = new SqlCommand(sqlAddFK, con);
            cmd.ExecuteNonQuery();
        }

        private void InsertToSql_Click(object sender, EventArgs e)
        {
            
        }

        private void uploadButtonClick(object sender, EventArgs e)
        {
            openExcelFileDialog.ShowDialog();
        }

        private void lineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLine = (Line)((ComboBox)sender).SelectedItem;
            int selectedLineId = selectedLine.lineId;
            List<Section> filteredSectionList = new List<Section>();
            foreach (Section section in sectionList)
            {
                if (section.lineId == selectedLineId)
                {
                    filteredSectionList.Add(section);
                }
            }
            filteredBlockList = new List<Block>();
            foreach (var block in blockList)
            {
                Section parentSection = null;
                foreach (Section section in filteredSectionList)
                {
                    if (block.sectionId == section.sectionId)
                    {
                        block.section = section.name;
                        filteredBlockList.Add(block);
                        break;
                    }
                }
            }

            blockSelectListBox.DataSource = filteredBlockList;
            blockSelectListBox.DisplayMember = "blockNum";
            blockSelectListBox.ValueMember = "blockId";
        }

        private void blockSelectedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedLine != null)
            {
                selectedBlock = (Block)((ListBox)sender).SelectedItem;
                if(selectedBlock != null)
                {
                    lineTextBox.Text = selectedLine.name;
                    sectionTextBox.Text = selectedBlock.section;
                    blockNumberTextBox.Text = selectedBlock.blockNum.ToString();
                    blockLengthTextBox.Text = selectedBlock.length.ToString();
                    blockGradeTextBox.Text = selectedBlock.grade.ToString();
                    blockElevationTextBox.Text = selectedBlock.elevation.ToString();
                    blockCumElevationTextBox.Text = selectedBlock.cumElevation.ToString();
                    blockSpeedLimitTextBox.Text = selectedBlock.speedLimit.ToString();
                    blockStationTextBox.Text = "X";
                    if (selectedBlock.station != null)
                        blockPersonsUnloadingTextBox.Text = selectedBlock.station.name;
                    blockTemperatureTextBox.Text = "69"; //TODO
                    blockHeaterStatusTextBox.Text = "Off"; //TODO
                    blockIsUndergroundTextBox.Text = "NO";
                    if(selectedBlock.isUnderground)
                        blockIsUndergroundTextBox.Text = "YES";
                    blockSwitchTextBox.Text = "None";
                    if(selectedBlock.parentSwitch != null)
                    {
                        if (selectedBlock.parentSwitch.sourceBlockId == selectedBlock.blockId)
                            blockSwitchTextBox.Text = "Source";
                        else
                            blockSwitchTextBox.Text = "Target";
                        switchNumTextBox.Text = selectedBlock.parentSwitch.switchId.ToString();
                    }
                    blockArrowDirectionTextBox.Text = "<-->"; //TODO
                    blockPersonsWaitingTextBox.Text = "X";
                    blockBeaconTextBox.Text = "X";
                }
            }
        }
    }
}
