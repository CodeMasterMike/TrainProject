using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainProject;
using TrainModelProject;
using TrainProject.HelperObjects;

namespace CTC
{
    public partial class Office : Form
    {
        TrainModel tm_window;
        int trainId;
        int selTrainId;
        bool trainSelected;
        double sugSpeed;
        int sugAuth;
        int trainCounter = 0;
        public static TrackControllerModule module;
        Block currentBlock;
        int currentLineSelection = 1;
        
        List<Block> myBlockList;
        public List<Train> myTrainList;
        Boolean mode; // 0 = man, 1 = auto

        public Office()
        {
            InitializeComponent();
            module = new TrackControllerModule();

        }

        public void updateTime(String time)
        {
            updateTimeLabel.Text = time;
            if (tm_window != null)
            {
                Invoke(new MethodInvoker(delegate { tm_window.updateTime(time); }));
            }
        }

        public void dispatchNewTrain()
        {
            trainCounter++;            
            Train train = new Train(trainCounter, sugSpeed, sugAuth);
            myTrainList.Add(train);
            train.currBlock = 0;
            tm_window = new TrainModel(currentLineSelection, trainCounter);
            tm_window.Show();
            module.dispatchNewTrain(trainCounter, tm_window, sugSpeed, sugAuth);
            train.authority = sugAuth;
            train.suggestedSpeed = sugSpeed;
        }

        public void dispatchOldTrain(int trainId)
        {
            module.updateSpeedAndAuthority(trainId, sugSpeed, sugAuth);
        }

        public void initializeTrackLayout(List<Line> trackLines)
        {
            systemListView.View = View.Details;
            systemListView.FullRowSelect = true;
            ListViewExtender extendo = new ListViewExtender(systemListView);
            ListViewButtonColumn blockClick = new ListViewButtonColumn(0);
            blockClick.Click += selBlock;
            blockClick.FixedWidth = true;
            extendo.AddColumn(blockClick);
            ListViewButtonColumn trainClick = new ListViewButtonColumn(2);
            trainClick.Click += selTrain;
            trainClick.FixedWidth = true;
            extendo.AddColumn(trainClick);
            myBlockList = new List<Block>();
            Block yard = new TrainProject.Block(0, 1);
            myBlockList.Add(yard);
            myTrainList = new List<Train>();
            foreach (Line line in trackLines)
            {
                foreach(Section section in line.sections)
                if(line.lineId == 2) //red line
                {
                    foreach(Block block in section.blocks)
                    {
                        {
                            if (block != null)
                            {
                                myBlockList.Add(block);
                                block.isOccupied = false;
                                block.lineId = 2;
                                Console.WriteLine(block.line);
                                block.section = section.name;
                            }                               
                        }
                    }
                }
            }

            //add yard
            ListViewItem yrd = new ListViewItem();
            yrd.Text = "Yard";
            systemListView.Items.Add(yrd);


            foreach (Block block in myBlockList)
            {
                if (block.lineId == 2)
                {
                    String bl = block.blockNum.ToString();
                    ListViewItem item = new ListViewItem();
                    item.Text = block.blockNum.ToString();
                    item.SubItems.Add("Open");
                    item.SubItems.Add("-");//occupancy
                    systemListView.Items.Add(item);

                    if (block.parentSwitch != null) //check if block is associated with switch
                    {
                        if (block.blockId == block.parentSwitch.sourceBlockId)
                        {
                            int switchId = block.parentSwitch.switchId;
                            int currState = (int)TrackControllerModule.getSwitchState(switchId);
                            Block b = findBlock(currState);
                            //int currState = (int)TrackControllerWindow.controllerModule.getSwitchState(switchId);
                            if (currState == (b.blockId))
                            {
                                currState = (b.blockNum);
                            }

                            item.SubItems.Add(currState.ToString());
                        }
                    }
                    else
                    {
                        item.SubItems.Add("-");//switch state
                    }
                    item.SubItems.Add("-");//crossing state
                }
            }


            //-----------------Green Line--------------------

            systemListView2.View = View.Details;
            systemListView2.FullRowSelect = true;
            ListViewExtender extendo2 = new ListViewExtender(systemListView2);
            ListViewButtonColumn blockClick2 = new ListViewButtonColumn(0);
            blockClick2.Click += selBlock;
            blockClick2.FixedWidth = true;
            extendo2.AddColumn(blockClick2);
            ListViewButtonColumn trainClick2 = new ListViewButtonColumn(2);
            trainClick2.Click += selTrain;
            trainClick2.FixedWidth = true;
            extendo2.AddColumn(trainClick2);
            foreach (Line line in trackLines)
            {
                foreach (Section section in line.sections)
                    if (line.lineId == 1) //green line
                    {
                        foreach (Block block in section.blocks)
                        {
                            {
                                if (block != null)
                                {
                                    myBlockList.Add(block);
                                    block.isOccupied = false;
                                    block.lineId = 1;
                                    block.section = section.name;
                                }
                            }
                        }
                    }
            }

            //add yard
            yrd = new ListViewItem();
            yrd.Text = "Yard";
            systemListView2.Items.Add(yrd);


            foreach (Block block in myBlockList)
            {
                if (block.lineId == 1)
                {
                    String bl = block.blockNum.ToString();
                    ListViewItem item = new ListViewItem();
                    item.Text = block.blockNum.ToString();
                    item.SubItems.Add("Open");
                    item.SubItems.Add("-");//occupancy
                    systemListView2.Items.Add(item);

                    if (block.parentSwitch != null) //check if block is associated with switch
                    {
                        if (block.blockId == block.parentSwitch.sourceBlockId)
                        {
                            int switchId = block.parentSwitch.switchId;
                            int currState = (int)TrackControllerModule.getSwitchState(switchId);
                            Block b = findBlock(currState);
                            //int currState = (int)TrackControllerWindow.controllerModule.getSwitchState(switchId);
                            if (currState == (b.blockId))
                            {
                                currState = (b.blockNum);
                            }

                            item.SubItems.Add(currState.ToString());
                        }
                    }
                    else
                    {
                        item.SubItems.Add("-");//switch state
                    }
                    item.SubItems.Add("-");//crossing state
                }
            }

        }

