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
        public List<Block> blockList = new List<Block>();
        public List<Block> filteredBlockList = new List<Block>();
        public List<Section> sectionList = new List<Section>();
        public List<Line> lineList = new List<Line>();
        public List<Switch> switchList = new List<Switch>();
        public List<Train> trainList = new List<Train>();
        public Block selectedBlock;
        public Line selectedLine;

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

        //only returns null if the yard
        public Block getNextBlock(Block prevBlock, Block currBlock)
        {
            Block nextBlock = null;
            //if(currBlock.prevBlockId == null)
            return nextBlock;
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
            }
            //TrackControllerModule.initializeSwitches(switchList);
            TrainSimulation.mainOffice.initializeTrackLayout(lineList);
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

        /*public List<Line> loadLinesFromDB(SqlConnection con)
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

        public List<Section> loadSectionsFromDB(SqlConnection con)
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
                //int? startBlockId = reader.GetInt32(3); //TODO
                //int? endBlockId = reader.GetInt32(4);
                //bool isBidirectional = reader.GetBoolean(5);
                Section section = new Section(sectionId, name, lineId, null, null, false);
                sections.Add(section);
                foreach(Line line in lineList)
                {
                    if(line.lineId == section.lineId)
                    {
                        line.sections.Add(section);
                    }
                }
            }
            reader.Close();
            con.Close();

            return sections;
        }

        public List<Block> loadBlocksFromDB(SqlConnection con)
        {
            List<Block> blocks = new List<Block>();

            SqlCommand read = new SqlCommand("SELECT * FROM Blocks");
            read.CommandType = CommandType.Text;
            read.Connection = con;
            con.Open();
            SqlDataReader reader = read.ExecuteReader();
            while(reader.Read())
            {
                int blockId = reader.GetInt32(0);
                int blockNumber = reader.GetInt32(1);
                int sectionId = reader.GetInt32(2);
                decimal length = reader.GetDecimal(3);
                decimal grade = reader.GetDecimal(4);
                decimal elevation = reader.GetDecimal(5);
                decimal cumulativeElevation = reader.GetDecimal(6);
                int speedLimit = reader.GetInt32(7);
                //bool isUndergound = reader.GetBoolean(8);

                Block block = new Block(blockId, blockNumber, sectionId, length, grade, elevation, cumulativeElevation, speedLimit, false);
                block.prevBlockId = null;
                block.nextBlockId = null;
                blocks.Add(block);

                foreach(Line line in lineList)
                {
                    foreach(Section section in line.sections)
                    {
                        if(section.sectionId == block.sectionId)
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

        private void loadSwitchesFromDB(SqlConnection con)
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
                    foreach (Switch s in switchList)
                    {
                        if(s.switchId == currId)
                        {
                            currSwitch = s;
                            found = true;
                            break;
                        }
                    }
                    bool isNew = false;
                    if(!found)
                    {
                        currSwitch = new Switch(currId, null, null, null);
                        isNew = true;
                    }
                    if(infrastructure.Contains("SWITCH"))
                    {
                        currSwitch.sourceBlockId = currBlock.blockId;
                    }
                    else if(currSwitch.targetBlockId1 == null)
                    {
                        currSwitch.targetBlockId1 = currBlock.blockId;
                    }
                    else
                    {
                        currSwitch.targetBlockId2 = currBlock.blockId;
                    }
                    if(isNew)
                    {
                        switchList.Add(currSwitch);
                    }
                    currBlock.parentSwitch = currSwitch;
                }
                
            }
            reader.Close();
            con.Close();
        }

        private void updateBlocksNextPrevious() //uses blocks in Line/Section/Block format
        {
            foreach(Line line in lineList)
            {
                Block prevBlock = null;
                foreach(Section section in line.sections)
                {
                    foreach (Block block in section.blocks)
                    {
                        if (prevBlock != null)
                        {
                            if(!(prevBlock.parentSwitch != null && block.parentSwitch != null))
                            {
                                block.prevBlockId = prevBlock.blockId;
                                prevBlock.nextBlockId = block.blockId;
                            }
                        }
                        prevBlock = block;
                    }
                }
            }
        }*/
        
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
                    blockStationTextBox.Text = "X"; //TODO - here and below
                    blockPersonsUnloadingTextBox.Text = "X";
                    blockTemperatureTextBox.Text = "69";
                    blockHeaterStatusTextBox.Text = "X";
                    blockIsUndergroundTextBox.Text = "X";
                    blockTypeTextBox.Text = "X";
                    blockSwitchTextBox.Text = "X";
                    blockSwitchActivatedTextBox.Text = "X";
                    blockArrowDirectionTextBox.Text = "X";
                    blockPersonsWaitingTextBox.Text = "X";
                    blockBeaconTextBox.Text = "X";
                }
            }
        }
    }
}
