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
        public Block selectedBlock;
        public Line selectedLine;

        public TrackModelUI()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e) //open file
        {

        }

        private void selectFile(object sender, EventArgs e)
        {
            openExcelFileDialog.ShowDialog();
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

            //now actually load the data into the database
            string str = ConfigurationManager.ConnectionStrings["TrainProject.Properties.Settings.TrackDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                //first delete all current db rows
                deleteAllDbRows(con);

                //then insert into Line table
                List<string> lineNames = new List<string>();
                con.Open();
                foreach (DataGridViewRow row in dvgBlocks.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        bool found = false;
                        string currName = row.Cells[0].Value.ToString();
                        foreach (string name in lineNames)
                        {
                            if (string.Compare(name, currName) == 0)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            lineNames.Add(currName);
                            SqlCommand cmd = new SqlCommand("INSERT INTO Lines (Name) VALUES (@Name)");
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Name", row.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                con.Close();

                List<string> lineSectionNames = new List<string>();
                con.Open();
                //now insert into Sections table
                foreach (DataGridViewRow row in dvgBlocks.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        bool found = false;
                        string currLine = row.Cells[0].Value.ToString();
                        string currName = row.Cells[1].Value.ToString();
                        foreach (string name in lineSectionNames)
                        {
                            if (string.Compare(name, currLine + currName) == 0)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            lineSectionNames.Add(currLine + currName);
                            SqlCommand read = new SqlCommand("SELECT * FROM Lines WHERE Name = @Name");
                            read.CommandType = CommandType.Text;
                            read.Connection = con;
                            read.Parameters.AddWithValue("@Name", currLine);
                            SqlDataReader reader = read.ExecuteReader();
                            if (reader.Read())
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Sections (Name, LineId) VALUES (@Name, @LineId)");
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Name", currName);
                                int lineId = reader.GetInt32(0);
                                cmd.Parameters.AddWithValue("@LineId", lineId);
                                reader.Close();
                                cmd.ExecuteNonQuery();
                            }
                            else
                                Console.WriteLine("Associated line not found for section.");
                        }
                    }
                }
                con.Close();

                List<string> lineBlockNames = new List<string>();
                con.Open();
                //now insert into Sections table
                foreach (DataGridViewRow row in dvgBlocks.Rows)
                {
                    if (row.Cells[2].Value != null) //Block Id
                    {
                        bool found = false;
                        string currLine = row.Cells[0].Value.ToString();
                        string currSection = row.Cells[1].Value.ToString();
                        string currNumber = row.Cells[2].Value.ToString();
                        decimal currLength = Convert.ToDecimal(row.Cells[3].Value);
                        decimal currGrade = Convert.ToDecimal(row.Cells[4].Value);
                        int currSpeedLimit = Convert.ToInt32(row.Cells[5].Value);
                        decimal currElevation = Convert.ToDecimal(row.Cells[8].Value);
                        decimal currCumElevation = Convert.ToDecimal(row.Cells[9].Value);
                        foreach (string name in lineBlockNames)
                        {
                            if (string.Compare(name, currLine + currNumber) == 0)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            lineBlockNames.Add(currLine + currNumber);
                            SqlCommand read = new SqlCommand("SELECT Sections.SectionId, Sections.Name AS SectionName, Lines.Name AS LineName FROM Sections JOIN Lines ON Sections.LineId = Lines.LineId WHERE Sections.Name = @SectionName AND Lines.Name = @LineName");
                            read.CommandType = CommandType.Text;
                            read.Connection = con;
                            read.Parameters.AddWithValue("@SectionName", currSection);
                            read.Parameters.AddWithValue("@LineName", currLine);
                            SqlDataReader reader = read.ExecuteReader();
                            if (reader.Read())
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO Blocks (BlockNumber, SectionId, Length, Grade, Elevation, CumulativeElevation, SpeedLimit, IsUnderground) VALUES (@BlockNumber, @SectionId, @Length, @Grade, @Elevation, @CumulativeElevation, @SpeedLimit, @IsUnderground)");
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@BlockNumber", currNumber);
                                int sectionId = reader.GetInt32(0);
                                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                                cmd.Parameters.AddWithValue("@Length", currLength);
                                cmd.Parameters.AddWithValue("@Grade", currGrade);
                                cmd.Parameters.AddWithValue("@Elevation", currElevation);
                                cmd.Parameters.AddWithValue("@CumulativeElevation", currCumElevation);
                                cmd.Parameters.AddWithValue("@SpeedLimit", currSpeedLimit);
                                cmd.Parameters.AddWithValue("@IsUnderground", false);
                                reader.Close();
                                cmd.ExecuteNonQuery();
                            }
                            else
                                Console.WriteLine("Associated section not found for block.");
                        }
                    }
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
                blockList = loadBlocksFromDB(con);
                sectionList = loadSectionsFromDB(con);
                lineList = loadLinesFromDB(con);
            }

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

        private List<Line> loadLinesFromDB(SqlConnection con)
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

        private List<Section> loadSectionsFromDB(SqlConnection con)
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
            }
            reader.Close();
            con.Close();

            return sections;
        }

        private List<Block> loadBlocksFromDB(SqlConnection con)
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
                bool isUndergound = reader.GetBoolean(8);
                Block block = new Block(blockId, blockNumber, sectionId, length, grade, elevation, cumulativeElevation, speedLimit, isUndergound);
                blocks.Add(block);
            }
            reader.Close();
            con.Close();

            return blocks;
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