        private Block findBlock(int blockId)
        {
            foreach (Block block in myBlockList)
            {
                if (block.blockId == blockId)
                {
                    return block;
                }
            }
            return null;
        }

        private void selBlock(object sender, ListViewColumnMouseEventArgs e)
        {
            int blockSelected = Int32.Parse(e.Item.SubItems[0].Text) +1;
            Block b = myBlockList[blockSelected-1];//bc index starts at zero + header row
            updateBlockLabel.Text = b.blockNum.ToString();
            if (b.isOccupied == true)
            {
                updateBlockStatLabel.Text = "Occupied";
            }
            else
            {
                updateBlockStatLabel.Text = "Empty";
            }
            updateSectionLabel.Text = b.section;
            updateLineLabel.Text = b.line;
        }

        private void selTrain(object sender, ListViewColumnMouseEventArgs e)
        {
            String trainSelected = e.Item.SubItems[2].Text;
            if (!(trainSelected.Equals("-")))
            {
                Char delimiter = ' ';
                String[] txtSubstrings = trainSelected.Split(delimiter);
                Console.WriteLine(txtSubstrings[0]);
                Console.WriteLine(txtSubstrings[1]);
                int trainSelectedInt = Int32.Parse(txtSubstrings[1]);
                Console.WriteLine("train selected is: " + trainSelectedInt);
                updateTrainLabel.Text = txtSubstrings[1];
                foreach (Train t in myTrainList)
                    if(t.trainId == trainSelectedInt)
                    {
                        updateSugSpeedLabel.Text = t.suggestedSpeed.ToString();
                        updateSugSpeedLabel.Text = t.authority.ToString();
                    }
            }
        }

