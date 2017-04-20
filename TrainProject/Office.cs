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
        int trainSelectedInt;
        bool trainSelectedBool;
        double sugSpeed;
        int sugAuth;
        int trainCounter = 0;
        public static TrackControllerModule module;
        Block currentBlock;
        int currentLineSelection = 1;

        List<Block> myBlockList;
        List<Line> myLineList;
        TrainModel[] trainModelArray = new TrainModel[50];
        public List<Train> myTrainList;
        Boolean autoMode; // 0 = man, 1 = auto
        Boolean MBOMode;

        public Office()
        {
            InitializeComponent();
            module = new TrackControllerModule();

        }

        public void updateTime(String time)
        {
            updateTimeLabel.Text = time;
            for (int i = 1; i <= trainCounter; i++)
            {
                tm_window = trainModelArray[i];
                if (tm_window != null)
                {
                    Invoke(new MethodInvoker(delegate { tm_window.updateTime(time); }));
                }
            }
        }

        public void dispatchNewTrain()
        {
            trainCounter++;            
            Train train = new Train(trainCounter, sugSpeed, sugAuth);
            myTrainList.Add(train);
            if (currentLineSelection == 1) //green
            {
                train.prevBlock = 152;
                train.currBlock = 152;
            }
            else //red
            {
                train.prevBlock = 229;
                train.currBlock = 229;
            }
            tm_window = new TrainModel(currentLineSelection, trainCounter);
            trainModelArray[trainCounter] = tm_window; //starts at 1 and skips 0 element, noted for the for loop
            tm_window.Show();
            module.dispatchNewTrain(trainCounter, tm_window, sugSpeed, sugAuth);
            train.authority = sugAuth;
            train.suggestedSpeed = sugSpeed;
            
        }


        public void dispatchMBOTrain(int line, double speed, int auth)
        {
            currentLineSelection = line;
            sugSpeed = speed;
            sugAuth = auth;
            trainCounter++;
            Train train = new Train(trainCounter, sugSpeed, sugAuth);
            myTrainList.Add(train);
            if (currentLineSelection == 1) //green
            {
                train.prevBlock = 152;
                train.currBlock = 152;
            }
            else //red
            {
                train.prevBlock = 229;
                train.currBlock = 229;
            }
            tm_window = new TrainModel(currentLineSelection, trainCounter);
            trainModelArray[trainCounter] = tm_window; //starts at 1 and skips 0 element, noted for the for loop
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
            myLineList = new List<Line>();
            Block yard = new TrainProject.Block(0, 1);
            myBlockList.Add(yard);
            myTrainList = new List<Train>();
            foreach (Line line in trackLines)
            {
                myLineList.Add(line);
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
                {
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

       /* private Block findBlock(int blockId)
        {
            foreach (Block block in myBlockList)
            {
                if (block.blockId == blockId)
                {
                    return block;
                }
            }
            return null;
        }*/

        private void selBlock(object sender, ListViewColumnMouseEventArgs e)
        {
            if (!(e.Item.SubItems[0].Text == "Yard"))
            {
                int blockSelected = Int32.Parse(e.Item.SubItems[0].Text) + 1;
                Block b = myBlockList[blockSelected - 1];//bc index starts at zero + header row
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

            else
            {
                trainSelectedBool = false;
            }
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
                trainSelectedInt = Int32.Parse(txtSubstrings[1]);
                Console.WriteLine("train selected is: " + trainSelectedInt);
                updateTrainLabel.Text = txtSubstrings[1];
                foreach (Train t in myTrainList)
                    if(t.trainId == trainSelectedInt)
                    {
                        updateSugSpeedLabel.Text = t.suggestedSpeed.ToString();
                        updateSugAuthLabel.Text = t.authority.ToString();
                    }
                trainSelectedBool = true;
            }
        }

       public void updateBlockOccupancy(int bId, bool occupied)
        {
            foreach (Train t in myTrainList)
            {
                if(!occupied && (bId == t.currBlock))
                {
                    Block b = findBlock(bId);
                    Block prevBlock = findBlock(t.prevBlock);
                    Block currBlock = findBlock(t.currBlock);
                    t.prevBlock = t.currBlock;
                    if (prevBlock == currBlock)
                    {
                        prevBlock = null;
                    }
                    Block nextBlock = getNextBlock(prevBlock, currBlock, bId);
                    t.currBlock = nextBlock.blockId;
                    if (b.lineId == 2) //red line
                    {
                        foreach (ListViewItem item in systemListView.Items)
                        {
                            if (item.Index == (nextBlock.blockNum))
                            {
                                item.SubItems[2] = new ListViewItem.ListViewSubItem()
                                { Text = "Train " + t.trainId.ToString() };
                            }

                            if (item.Index == (b.blockNum))
                            {
                                item.SubItems[2] = new ListViewItem.ListViewSubItem()
                                { Text = "-" };
                            }
                        }

                        if((t.currBlock == 229) && (t.prevBlock == 161))
                        {
                            tm_window = trainModelArray[t.trainId];
                            tm_window.closeTrainController();
                            tm_window.Close();
                            //t = null;
                            //myTrainList.Remove(t);
                        }

                    }

                    if (b.lineId == 1) //green line
                    {
                        foreach (ListViewItem item in systemListView2.Items)
                        {
                            if (item.Index == (nextBlock.blockNum))
                            {
                                item.SubItems[2] = new ListViewItem.ListViewSubItem()
                                { Text = "Train " + t.trainId.ToString() };
                            }

                            if (item.Index == (b.blockNum))
                            {
                                item.SubItems[2] = new ListViewItem.ListViewSubItem()
                                { Text = "-" };
                            }
                        }
                        if ((t.currBlock == 57) && (b.isToYard))
                        {
                            tm_window = trainModelArray[t.trainId];
                            tm_window.closeTrainController();
                            tm_window.Close();
                            //t = null;
                            //myTrainList.Remove(t);
                        }
                    }
                }
            }
        }

        public Block findBlock(int blockId)
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

        public Block findYardBlock(int lineId) 
        {
            foreach (Line line in myLineList)
            {
                if (line.lineId == lineId)
                {
                    foreach (Section section in line.sections)
                    {
                        foreach (Block block in section.blocks)
                        {
                            if (block.isFromYard)
                                return block;
                        }
                    }
                }
            }
            return null;
        }

        //only returns null if the yard
        public Block getNextBlock(Block prevBlock, Block currBlock, int? lineId = null)
        {
            Block nextBlock = null;
            bool isSource = false;
            bool isTarget = false;
            if (prevBlock == null && currBlock == null) //coming from yard
            {
                return findYardBlock((int)lineId); //TODO use findYardBlock
            }
            if (currBlock.parentSwitch != null)
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
            if (prevBlock == null && currBlock.parentSwitch != null) //if already on 1st block from yard
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

            if (prevBlock != null && currBlock.prevBlockId == null && currBlock.nextBlockId == null)
            {
                return null;
            }

            else if (prevBlock.parentSwitch != null && currBlock.parentSwitch != null) //if coming off a switch
            {
                if (currBlock.prevBlockId == null)
                {
                    return findBlock((int)currBlock.nextBlockId);
                }
                else
                {
                    return findBlock((int)currBlock.prevBlockId);
                }
            }
            else if (currBlock.parentSwitch != null && prevBlock.parentSwitch == null) //if entering a switch
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
                if (prevBlock.nextBlockId != null && prevBlock.nextBlockId == currBlock.blockId)
                {
                    return findBlock((int)currBlock.nextBlockId);
                }
                else if (prevBlock.prevBlockId != null && prevBlock.prevBlockId == currBlock.blockId)
                {
                    return findBlock((int)currBlock.prevBlockId);
                }
            }
            return nextBlock;
        }

        private void setAuto()
        {
            autoMode = true;
            TrainSimulation.MBOWindow.isAuto(autoMode);
        }

        private void setManual()
        {
            autoMode = false;
            MBOMode = false;
            TrainSimulation.MBOWindow.isAuto(autoMode);
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
           if (trainSelectedBool)
            {
                dispatchOldTrain(trainSelectedInt);
            }
           else
            {
                dispatchNewTrain();
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
            autoMode = false;
            autoButton.ForeColor = Color.Black;
            autoButton.BackColor = Color.White;
            manButton.ForeColor = Color.White;
            manButton.BackColor = Color.Black;

        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            //setAuto();
            //dispatchNewTrain();
            autoMode = true;
            autoButton.ForeColor = Color.White;
            autoButton.BackColor = Color.Black;
            manButton.ForeColor = Color.Black;
            manButton.BackColor = Color.White;

        }

        private void fbRadio_CheckedChanged(object sender, EventArgs e)
        {           
        
            autoMode = true;
            TrainSimulation.MBOWindow.isAuto(autoMode);
        
        }

        private void mboButton_CheckedChanged(object sender, EventArgs e)
        {
            MBOMode = true;
            TrainSimulation.MBOWindow.isMBO(MBOMode);
        }

        private void notifLabel_Click(object sender, EventArgs e)
        {

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
