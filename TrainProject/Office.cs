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
        
        List<Block> myBlockList;
        Boolean mode;

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
            tm_window = new TrainModel();
            tm_window.Show();

            module.dispatchNewTrain(trainCounter, tm_window, sugSpeed, sugAuth);
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
            blockClick.Click += selTrain;
            trainClick.FixedWidth = true;
            extendo.AddColumn(trainClick);
            myBlockList = new List<Block>();
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
                                    block.line = "Red";
                                    block.section = section.name;
                                }
                                String bl = block.blockNum.ToString();
                            ListViewItem item = new ListViewItem();
                            item.Text = block.blockNum.ToString();
                            item.SubItems.Add("Open");
                            item.SubItems.Add("-");//occupancy
                                if (block.parentSwitch != null) //check if block is associated with switch
                                {
                                    if (block.blockId == block.parentSwitch.sourceBlockId)
                                    {
                                        int switchId = block.parentSwitch.switchId;
                                        int currState = (int)TrackControllerModule.getSwitchState(switchId);
                                        //int currState = (int)TrackControllerWindow.controllerModule.getSwitchState(switchId);
                                        foreach (Block b in section.blocks)
                                        {
                                            if (currState == b.blockId)
                                                {
                                                    currState = b.blockNum;
                                                }
                                        }
                                               
                                        item.SubItems.Add(currState.ToString());
                                    }
                                }
                                else
                                {
                                    item.SubItems.Add("-");//switch state
                                }
                            item.SubItems.Add("-");//crossing state
                            systemListView.Items.Add(item);
                               
                        }
                    }
                }
            }
        }

        private void selBlock(object sender, ListViewColumnMouseEventArgs e)
        {
            Console.WriteLine("hit sel block");
            int blockSelected = Int32.Parse(e.Item.SubItems[0].Text) +1;
            Console.WriteLine(blockSelected);
            Block b = myBlockList[blockSelected];
            updateBlockLabel.Text = b.blockNum.ToString();
            Console.WriteLine(updateBlockLabel.Text);
            if (b.isOccupied == true)
            {
                updateBlockStatLabel.Text = "Occupied";
            }
            else
            {
                updateBlockStatLabel.Text = "Empty";
            }
            updateSectionLabel.Text = b.section;
            Console.WriteLine(updateSectionLabel.Text);
            updateLineLabel.Text = b.line;
            Console.WriteLine(updateLineLabel.Text);

        }

        private void selTrain(object sender, ListViewColumnMouseEventArgs e)
        {
            //something
        }

        public void updateBlockOccupancy(int bId, bool occupied)
        {
            foreach (Block b in myBlockList)
            {
                if ((b.blockId == bId) && (occupied == true))
                {
                    Console.WriteLine(b.blockId);
                    Console.WriteLine(bId);
                    foreach (ListViewItem item in systemListView.Items)
                    {
                        if (item.Index == b.blockNum)
                        {
                            item.SubItems[2] = new ListViewItem.ListViewSubItem() { Text = "Train 1" };
                        }
                    }
                    b.isOccupied = true;
                }
                else if ((b.blockId == bId) && (occupied == false))
                {
                    Console.WriteLine(b.blockNum);
                    Console.WriteLine(bId);
                    foreach (ListViewItem item in systemListView.Items)
                    {
                        if (item.Index == b.blockNum)
                        {
                            item.SubItems[2] = new ListViewItem.ListViewSubItem() { Text = "-" };
                        }
                    }
                    b.isOccupied = false;
                }
            }
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

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            setAuto();
            dispatchNewTrain();
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

        private void trackTrain_Click(object sender, EventArgs e)
        {
            trainSelected = true;
            trainId = 1;

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
    }
}