        public void updateBlockOccupancy(int bId, bool occupied)
        {
            foreach (Block b in myBlockList)
            {
                if ((b.blockId == bId) && (occupied == true))
                {
                    if (b.isFromYard) //for the case when a train is just getting newly dispatched
                    {
                        foreach(Train t in myTrainList)
                        {
                            if (t.currBlock == 0)
                            {
                                t.prevBlock = t.currBlock;
                                t.currBlock = b.blockId; //curr block
                            }
                        }
                    }
                    
                    else
                    {
                        foreach (ListViewItem item in systemListView.Items)
                        {
                            if (item.Index == (b.blockNum))
                            {
                                foreach (Train t in myTrainList)
                                {
                                    int pBlock = t.currBlock;
                                    int nBlock = (getNextBlock(pBlock)).blockId;
                                    if (nBlock == b.blockId) //if trains curr block is this one
                                    {
                                        item.SubItems[2] = new ListViewItem.ListViewSubItem()
                                        { Text = "Train " + t.trainId.ToString() };
                                    }
                                }

                            }
                        }
                        foreach (Train t in myTrainList)
                        {
                            int pBlock = t.currBlock;
                            int nBlock = (getNextBlock(pBlock)).blockId;
                            if (nBlock == b.blockId)
                            {
                                t.currBlock = b.blockId;
                            }

                        }
                    }

                    b.isOccupied = true;
                }

                else if ((b.blockId == bId) && (occupied == false))
                {
                    foreach (ListViewItem item in systemListView.Items)
                    {
                        if (item.Index == (b.blockNum))
                        {
                            item.SubItems[2] = new ListViewItem.ListViewSubItem() { Text = "-" };
                        }
                    }
                    b.isOccupied = false;
                }
            }
        }

        private Block getBlock(int blockID)
        {
            foreach (Block block in myBlockList)
            {
                if (block.blockId == blockID) return block;
            }
            return null;
        }

        bool onSwitch = false;
        bool prevToNext = true;

        public Block getNextBlock(int i)
        {
            currentBlock = getBlock(i);
            int blockId = currentBlock.blockId;
            if (onSwitch)
            {
                configureDirection();
                onSwitch = false;
            }

            if (prevToNext)
            {
                if (currentBlock.nextBlockId != null)
                {
                    return getBlock((int)currentBlock.nextBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId1 == blockId)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId2 == blockId)
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
                else if (currentBlock.parentSwitch.targetBlockId1 == blockId)
                {
                    onSwitch = true;
                    return getBlock((int)currentBlock.parentSwitch.sourceBlockId);
                }
                else if (currentBlock.parentSwitch.targetBlockId2 == blockId)
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

        private void configureDirection()
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
            for (int i = 0; i < n - 1; i++)
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

        private void setAuto()
        {
            mode = true;
            TrainSimulation.MBOWindow.isAuto(mode);
        }

        private void setManual()
        {
            mode = false;
            TrainSimulation.MBOWindow.isAuto(mode);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void infoBox_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dispTrain_Click(object sender, EventArgs e)
        {
           if (trainSelected)
            {
                dispatchOldTrain(selTrainId);
            }
           else
            {
                dispatchNewTrain();
               /* 
                Button t = new Button();
                t.Size = new Size(100, 100);
                t.Location = new Point(100, 100);
                t.Text = "1";
                TrainSimulation.mainOffice.systemBox.Controls.Add(t);
                Controls.Add(t);
                Console.WriteLine("past button create");
                */
            }
        }

        private void dispatchGroup_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openBlockButton_Click(object sender, EventArgs e)
        {

        }

        private void closeBlockButton_Click(object sender, EventArgs e)
        {

        }

        private void fixTrackButton_Click(object sender, EventArgs e)
        {

        }

        private void fixTrainButton_Click(object sender, EventArgs e)
        {

        }

        private void manButton_Click(object sender, EventArgs e)
        {
            setManual();
            mode = false;
            autoButton.ForeColor = Color.Black;
            autoButton.BackColor = Color.White;
            manButton.ForeColor = Color.White;
            manButton.BackColor = Color.Black;

        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            setAuto();
            dispatchNewTrain();
            mode = true;
            autoButton.ForeColor = Color.White;
            autoButton.BackColor = Color.Black;
            manButton.ForeColor = Color.Black;
            manButton.BackColor = Color.White;

        }

        private void fbRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mboButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void notifLabel_Click(object sender, EventArgs e)
        {

        }

        private void yardTrain_Click(object sender, EventArgs e)
        {
            trainSelected = false;
        }


        private void speedScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            sugSpeed = speedScrollBar.Value;
            speedValueLabel.Text = sugSpeed + " mph";
        }

        private void authScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            sugAuth = authScrollBar.Value;
            authValueLabel.Text = sugAuth + " blocks";
        }

        private void Office_Load(object sender, EventArgs e)
        {

        }

        private void lineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLineSelection = lineSelect.SelectedIndex + 1;
        }

        private void updateTrainLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateSugSpeedLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateSugAuthLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateBlockLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateBlockStatLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateSectionLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateLineLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateNumTrainsLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateThroughputLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
